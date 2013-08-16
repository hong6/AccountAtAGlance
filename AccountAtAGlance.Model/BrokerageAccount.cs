using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
//Building ASP.NET MVC Apps with EF Code First, HTML5, and jQuery
//By Dan Wahlin
namespace AccountAtAGlance.Model
{
    public class BrokerageAccount
    {
        public BrokerageAccount()
        {
            Positions = new HashSet<Position>();
            Orders = new HashSet<Order>();
        }

        //Primitive properties, POCO class      
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountTitle { get; set; }        
        public decimal Total { get; set; }
        public decimal MarginBalance { get; set; }
        public bool IsRetirement { get; set; }
        public int CustomerId { get; set; }
        public decimal CashTotal { get; set; }
        public decimal PositionsTotal { get; set; }
        public int WatchListId { get; set; }
        

        //Navigation properties
        ICollection<Position> Positions { get; set; }
        ICollection<Order> Orders { get; set; }
        WatchList WatchList { get; set; }
    }
}
