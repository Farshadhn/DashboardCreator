using System;
using System.Collections.Generic;

namespace DashboardCreator.Models
{
    public class FoundProperty
    {
        public string PropertyName { get; set; }
        public Type PropertyType { get; set; }
    }
    public class FoundClass
    {
        public string ClassName { get; set; }
        public string FullName { get; set; }
        public string NameSpace { get; set; }
        public string[] FullNamespace { get; set; }
        public List<string> RelatedNamespace { get; set; }
        public string[] CommonNameSpace { get; set; }
        public List<FoundProperty> Properties { get; set; }
    }
}
