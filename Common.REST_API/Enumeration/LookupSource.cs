using System;
using System.Collections.Generic;
using System.Text;

namespace Common.REST_API
{
    public class LookupSource : Enumeration
    {
        public static readonly LookupSource Brand = new LookupSource(1, "Brand");
        public static readonly LookupSource FormFactor = new LookupSource(2, "FormFactor");
        public static readonly LookupSource ProcessorType = new LookupSource(3, "ProcessorType");
        public static readonly LookupSource ProductType = new LookupSource(4, "ProductType");
        public LookupSource(int id, string name) : base(id, name)
        {
        }
    }
}
