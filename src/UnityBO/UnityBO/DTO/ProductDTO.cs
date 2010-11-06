using System;
using UnityBO.Interfaces;

namespace UnityBO.DTO
{
    public class ProductDTO : DTOObjectBase, IProduct
    {
        public int ProductId { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if(value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
                
            }
        }

        private string _productNumber;
        public string ProductNumber
        {
            get { return _productNumber; }
            set
            {
                if (value != _productNumber)
                {
                    _productNumber = value;
                    NotifyPropertyChanged("ProductNumber");
                }
            }
        }

        public string Color { get; set; }
        public decimal ListPrice { get; set; }
        public int DaysToManufacture { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int SubcategoryId { get; set; }
    }
}
