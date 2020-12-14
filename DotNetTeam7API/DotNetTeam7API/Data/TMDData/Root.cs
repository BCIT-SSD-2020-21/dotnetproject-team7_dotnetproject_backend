using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Data.TMDData
{
    public class Root
    {
        public int page { get; set; }
        public List<Result> results { get; set; }
    }
}
