using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GridMvcPOC.Models
{
    public class Foo
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class OutputClass
    {
        public string PlanName { get; set; }

        public int PaymentAmount { get; set; }
    }
}