using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofiForce.Models.SyncModels
{
    public class ClientSyncModel
    {
        public Int32? ClientId { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public decimal? CreditLimit { get; set; }
        public decimal? CreditBalance { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string WhatsApp { get; set; }
        public string Address { get; set; }
        
        public bool? IsTaxable { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

    }
}
