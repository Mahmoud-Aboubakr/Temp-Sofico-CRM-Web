using System;

namespace Models
{
    public class SysdiagramsModel
    {
        public string name { get; set; }
        public int principal_id { get; set; }
        public int diagram_id { get; set; }
        public int? version { get; set; }
        public byte[] definition { get; set; }
    }
}
