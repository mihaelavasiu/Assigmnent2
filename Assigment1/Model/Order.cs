using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment1
{
    public class Order
    {
    public int ID  { get; set; }
    public string Customer { get; set; }
    public string Address  { get; set; }
    public DateTime DeliveryDate  { get; set; }
    public string Status  { get; set; }
    public int Pieces  { get; set; }
    public int Value  { get; set; }
    public int ProductID  { get; set; }
    }
}
