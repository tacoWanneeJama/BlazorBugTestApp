using Blazorise;
using Microsoft.AspNetCore.Components;

namespace BlazorBugTestApp.Client.Pages
{
    [Route("stressTestGraph")]
    [Route("/")]

    public partial class StressTestGraph
    {
        private List<(DateTime Time, double Value, double Value2)> _data = new();

        private bool series1Hidden = false;
        private bool series2Hidden = false;

        private Random _rand = new Random();

        public StressTestGraph()
        {
            DateTime date = DateTime.Parse("06:00:00");
            for(int i = 0; i < 800; i++)
            {
                _data.Add((date, _rand.Next(1, 100), _rand.Next(1, 100)));
                date = date.AddMinutes(1);
            }           
        }
    }
}
