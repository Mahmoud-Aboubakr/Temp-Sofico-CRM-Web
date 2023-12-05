using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Models;
using SofiForce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Hubs
{
    public class AppHub : Hub
    {

        //    public override Task OnConnectedAsync()
        //    {
        //        try
        //        {
        //            if(Context.User.FindFirst("UserId")!=null && Context.User.FindFirst("UserId").Value != null)
        //            {
        //                int UserId = int.Parse(Context.User.FindFirst("UserId").Value);
        //                if (UserId > 0)
        //                {
        //                    var user = new BOAppUser(UserId);
        //                    user.SignalrId = Context.ConnectionId;
        //                    user.Update();
        //                }
        //            }

        //        }
        //        catch(Exception ex) 
        //        {

        //        }
        //        return base.OnConnectedAsync();
        //    }
        //    public AppHub(IHttpContextAccessor contextAccessor)
        //    {

        //    }

        //    public string GetConnectionId() => Context.ConnectionId;
    }
}
