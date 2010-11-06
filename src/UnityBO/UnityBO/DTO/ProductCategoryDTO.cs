using System.Runtime.Serialization;

namespace UnityBO.DTO
{
    [DataContract]
    public class ProductCategoryDTO : DTOObjectBase
    {
        [DataMember]
        public int ProductCategoryId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}