using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountAtAGlance.Model
{
    public class Security
    {
        public int Id { get; set; }
        public decimal Change { get; set; }
        public decimal PercentChange { get; set; }
        public decimal Last { get; set; }
        public decimal Shares { get; set; }
        public string Symbol { get; set; }
        public DateTime RetrievalDateTime { get; set; }
        public string Company { get; set; }

        public List<DataPoint> DataPoints { get; set; } 
    }
}
