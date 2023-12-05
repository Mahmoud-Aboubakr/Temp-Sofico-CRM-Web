using Models;
using Newtonsoft.Json;
using SofiForce.BusinessObjects;
using SofiForce.Worker.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SofiForce.Worker
{
    public interface IOrderService
    {
        public Task<OrderAIFResponseModel> AddOrder(OrderAIFRequestModel model,double SalesId);
    }
    public class OrderService: IOrderService
    {
        string url = "http://10.100.1.82:8090/api/Sales/CreateSales";

        HttpClient client;
        public ISalesOrderManager SalesOrderManager { get; }
        public OrderService(ISalesOrderManager salesOrderManager)
        {
            client = new HttpClient();
            SalesOrderManager = salesOrderManager;
        }

        

        public async Task<OrderAIFResponseModel> AddOrder(OrderAIFRequestModel model,double SalesId)
        {

            var bo = new Criteria<BOSalesOrder>()
                .Add(Expression.Eq(nameof(BOSalesOrder.SalesId), SalesId))
                .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                .FirstOrDefault<BOSalesOrder>();
            bo.DeleteAllSalesOrderError();

            try
            {
                var hasErrors = OrderHelper.ValidateOrder(bo.SalesId.Value);
                if (hasErrors.Count == 0)
                {

                    OrderAIFResponseModel? responseModel = new OrderAIFResponseModel();


                    var json = JsonConvert.SerializeObject(model);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");


                    var response = await client.PostAsync(url, data);
                    var result = await response.Content.ReadAsStringAsync();


                    responseModel = JsonConvert.DeserializeObject<OrderAIFResponseModel>(result);


                    if (responseModel.ResponseCode == 200)
                    {
                        if (bo != null)
                        {
                            //update onhand


                            bo.IsInvoiced = true;
                            bo.InvoiceDate = responseModel.InvoiceDate;
                            bo.InvoiceCode = responseModel.InvoiceId;
                            bo.SalesOrderStatusId = 4;
                            bo.RecId = (long)responseModel.HeaderRecId;
                            bo.Inprogress = false;
                            bo.CreateDate = DateTime.Now;
                            bo.Update();


                            var res = SalesOrderManager.UpdateOnhand(bo.SalesId.Value);


                        }
                    }
                    else
                    {
                        if (bo != null)
                        {

                            bo.HasError = true;
                            bo.IsInvoiced = null;
                            bo.InvoiceDate = null;
                            bo.InvoiceCode = null;
                            bo.InvoiceRetry = bo.InvoiceRetry > 0 ? bo.InvoiceRetry++ : 1;
                            bo.Inprogress = false;
                            bo.CreateDate = null;
                            bo.Update();

                            var error = new BOSalesOrderError();
                            error.SalesId = (long)SalesId;
                            error.ErrorDate = DateTime.Now;
                            error.ErrorDetail = responseModel.Message;
                            error.SaveNew();

                        }
                    }
                    return responseModel;
                }
                else
                {
                    bo.HasError = true;
                    bo.IsInvoiced = null;
                    bo.InvoiceDate = null;
                    bo.InvoiceCode = null;
                    bo.InvoiceRetry = bo.InvoiceRetry > 0 ? bo.InvoiceRetry++ : 1;
                    bo.Inprogress = false;
                    bo.CreateDate = null;
                    bo.Update();

                    foreach (var er in hasErrors)
                    {
                        var error = new BOSalesOrderError();
                        error.SalesId = (long)SalesId;
                        error.ErrorDate = DateTime.Now;
                        error.ErrorDetail = er;
                        error.SaveNew();
                    }

                    return new OrderAIFResponseModel();
                }
            }
            catch (Exception ex)
            {

                if (bo != null)
                {
                    bo.IsInvoiced = null;
                    bo.InvoiceDate = null;
                    bo.InvoiceCode = null;
                    bo.InvoiceRetry = bo.InvoiceRetry > 0 ? bo.InvoiceRetry++ : 1;
                    bo.Inprogress = false;
                    bo.CreateDate = null;
                    bo.Update();

                    var error = new BOSalesOrderError();
                    error.SalesId = (long)SalesId;
                    error.ErrorDate = DateTime.Now;
                    error.ErrorDetail = ex.Message != null ? ex.Message : ex.InnerException.Message;
                    error.SaveNew();

                }

                return new OrderAIFResponseModel();
            }




        }
    }
}
