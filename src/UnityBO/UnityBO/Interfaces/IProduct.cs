using System;
using System.Collections.Generic;
using UnityBO.DTO;

namespace UnityBO.Interfaces
{
    public interface IProduct
    {
        int ProductId { get; set; }
        string Name { get; set; }
        string ProductNumber { get; set; }
        string Color { get; set; }
        decimal ListPrice { get; set; }
        int DaysToManufacture { get; set; }
        string Class { get; set; }
        string Style { get; set; }
        DateTime ModifiedDate { get; set; }
        int SubcategoryId { get; set; }

    }
}