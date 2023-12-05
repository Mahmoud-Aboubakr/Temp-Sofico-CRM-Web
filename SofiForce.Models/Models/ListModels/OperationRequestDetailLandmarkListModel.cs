using System;
using System.Collections.Generic;

namespace Models
{
    public class OperationRequestDetailLandmarkListModel
    {

        public string Id { get; set; }
        public long DetaillandId { get; set; }

        public long DetailId { get; set; }
        public int LandmarkId { get; set; }
        public string LandmarkName { get; set; }
    }
}
