

using Models;
using SofiForce.BusinessObjects;
using System.Data;
using System.Data.SqlClient;
using static Models.OrderAIFRequestModel;

namespace SofiForce.Worker
{
    public class Worker2 : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IOrderService orderService;

        public Worker2(ILogger<Worker2> logger, IConfiguration configuration, IOrderService orderService)
        {
            _logger = logger;
            _configuration= configuration;
            this.orderService = orderService;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            //should be this
            //_logger.LogInformation("Worker2 Start at: {time}", DateTimeOffset.Now);
            _logger.LogInformation("Invoice Start at: {time}", DateTimeOffset.Now);
            try
            {
                _logger.LogInformation("{info}: {time}", "Connections Done", DateTimeOffset.Now);
            }
            catch (Exception ex)
            {
                _logger.LogError("{error}: {time}", ex.Message, DateTimeOffset.Now);
            }
            await base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            

             

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {

                    // get branchs in Worker

                    var worker = new Criteria<BOServiceWorker>()
                        .Add(Expression.Eq(nameof(BOServiceWorker.ServiceWorkerCode), "2"))
                        .FirstOrDefault<BOServiceWorker>();

                    if(worker !=null && worker.IsActive == true)
                    {


                        var workerBranchs = new Criteria<BOBranchInvoiceingSetup>()
                               .Add(Expression.Eq(nameof(BOBranchInvoiceingSetup.ServiceWorkerId), worker.ServiceWorkerId))
                                .Add(Expression.Eq(nameof(BOBranchInvoiceingSetup.IsEnabled), true))
                               .List<BOBranchInvoiceingSetup>();

                        if (workerBranchs.Count > 0)
                        {

                            var BranchId= workerBranchs.Select(a=>a.BranchId).ToList();

                            if(BranchId.Count > 0)
                            {
                                var orders = new Criteria<BOSalesOrderVw>()
                                        .Add(Expression.In(nameof(BOSalesOrderVw.BranchId), string.Join(',', BranchId)))
                                        .Add(Expression.Eq(nameof(BOSalesOrderVw.SalesOrderStatusId), 3))
                                        .Add(Expression.Eq(nameof(BOSalesOrderVw.HasError), false))
                                        .Add(Expression.Eq(nameof(BOSalesOrderVw.IsDeleted), false))
                                        .List<BOSalesOrderVw>();

                                foreach (var order in orders)
                                {
                                    if (order != null)
                                    {

                                        var bo = new BOSalesOrder(order.SalesId.Value);
                                        bo.Inprogress = true;
                                        bo.Update();

                                        var orderDetails = new Criteria<BOSalesOrderDetailVw>()
                                                    .Add(Expression.Eq(nameof(BOSalesOrderDetailVw.SalesId), order.SalesId))
                                                    .List<BOSalesOrderDetailVw>();

                                        OrderAIFRequestModel model = new OrderAIFRequestModel()
                                        {
                                            CustAccount = order.ClientCode,
                                            CustomerReference = order.SalesCode,
                                            InventLocationId = order.StoreCode,
                                            InventSiteId = order.BranchCode,
                                            OrderSource = 1,
                                            SalesManId = order.RepresentativeCode,
                                            SalesTakerId = order.RepresentativeCode,
                                            ShipCarrierAccount = order.SalesId.Value.ToString(),
                                            transDate = DateTime.Now,
                                            CashDisc = order.ItemTotal > 0 ? Math.Round(order.CashDiscountTotal.Value / order.ItemTotal.Value * 100, 3) : 0,
                                            CashDiscValue = order.CashDiscountTotal.Value,
                                            Payment = new List<payment>()
                                            
                                {
                                    new payment()
                                    {
                                        Payment="ARPay",
                                        Reference="",
                                        Value=0,

                                    }
                                },

                                            salesLine = orderDetails.Select(a => new SalesLine()
                                            {
                                                ItemId = a.ItemCode != null ? a.ItemCode : "",
                                                Batch = a.Batch != null ? a.Batch : "",
                                                Discount = a.Discount != null ? (decimal)a.Discount : 0,
                                                Price = a.ClientPrice != null ? (decimal)a.ClientPrice : 0,
                                                Quantity = a.Quantity != null ? (decimal)a.Quantity : 0,
                                                Unit = a.UnitId > 0 ? a.UnitId.Value.ToString() : "0",

                                            }).ToList()

                                        };


                                        var res = await orderService.AddOrder(model, (double)order.SalesId);

                                    }



                                }
                            }
                           
                        }

                      
                    }

                   


                }
                catch (Exception ex)
                {
                    //should be this
                    //_logger.LogError("Worker 2 {error}: {time}",ex.Message, DateTimeOffset.Now);
                    _logger.LogError("Worker 1 {error}: {time}",ex.Message, DateTimeOffset.Now);

                }

                await Task.Delay( 1 * 1000, stoppingToken);
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            //should be this
            // _logger.LogInformation("Worker2 Stoped at: {time}", DateTimeOffset.Now);
            _logger.LogInformation("Worker1 Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}