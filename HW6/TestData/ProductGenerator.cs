using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    class ProductGenerator
    {
        public static Product GenerateProduct()
        {
            return new Product("BrovaTheOctopus", "Seafood", "Heli Su?waren GmbH & Co. KG", "60","1", "1", "1", "1");
        }
    }
}
