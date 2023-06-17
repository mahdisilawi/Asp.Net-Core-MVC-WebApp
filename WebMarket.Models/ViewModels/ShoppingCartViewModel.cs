using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public double CartTotal { get; set; }
        public IEnumerable<ShoppingCart> ListCart { get; set; }

       // public int Count { get; set; }
    }
}
