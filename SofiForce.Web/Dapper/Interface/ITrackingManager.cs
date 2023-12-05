using Models;
using SofiForce.Models.StatisticalModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface ITrackingManager
    {

        KBISummeryModel getKBISummeryRepresentative(int? RepresentativeId, DateTime from, DateTime to, string lan);

    }
}
