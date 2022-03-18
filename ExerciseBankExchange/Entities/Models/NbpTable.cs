using System.Collections.Generic;

namespace ExerciseBankExchange.Entities.Models
{
    public class NbpTable
    {
        public string table { get; set; }
        public string currency { get; set; }
        public string code { get; set; }
        public IList<Rates> rates { get; set; }
    }
}
