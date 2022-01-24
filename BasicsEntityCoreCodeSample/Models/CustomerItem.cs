using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeconstructCodeSamples.Models
{
    public class CustomerItem
    {
        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public override string ToString() => CompanyName;
    }
}
