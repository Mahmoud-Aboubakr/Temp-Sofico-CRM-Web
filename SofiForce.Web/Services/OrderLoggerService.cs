using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using System;

namespace SofiForce.Web.Services
{
    public interface IOrderLoggerService
    {
        public void Log(long SalesId, OrderLogType LogTypeId,int UserId);
        public void LogError(long SalesId, string Error);
    }

    public class OrderLoggerService : IOrderLoggerService
    {
        public void Log(long SalesId, OrderLogType LogTypeId,int UserId)
        {
            try
            {
                var bo = new BOSalesOrderLog();
                bo.SalesId = SalesId;
                bo.SalesOrderLogTypeId = (int)LogTypeId;
                bo.LogDate = DateTime.Now;
                bo.UserId = UserId;

                bo.SaveNew();

            }
            catch 
            {  
                
            }
        }
        public void LogError(long SalesId, string Error)
        {
            try
            {
                var bo = new BOSalesOrderError();
                bo.SalesId = SalesId;
                bo.ErrorDetail = Error;
                bo.ErrorDate = DateTime.Now;
                bo.SaveNew();

            }
            catch
            {

            }
        }
    }

}
