using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_expando_object
{
    class Expando_Example_Simple
    {
        public static void Init()
        {
            //origin : https://stackoverflow.com/questions/1653046/what-are-the-true-benefits-of-expandoobject

            dynamic contact = new ExpandoObject();

            contact.Name = "Patrick Hines";
            contact.Phone = "206 - 555 - 0144";
            contact.Address = new ExpandoObject();
            contact.Address.Street = "123 Main St";
            contact.Address.City = "Mercer Island";
            contact.Address.State = "WA";
            contact.Address.Postal = "68402";
        }
    }
}
