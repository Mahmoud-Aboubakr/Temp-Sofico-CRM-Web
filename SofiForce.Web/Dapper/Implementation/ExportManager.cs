using Dapper;
using SofiForce.Web.Dapper.Interface;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using System;
using SofiForce.Models.StatisticalModels;
using System.Collections.Generic;
using Models;

namespace SofiForce.Web.Dapper.Implementation
{
    public class ExportManager : IExportManager
    {

        private readonly DapperContext _context;
        public ExportManager(DapperContext context)
        {
            _context = context;
        }

        public List<ExportSalesDetailModel> getInvoiceDetails(ExportSearchModel searchmodel)
        {
            List<ExportSalesDetailModel> model = new List<ExportSalesDetailModel>();



            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var param = new
                    {
                        @BranchId = searchmodel.BranchId > 0 ? searchmodel.BranchId : null,
                        @StoreId = searchmodel.StoreId > 0 ? searchmodel.StoreId : null,
                        @ClientId = searchmodel.ClientId > 0 ? searchmodel.ClientId : null,
                        @RepresentativeId = searchmodel.RepresentativeId > 0 ? searchmodel.RepresentativeId : null,

                        @VendorId = searchmodel.VendorId > 0 ? searchmodel.VendorId : null,
                        @ItemId = searchmodel.ItemId > 0 ? searchmodel.ItemId : null,


                        @FromDate = searchmodel.FromDate,
                        @ToDate = searchmodel.ToDate
                    };
                    model = connection.Query<ExportSalesDetailModel>("Query_Export_SalesDetails_All", param, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return model;
        }

        public List<ExportSalesHeaderModel> getInvoiceHeaders(ExportSearchModel searchmodel)
        {
            List<ExportSalesHeaderModel> model = new List<ExportSalesHeaderModel>();



            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var param = new
                    {
                        @BranchId = searchmodel.BranchId > 0 ? searchmodel.BranchId : null,
                        @StoreId = searchmodel.StoreId > 0 ? searchmodel.StoreId : null,
                        @ClientId = searchmodel.ClientId > 0 ? searchmodel.ClientId : null,
                        @RepresentativeId = searchmodel.RepresentativeId > 0 ? searchmodel.RepresentativeId : null,




                        @FromDate = searchmodel.FromDate,
                        @ToDate = searchmodel.ToDate
                    };
                    model = connection.Query<ExportSalesHeaderModel>("Query_Export_SalesInvoices_All", param, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return model;
        }

    }
}
