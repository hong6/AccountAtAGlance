using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountAtAGlance.Model
{
    public class WatchList
    {
        public ICollection<TTargetEntity> Securities { get; set; }
    }
}
