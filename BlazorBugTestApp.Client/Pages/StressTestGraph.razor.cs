using Blazorise;
using Blazorise.Charts.Svg;
using Microsoft.AspNetCore.Components;

namespace BlazorBugTestApp.Client.Pages
{
    [Route("stressTestGraph")]

    public partial class StressTestGraph
    {
        private SvgChart<(DateTime Time, double Value, double Value2, double Avg, double Avg2)> _chart1 = new();
        private SvgChart<(DateTime Time, double Value, double Value2, double Avg, double Avg2)> _chart2 = new();
        private List<(DateTime Time, double Value, double Value2, double Avg, double Avg2)> _data = new();
        private Random _rand = new Random();
        private Dictionary<int, List<(DateTime Time, double Value)>> _avg = new();

        private bool _showLine1 = false;
        private bool _showLine2 = false;

        public StressTestGraph()
        {
            DateTime date = DateTime.Parse("06:00:00");
            var rand1 = _rand.Next(1, 100);
            var rand2 = _rand.Next(1, 100);
            var total = rand1;
            var total2 = rand2;
            for (int i = 0; i < 800; i++)
            {
                if (i == 0)
                {
                    _data.Add((date, rand1, rand2, total / (i + 1), total2 / (i + 1)));
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
            _showLine1 = true;
            _showLine2 = true;
        }

        public void UpdateCharts()
        {
            _chart1.Update();
            _chart2.Update();
            StateHasChanged();
        }

        private bool ShowLineChanged(int v, object nv)
        {
            if(v == 1)
            {
                _showLine1 = (bool)nv;
            }
            else if(v == 2)
            {
                _showLine2 = (bool)nv;
            }
            UpdateCharts();
            return _showLine1 && _showLine2;
        }
    }
}
