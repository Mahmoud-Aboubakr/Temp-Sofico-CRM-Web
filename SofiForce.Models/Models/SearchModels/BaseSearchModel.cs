using System.Collections.Generic;

namespace Models
{
    public class BaseSearchModel
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public string Term { get; set; }

        public string TermBy { get; set; }
        public List<FilterBy> FilterBy { get; set; }
        public SortBy SortBy { get; set; }
    }
    public class FilterBy
    {
        public string Property { get; set; }
        public string Operand { get; set; }
        public object Value { get; set; }

    }
    public class SortBy
    {
        public string Property { get; set; }
        public string Order { get; set; }


    }
}