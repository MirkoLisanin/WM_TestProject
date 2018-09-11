using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM_TestProject.Models;

namespace WM_TestProject.Repository
{
    public interface IProductRepository
    {        
        IList<Product> GetAllProducts();        
        void AddProduct(Product p);
        void EditProduct(Product p);
        Product GetProductById(int id);
    }
}
