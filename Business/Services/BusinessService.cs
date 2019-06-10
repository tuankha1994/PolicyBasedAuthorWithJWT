using Data.DataTest;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public interface IBusinessService
    {
        Product GetProductById(long productId);
        List<Product> GetAllProduct();
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProductById(long productId);
    }

    public class BusinessService : IBusinessService
    {
        public Product AddProduct(Product product)
        {
            long id = 1;
            if (DataTest.ProductList.Count > 0)
            {
                id = DataTest.ProductList.Max(x => x.Id) + 1;
            }
            product.Id = id;
            DataTest.ProductList.Add(product);
            return product;
        }

        public Product DeleteProductById(long productId)
        {
            var productDelete = GetProductById(productId);
            DataTest.ProductList.Remove(productDelete);
            return productDelete;
        }

        public List<Product> GetAllProduct()
        {
            var listProduct = DataTest.ProductList;
            return listProduct;
        }

        public Product GetProductById(long productId)
        {
            var product = DataTest.ProductList.FirstOrDefault(x => x.Id == productId);
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            var productUpdate = DataTest.ProductList.FirstOrDefault(x => x.Id == product.Id);
            if (productUpdate != null)
            {
                productUpdate.Name = product.Name;
                productUpdate.Price = product.Price;
                return productUpdate;
            }
            return null;
        }
    }
}
