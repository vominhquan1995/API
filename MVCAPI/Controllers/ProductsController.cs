using DBProductDataContext;
using MVCAPI.Controllers;
using MVCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCAPI.Controllers
{
    
    public class ProductsController : ApiController
    {
        
        DBProductsDataContext context = new DBProductsDataContext();
       // [Authorize]
        public IEnumerable<Product> GetAll()
        {
            IList<Product> list = new List<Product>();
            var query = (from prods in context.Products select prods).ToList();
            foreach(var item in query)
            {
                list.Add(new Product
                {
                    Id = Convert.ToInt32(item.Id),
                    Name = item.Name,
                    Descriptionpd = item.Descriptionpd,
                    Price=Convert.ToDecimal(item.Price),
                    Unit=item.Unit,
                    CatId=Convert.ToInt32(item.CatId)       
                });
            }
            return list;
        }
        public IEnumerable<Product> GetCateloriesByID(int catid)
        {
            IList<Product> list = new List<Product>();
            var query = (from prods in context.Products where prods.CatId==catid select prods).ToList();
            foreach (var item in query)
            {
                list.Add(new Product
                {
                    Id = Convert.ToInt32(item.Id),
                    Name = item.Name,
                    Descriptionpd = item.Descriptionpd,
                    Price = Convert.ToDecimal(item.Price),
                    Unit = item.Unit,
                    CatId = Convert.ToInt32(item.CatId)
                });
            }
            return list;
        }
        public Product GetByID(int id)
        {
            Product product;
            var query = (from prods in context.Products where prods.Id == id select prods).SingleOrDefault();
                product=new Product
                {
                    Id = Convert.ToInt32(query.Id),
                    Name = query.Name,
                    Descriptionpd =  query.Descriptionpd,
                    Price = Convert.ToDecimal(query.Price),
                    Unit = query.Unit,
                    CatId = Convert.ToInt32(query.CatId)
                };
            return product;
        }
    }
}
