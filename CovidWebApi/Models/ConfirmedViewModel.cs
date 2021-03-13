using System.Collections.Generic;

namespace CovidWebApi.Models
{
    public class ConfirmedViewModel
    {
        public Confirmed Confirmed { get; set; }
        public List<Confirmed> ConfirmedList { get; set; }
        public ConfirmedViewModel()
        {
            ConfirmedList = new List<Confirmed>();
        }
    }
    public class Confirmed
    {
        public string AnoMes { get; set; }
        public string Total { get; set; }
    }
}