using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GridMvcPOC.Models
{
    public static class FooRepository
    {
        public static List<Foo> GetAll()
        {
            return new List<Foo>
            {
                new Foo(){Title="Demo1", Description="asdf"},
                new Foo(){Title="Demo2", Description="asg"},
                new Foo(){Title="Demo3", Description="shgfd"},
                new Foo(){Title="Demo4", Description="dfghdfg"},
                new Foo(){Title="Demo5", Description="dfshdf"},
                new Foo(){Title="Demo6", Description="werer"},
                new Foo(){Title="Demo7", Description="asdsdb"},
                new Foo(){Title="Demo8", Description="ewrtret"}
            };
        }

        public static List<OutputClass> GetAllOutput()
        {
            return new List<OutputClass>
            {
                new OutputClass(){PaymentAmount=10,PlanName="asd"},
                new OutputClass(){PaymentAmount=20,PlanName="ew"},
                new OutputClass(){PaymentAmount=30,PlanName="rte"},
                new OutputClass(){PaymentAmount=40,PlanName="ery"},
                new OutputClass(){PaymentAmount=50,PlanName="hgj"},
                new OutputClass(){PaymentAmount=50,PlanName="wer"},
            };
        }

        public static List<tblOpcode> GetAllRecords()
        {
            using (var context = new PayMasterCommunicatorEntities1())
            {
                var data = context.tblOpcodes.ToList();
                return data;
            }
        }
    }
}