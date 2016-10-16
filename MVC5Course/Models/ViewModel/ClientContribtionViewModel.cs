using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModel
{
    public class ClientContribtionViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<decimal> OrderTotal { get; set; }
    }
}