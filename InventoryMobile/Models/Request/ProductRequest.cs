using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMobile.Models.Request
{
    public class ProductRequest
    {
        public ProductRequest(
            string description, 
            int storaged, 
            string codeBar, 
            string unitOfMeasurement, 
            double price, 
            DateTime update)
        {
            ProductId = Guid.NewGuid();
            Description = description;
            Storaged = storaged;
            CodeBar = codeBar;
            UnitOfMeasurement = unitOfMeasurement;
            Price = price;
            Update = update;
        }

        public Guid ProductId { get; private set; }
        public string Description { get; private set; }
        public int Storaged { get; private set; }
        public string CodeBar { get; private set; }
        public string UnitOfMeasurement { get; private set; }
        public double Price { get; private set; }        
        public DateTime Update { get; private set; }
    }
}
