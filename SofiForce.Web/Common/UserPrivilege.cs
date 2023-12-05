using SofiForce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SofiForce.Web.Common
{
    public class UserPrivilege
    {
        public static string getUserBranchs(List<int> Selected,int UserId,bool IsFullDataAccess)
        {
            string branchs = "";

            if(Selected==null || Selected.Count() == 0)
            {
                if (IsFullDataAccess)
                {
                    branchs = string.Join(',', new Criteria<BOBranch>().List<BOBranch>().Select(a => a.BranchId).ToList());
                }
                else
                {
                    branchs = string.Join(',', new Criteria<BOAppUserBranch>()
                        .Add(Expression.Eq(nameof(BOAppUserBranch.UserId), UserId))
                        .List<BOAppUserBranch>().Select(a => a.BranchId).ToList());

                }
            }
            else
            {
                branchs = String.Join(',', Selected);
            }


            return branchs;
        }
    }
}
