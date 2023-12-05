using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class ClientClassificationListModel
    {
		public Int32? ClientClassificationId { get; set; }
		public string ClientClassificationCode { get; set; }

		public string ClientClassificationName { get; set; }

		public bool? IsActive { get; set; }
		public bool? CanEdit { get; set; }
		public bool? CanDelete { get; set; }
		public string Icon { get; set; }
		public string Color { get; set; }
		public Int32? DisplayOrder { get; set; }

	}
}
