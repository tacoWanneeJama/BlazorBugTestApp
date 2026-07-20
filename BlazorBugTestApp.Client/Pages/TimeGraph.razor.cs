using Microsoft.AspNetCore.Components;
using System.Dynamic;

namespace BlazorBugTestApp.Client.Pages
{
    [Route("timeGraph")]
    [Route("/")]
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

        private List<DateTime> _listTime = new()
        {
            DateTime.Parse("04:00:00"),
            DateTime.Parse("04:25:00"),
            DateTime.Parse("04:30:09"),
            DateTime.Parse("04:55:38"),
            DateTime.Parse("05:11:11"),
            DateTime.Parse("05:44:23"),
            DateTime.Parse("06:28:34"),
            DateTime.Parse("06:30:00"),
            DateTime.Parse("06:45:02"),
            DateTime.Parse("07:02:00"),
            DateTime.Parse("07:08:12"),
            DateTime.Parse("07:30:00"),
            DateTime.Parse("07:33:00"),
            DateTime.Parse("08:04:22"),
            DateTime.Parse("08:22:45")
        };
        private List<double> _listValues = new()
        {
            22.55,
            33.45,
            19.10,
            18.00,
            8.30,
            36.50,
            10.25,
            14.75,
            28.20,
            31.00,
            9.35,
            7.85,
            40.65,
            39.95,
            9.95
        };

        protected override void OnInitialized()
        {
            CombineList();
            base.OnInitialized();
        }

        private List<(DateTime, double)> _listCombined = new();

        public void ReadTimes()
        {
            foreach(var time in _listTime)
            {
                Console.WriteLine(time.ToOADate().ToString());
            }
        }

        public List<(DateTime, double)> CombineList()
        {
            _listCombined.Clear();
            for (int i = 0; i < _listTime.Count(); i++)
            {
                _listCombined.Add((_listTime[i], _listValues[i]));
            }
            return _listCombined;
        }

        public double GetValue(DateTime time)
        {
            for (int i = 0; i < _listCombined.Count; i++)
            {
                if (_listCombined[i].Item1 == time)
                {
                    return _listCombined[i].Item2;
                }
            }
            return 0.0;
        }

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
