using System;
using System.Collections.Generic;

namespace Models
{
    public class OperationRequestDetailApproveModel
    {
        public long DetailId { get; set; }
        public int Accuracy { get; set; }

        public int OperationTypeId { get; set; }

    }

}