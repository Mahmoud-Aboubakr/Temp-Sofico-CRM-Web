using Dapper;
using SofiForce.Web.Dapper.Interface;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using System;
using DocumentFormat.OpenXml.Spreadsheet;

namespace SofiForce.Web.Dapper.Implementation
{
    public class PromotionManager : IPromotionManager
    {

        private readonly DapperTempContext _tempContext;
        private readonly DapperContext _context;

        public PromotionManager(DapperTempContext tempContext, DapperContext context)
        {
            _tempContext = tempContext;
            _context = context;
        }

        public Task ClearCustomClient(int clientAttributeId)
        {
            if (clientAttributeId != 0)
            {

                using (var connection = _context.CreateConnection())
                {
                    var Res = connection.Query(string.Format("delete from PromtionCriteriaClientAttrCustom where clientAttributeId={0} ", clientAttributeId), commandType: CommandType.Text);
                }
            }


            return Task.CompletedTask;
        }

        public Task ClearCustomItem(int AttributeId)
        {
            if (AttributeId != 0)
            {

                using (var connection = _context.CreateConnection())
                {
                    var Res = connection.Query(string.Format("delete from PromotionCriteriaAttrCustom where AttributeId={0} ", AttributeId), commandType: CommandType.Text);
                }
            }


            return Task.CompletedTask;
        }

        public Task Upload(DataTable dt,int UserId)
        {

            if (dt != null)
            {

                using (var connection = _tempContext.CreateConnection())
                {
                    var Res = connection.Query(string.Format("truncate table Supplementary"), commandType: CommandType.Text);
                }

                using (var _SqlBulkCopy = new SqlBulkCopy(_tempContext.CreateConnection().ConnectionString))
                {
                    _SqlBulkCopy.DestinationTableName = "Supplementary";

                    _SqlBulkCopy.ColumnMappings.Add("FromDate", "FromDate");
                    _SqlBulkCopy.ColumnMappings.Add("ToDate", "ToDate");
                    _SqlBulkCopy.ColumnMappings.Add("InputCode", "InputCode");
                    _SqlBulkCopy.ColumnMappings.Add("Slice", "Slice");
                    _SqlBulkCopy.ColumnMappings.Add("Quantity", "Quantity");
                    _SqlBulkCopy.ColumnMappings.Add("Bouns", "Bouns");
                    _SqlBulkCopy.ColumnMappings.Add("OutputCode", "OutputCode");
                    _SqlBulkCopy.ColumnMappings.Add("Activate", "Activate");

                    _SqlBulkCopy.BatchSize = 5000;
                    _SqlBulkCopy.WriteToServer(dt);
                }



                using (var connection = _tempContext.CreateConnection())
                {
                    var Res = connection.Query(string.Format("exec Batch_Promotion_Supplementary {0} ", UserId), commandType: CommandType.Text);
                }
            }


            return Task.CompletedTask;
        }

        public Task UploadClients(DataTable dt,int clientAttributeId, int UserId)
        {
            if (dt != null)
            {

                using (var connection = _tempContext.CreateConnection())
                {
                    var Res = connection.Query(string.Format("delete from PromtionCriteriaClientAttrCustom where clientAttributeId={0}", clientAttributeId), commandType: CommandType.Text);
                }

                using (var _SqlBulkCopy = new SqlBulkCopy(_tempContext.CreateConnection().ConnectionString))
                {
                    _SqlBulkCopy.DestinationTableName = "PromtionCriteriaClientAttrCustom";
                   
                    _SqlBulkCopy.ColumnMappings.Add("clientCode", "clientCode");
                    _SqlBulkCopy.ColumnMappings.Add("clientAttributeId", "clientAttributeId");


                    _SqlBulkCopy.BatchSize = 5000;
                    _SqlBulkCopy.WriteToServer(dt);
                }



                using (var connection = _tempContext.CreateConnection())
                {
                    var Res = connection.Query(string.Format("exec Batch_PromtionCriteriaClientAttrCustom {0},{1} ", UserId, clientAttributeId), commandType: CommandType.Text);
                }
            }


            return Task.CompletedTask;
        }

        public Task UploadCutomItems(DataTable dt, int attributeId, int UserId)
        {
            if (dt != null)
            {

                using (var connection = _tempContext.CreateConnection())
                {
                    var Res = connection.Query(string.Format("delete from PromotionCriteriaAttrCustom where AttributeId={0}", attributeId), commandType: CommandType.Text);
                }

                using (var _SqlBulkCopy = new SqlBulkCopy(_tempContext.CreateConnection().ConnectionString))
                {
                    _SqlBulkCopy.DestinationTableName = "PromotionCriteriaAttrCustom";

                    _SqlBulkCopy.ColumnMappings.Add("ItemCode", "ItemCode");
                    _SqlBulkCopy.ColumnMappings.Add("AttributeId", "AttributeId");


                    _SqlBulkCopy.BatchSize = 5000;
                    _SqlBulkCopy.WriteToServer(dt);
                }



                using (var connection = _tempContext.CreateConnection())
                {
                    var Res = connection.Query(string.Format("exec Batch_PromotionCriteriaAttrCustom {0},{1} ", UserId, attributeId), commandType: CommandType.Text);
                }
            }


            return Task.CompletedTask;
        }
    }
}
