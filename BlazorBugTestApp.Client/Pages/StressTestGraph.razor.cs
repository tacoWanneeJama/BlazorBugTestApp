using Blazorise;
using Microsoft.AspNetCore.Components;

namespace BlazorBugTestApp.Client.Pages
{
    [Route("stressTestGraph")]
    [Route("/")]

    public partial class StressTestGraph
    {
        private List<(DateTime Time, double Value, double Value2, double Avg, double Avg2)> _data = new();

        private bool series1Hidden = false;
        private bool series2Hidden = false;

        private Random _rand = new Random();
        private Dictionary<int, List<(DateTime Time, double Value)>> _avg = new();
        

        public StressTestGraph()
        {
            DateTime date = DateTime.Parse("06:00:00");
            var rand1 = _rand.Next(1, 100);
            var rand2 = _rand.Next(1, 100);
            var total = rand1;
            var total2 = rand2;
            for (int i = 0; i < 800; i++)
            {
                if(i == 0)
                {
                    _data.Add((date, rand1, rand2, total / (i+1), total2 / (i + 1)));
                }
                else
                {
                    rand1 = _rand.Next(1, 100);
                    rand2 = _rand.Next(1, 100);
                    total += rand1;
                    total2 += rand2;
                    _data.Add((date, rand1, rand2, total / (i + 1), total2 / (i + 1)));
                }
                date = date.AddMinutes(1);
            }
        }

        public void StatusHasChanged1(bool status)
        {
            series1Hidden = status;
            StateHasChanged();
        }

        public void SatusHasChanged2(bool status)
        {
            series2Hidden = status;
            StateHasChanged();
        }

        


    }
}
