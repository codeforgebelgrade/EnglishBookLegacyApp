using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SummerSchoolsApp
{
    [DataContract]
    public class ProductSettings
    {
        [DataMember(Name = "product_types")]
        public List<String> productTypes { get; set; }

        [DataMember(Name = "product_groups")]
        public List<String> productGroups { get; set; }

    }
}
