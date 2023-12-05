using System;
using System.Collections.Generic;

namespace Models
{
    public class DateTypeModel : LookupModel
	{
        public bool IsCustom { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }



}