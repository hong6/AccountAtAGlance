using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using AccountAtAGlance.Model;

namespace AccountAtAGlance.Repository.Helpers
{
    //http://www.google.com/ig/api?stock=msft&stock=ibm&stock=goog
    public class StockEngine
    {
        private const string BASE_URL = "http://www.google.com/ig/api?";
        private readonly string _Separator = "&stock=";

        public List<Security> GetSecurityQuotes(params string[] symbols)
        {
            XDocument doc = CreateXDocument(symbols);
            return ParseSecurities(doc);
        }

        public List<MarketIndex> GetMarketQuotes(string[] symbols)
        {
            XDocument doc = CreateXDocument(symbols);
            return ParseMarketIndexes(doc);
        }

        private XDocument CreateXDocument(string[] symbols)
        {
            string symbolList = String.Join(_Separator, symbols);
            string url = string.Concat(BASE_URL, _Separator, "&Tick=", DateTime.Now.Ticks); //radom for cache

            try
            {
                XDocument doc = XDocument.Load(url);
                return doc;
            }
            catch { }
            return null;

        }

        private List<MarketIndex> ParseMarketIndexes(XDocument doc)
        {
            throw new NotImplementedException();
        }

        private List<Security> ParseSecurities(XDocument doc)
        {            
            if (doc == null)
                return null;

            List<Security> securities = new List<Security>();
            IEnumerable<XElement> quotes = doc.Root.Descendants("finance");

            foreach (var quote in quotes)
            {
                var symbol = GetAttributeData(quote, "symbol");
                var exchange = GetAttributeData(quote, "exchange");
                var last = GetDecimal(quote, "last");
                var change = GetDecimal(quote, "change");
                var percentChange = GetDecimal(quote, "perc_change");
                var company = GetAttributeData(quote, "company");
          
                //if (exchange.ToUpper() == "MUTF") //handle mutual fund
                if (exchange.ToUpper() == "NASDAQ") //handle mutual fund
                {
                    var mf = new MutualFund();
                    mf.Symbol = symbol;
                    mf.Last = last;
                    mf.Change = change;
                    mf.PercentChange = percentChange;
                    mf.RetrievalDateTime = DateTime.Now;
                    mf.Company = company;
                    securities.Add(mf);
                }
            }
            return securities;
        }

        private decimal GetDecimal(XElement quote, string elemName)
        {            
            return Convert.ToDecimal(GetAttributeData(quote, elemName));
        }

        private string GetAttributeData(XElement quote, string elemName)
        { 
            return quote.Element(elemName).Attribute("data").Value;            
        }

       
    }
}
