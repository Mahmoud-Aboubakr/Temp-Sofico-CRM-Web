using Dapper;
using SofiForce.Web.Dapper.Interface;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using System;
using SofiForce.Models.StatisticalModels;

namespace SofiForce.Web.Dapper.Implementation
{
    public class JourneyPlanManager : IJourneyPlanManager
    {

        private readonly DapperContext _context;
        public JourneyPlanManager(DapperContext context)
        {
            _context = context;
        }

        public Task clear()
        {
            using (var connection = _context.CreateConnection())
            {
                var Res = connection.Query(string.Format("delete from Representative_Journey "), commandType: CommandType.Text);
            }
            return Task.CompletedTask;
        }

        public Task duplicate(int UserId,int JourneyYear, int JourneyMonth)
        {
            using (var connection = _context.CreateConnection())
            {
                var param = new { @UserId = UserId, @JourneyYear = JourneyYear, @JourneyMonth= JourneyMonth };
                var Res = connection.Query(string.Format("Batch_JourneyPlan_Duplicate"), param, commandType: CommandType.StoredProcedure);
            }

            return Task.CompletedTask;
        }

        public Task Upload(DataTable dt,int UserId)
        {

            if (dt != null)
            {

                using (var _SqlBulkCopy = new SqlBulkCopy(_context.CreateConnection().ConnectionString))
                {
                    _SqlBulkCopy.DestinationTableName = "temp_JourneyPlan";

                    _SqlBulkCopy.ColumnMappings.Add("RouteCode", "RouteCode");
                    _SqlBulkCopy.ColumnMappings.Add("RepresentativeCode", "RepresentativeCode");

                    _SqlBulkCopy.BatchSize = 5000;
                    _SqlBulkCopy.WriteToServer(dt);
                }



                using (var connection = _context.CreateConnection())
                {
                    var Res = connection.Query(string.Format("exec Batch_JourneyPlan_Migrator {0} ",UserId), commandType: CommandType.Text);
                }
            }


            return Task.CompletedTask;
        }



        string getPerformanceLabel(decimal percentage)
        {
            string label = "Low";

            if (percentage >= 0 && percentage < 60)
                label = "Low";
            if (percentage >= 60 && percentage < 70)
                label = "Medium";
            if (percentage >= 80 && percentage < 90)
                label = "Normal";
            if (percentage >= 90 && percentage < 100)
                label = "High";
            if (percentage > 100)
                label = "Premium";

            return label;

        }
    }
}

