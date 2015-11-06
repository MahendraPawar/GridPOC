using System.Collections.Generic;
using System.Web.Mvc;
using PayMaster.Framework.Data;
using PayMaster.Framework.Model;

namespace PayMaster.Framework.Business
{
    public class OpCodeBa 
    {
        public static ICollection<OpCode> Get(OpCode obj)
        {
            return OpCodeDa.Get(obj);
        }
    }
}
