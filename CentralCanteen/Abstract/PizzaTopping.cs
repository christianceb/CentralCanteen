using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralCanteen
{
  public class PizzaTopping
  {
    public string Name { get; set; }
    public List<PizzaToppingSize> Sizes = new List<PizzaToppingSize>();
  }
}
