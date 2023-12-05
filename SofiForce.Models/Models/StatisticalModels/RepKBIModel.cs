using Models;
namespace SofiForce.Models.StatisticalModels
{
    public class RepKBIModel
    {

        public string FullName { get; set; }
        public string Title { get; set; }

        public List<TimelineModel> Timelines { get; set; }=new List<TimelineModel>(){ };
        public ToTargetPoint Sales { get; set; }=new ToTargetPoint();
        public ToTargetPoint Coverage { get; set; } = new ToTargetPoint();
        public ToTargetPoint Visits { get; set; } = new ToTargetPoint();

    }

}
