using Microsoft.AspNetCore.Components;

namespace BlazorBugTestApp.Client.Pages
{
    [Route("timeGraph")]
    public partial class TimeGraph
    {
        private List<(int Value, DateTime Time)> _data = new()
            {
                (1, DateTime.Parse("04:00:00")),
                (2, DateTime.Parse("04:25:00")),
                (3, DateTime.Parse("04:30:09")),
                (4, DateTime.Parse("04:55:38")),
                (5, DateTime.Parse("05:11:11")),
                (6, DateTime.Parse("05:44:23")),
                (7, DateTime.Parse("06:28:34")),
                (8, DateTime.Parse("06:30:00")),
                (9, DateTime.Parse("06:45:02")),
                (10, DateTime.Parse("07:02:00")),
                (11, DateTime.Parse("07:08:12")),
                (12, DateTime.Parse("07:30:00")),
                (13, DateTime.Parse("07:33:00")),
                (14, DateTime.Parse("08:04:22")),
                (15, DateTime.Parse("08:22:45"))
            };

        public List<(int Value, DateTime Time)> GetDataWithLocalTime()
        {
            List<(int Value, DateTime Time)> tempList = new();
            foreach (var d in _data)
            {
                tempList.Add((d.Value, d.Time.ToLocalTime()));
            }
            return tempList;
        }
    }
}
