using System;
using System.Collections.Generic;
using System.Text;

namespace Common.REST_API
{
    public class PropertyType : Enumeration
    {
        public static readonly PropertyType Int = new PropertyType(1, "Int");
        public static readonly PropertyType Long = new PropertyType(2, "Long");
        public static readonly PropertyType Text = new PropertyType(3, "Text");
        public static readonly PropertyType Dropdown = new PropertyType(4, "Dropdown");
        public PropertyType(int id, string name) : base(id, name)
        {
        }
    }
}
