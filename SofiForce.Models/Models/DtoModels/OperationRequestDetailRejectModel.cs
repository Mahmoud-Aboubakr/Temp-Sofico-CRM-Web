using System;
using System.Collections.Generic;

namespace Models
{
    public class OperationRequestDetailRejectModel 
	{
        public long DetailId { get; set; }
        public int Accuracy { get; set; }   
        public int OperationRejectReasonId { get; set; }
        public int OperationTypeId { get; set; }

    }



}