using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Dapper.Implementation;
using SofiForce.Web.Dapper.Interface;
using System.ComponentModel.DataAnnotations;

namespace Helpers
{
    public class CheckAuthorizedAttribute : ActionFilterAttribute
    {

        public int UserId { get; set; }
        public bool IsLocked { get; set; } = false;
        public BOAppUser ExistUser { get; set; }
        private readonly IUserPermissionManager _userPermissionManager;
        CustomResultModel customResultModel;
        public CheckAuthorizedAttribute()
        {
            customResultModel = new CustomResultModel();
            _userPermissionManager = new UserPermissionManager();
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            UserId = context.HttpContext.User.FindFirst("UserId") != null ? int.Parse(context.HttpContext.User.FindFirst("UserId").Value) : 0;
            IsLocked = context.HttpContext.User.FindFirst("IsLocked") != null ? bool.Parse(context.HttpContext.User.FindFirst("IsLocked").Value) : false;
            ExistUser = new Criteria<BOAppUser>().Add(Expression.Eq(nameof(BOAppUser.UserId), UserId)).FirstOrDefault<BOAppUser>();
            var userPermissions= _userPermissionManager.getUserPermission(UserId);
            /// need to get Permissions and validate it 
            
            if (ExistUser.IsLocked != IsLocked)
            {
                customResultModel.Succeeded = false;
                customResultModel.StatusCode = 401;
                customResultModel.Message = "unauth";
                context.Result = new ObjectResult(customResultModel);
            }
        }
    }
}
