using AIFSalesService;
using AutoMapper;
using Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Promotion;
using SofiForce.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM.Setup
{
    [Route("api/[controller]")]
    public class OrderAifController : BaseController
    {
        public OrderAifController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }


        [CheckAuthorizedAttribute]
        [HttpPost("CreateSales")]
        public async Task<IActionResult> CreateSalesOrder(OrderAIFRequestModel SalesOrder)
        {

            var task = Task.Factory.StartNew(async () =>
            {

                var response = new OrderAIFResponseModel();

                try
                {


                    ////Validate Order;
                    //var tempOrder=new SalesOrderModel();


                    //tempOrder = PromotionCalculator.ValidateOrder(tempOrder, Language);


                    //if(tempOrder == null || tempOrder.SalesId==null || tempOrder.SalesId==0 || tempOrder.SalesOrderDetails.Count == 0)
                    //{

                    //    return null;
                    //}

                    //if (tempOrder.HasError == true)
                    //{

                    //    var bo = new Criteria<BOSalesOrder>().Add(Expression.Eq(nameof(BOSalesOrder.SalesId), tempOrder.SalesId)).First<BOSalesOrder>();
                    //    bo.HasError = true;
                    //    bo.Update();
                    //    bo.DeleteAllSalesOrderError();

                    //    foreach (var error in tempOrder.Errors)
                    //    {
                    //        var er = new BOSalesOrderError();
                    //        er.SalesId = bo.SalesId;
                    //        er.ErrorDate = DateTime.Now;
                    //        er.ErrorDetail = error;                          
                    //        er.SaveNew();
                    //    }

                    //    return null;
                    //}


                    SFC_SalesAppRequestContract Contract = new SFC_SalesAppRequestContract();

                    var config = new MapperConfiguration(cfg =>
                           cfg.CreateMap<SFC_SalesAppResponseContract, OrderAIFResponseModel>()
                       );

                    Contract.CustAccount = SalesOrder.CustAccount;
                    Contract.CustRef = SalesOrder.CustomerReference;
                    Contract.SalesManId = SalesOrder.SalesManId;
                    Contract.InventSiteId = SalesOrder.InventSiteId;
                    Contract.InventLocationId = SalesOrder.InventLocationId;
                    Contract.DeliveryDate = SalesOrder.transDate.Date;

                    Contract.OrderSource = (OrderSource)SalesOrder.OrderSource;
                    Contract.SalesTakerId = SalesOrder.SalesTakerId;
                    Contract.ShipCarrierAccount = SalesOrder.ShipCarrierAccount;
                    Contract.CashDisc = SalesOrder.CashDisc;


                    //Contract.Cash =  Convert.ToDecimal( SalesOrder.Cash );
                    //Contract.Visa = Convert.ToDecimal(SalesOrder.Visa);

                    String[] Payments = SalesOrder.Payment.Select(i => i.Payment).ToArray();
                    decimal[] Values = SalesOrder.Payment.Select(i => i.Value).ToArray();
                    string[] References = SalesOrder.Payment.Select(i => i.Reference).ToArray();

                    Contract.Payment = Payments;
                    Contract.Value = Values;
                    Contract.PaymentRef = References;


                    String[] Items = SalesOrder.salesLine.Select(i => i.ItemId).ToArray();

                    decimal[] Quantities = SalesOrder.salesLine.Select(i => i.Quantity).ToArray();
                    String[] Batches = SalesOrder.salesLine.Select(i => i.Batch).ToArray();
                    decimal[] Price = SalesOrder.salesLine.Select(i => i.Price).ToArray();
                    decimal[] Discounts = SalesOrder.salesLine.Select(i => i.Discount).ToArray();
                    String[] Units = SalesOrder.salesLine.Select(i => i.Unit).ToArray();

                    Contract.Items = Items;
                    Contract.Batches = Batches;
                    Contract.Price = Price;
                    Contract.Qty = Quantities;
                    Contract.Discount = Discounts;
                    Contract.Unit = Units;



                    SFC_SalesAppServiceClient Client = new SFC_SalesAppServiceClient();

                    CallContext context = new CallContext();

                    context.Company = "sfc";
                    context.LogonAsUser = @"soficopharm.local\magdy.halim";
                    

                    var AXResponse = await Client.CreateSalesOrderAsync(context, Contract);


                    


                    var mapper = new Mapper(config);
                    var responseModel = mapper.Map<OrderAIFResponseModel>(AXResponse);


                    
                }
                catch (Exception ex)
                {

                }

                return response;
            });
            await task;

            return Ok(task.Result.Result);
        }
    }
}
