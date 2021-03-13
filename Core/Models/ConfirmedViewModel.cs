using System.Collections.Generic;

namespace Core.Models
{
    public class ConfirmedSummary
    {
        //Ajustado para AnoMes para que os dados do mes do ano anterior não sejam perdidos ou apresentados sem a referencia do respectivo ano
        public string AnoMes { get; set; }
        public long TotalUltimoDiaDoMes { get; set; }
        public long Total { get; set; }
    }
}