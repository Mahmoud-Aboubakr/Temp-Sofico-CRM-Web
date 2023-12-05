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
using static SofiForce.Web.Common.DateTimExtensions;
using SofiForce.Web.Common;

namespace SofiForce.Web.Dapper.Implementation
{
    public class TrackingManager : ITrackingManager
    {

        private readonly DapperContext _context;
        public TrackingManager(DapperContext context)
        {
            _context = context;
        }

        public KBISummeryModel getKBISummeryRepresentative(int? RepresentativeId, DateTime from, DateTime to,string lan)
        {
            KBISummeryModel res = new KBISummeryModel();


            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var paramAll = new
                    {
                        lan,
                        from,
                        to,
                        RepresentativeId ,

                    };

                    res = connection.Query<KBISummeryModel>("Query_Performance_Summery_Representative", paramAll, commandType: CommandType.StoredProcedure).FirstOrDefault();


                    if(res !=null)
                    {

                        if (res.SalesTarget > 0)
                            res.SalesP = (int)Math.Round((decimal)res.SalesTotal / (decimal)res.SalesTarget * 100, 0);

                        if (res.VisitTarget > 0)
                            res.VisitP = (int) Math.Round((decimal)res.VisitTotal / (decimal)res.VisitTarget * 100, 0);

                        if (res.CallTarget > 0)
                            res.CallP = (int)Math.Round((decimal)res.CallTotal / (decimal)res.CallTarget * 100, 0);

                        if (res.ClientsTarget > 0)
                            res.ClientsP = (int)Math.Round((decimal)res.Clients / (decimal)res.ClientsTarget * 100, 0);

                        
                        if (res.DaysTarget > 0)
                            res.DaysP = (int)Math.Round((decimal)res.Days / (decimal)res.DaysTarget * 100, 0);


                        res.PerformanceValue =(int) Math.Round((decimal)res.SalesP * 100 / 100 + res.CallP * 0 / 100 + res.VisitP * 0 / 100, 0);
                        res.PerformanceLabel = Utils.getPerformanceLabel(res.PerformanceValue);
                    }


                   
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return res;
        }
    }
}
