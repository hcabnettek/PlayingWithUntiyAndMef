using System;
using System.Runtime.Serialization;

namespace UnityBO.DTO
{
    [DataContract]
    public class ProductSubcategoryDTO : DTOObjectBase
    {
        [DataMember]
        public int ProductSubcategoryId { get; set; }

        [DataMember]
        public int ProductCategoryId { get; set; }

        [DataMember]
        public string Name { get; set; }

       
      
    }
}