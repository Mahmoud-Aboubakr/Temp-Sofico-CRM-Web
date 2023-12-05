using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PromtionCriteriaClientAttrCustomListModel
    {
		public string ClientCode { get; set; }
		public Int32? ClientId { get; set; }
		public string ClientName { get; set; }
		public Int32? ClientCustomId { get; set; }
		public Int32? ClientAttributeId { get; set; }
		public string ClientAttributeCode { get; set; }
		public string ClientAttributeName { get; set; }
		public bool? IsCustom { get; set; }
	}
}
