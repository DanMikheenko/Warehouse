using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.UI
{
    internal class ProductRepository
    {
        public void Add(Product product)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (var context = new ApplicationContext())
            {
                var entity = context.Products.FirstOrDefault(item => item.Id == product.Id);

                if (entity != null)
                {
                    entity.Price = product.Price;
                    entity.Title = product.Title;
                    entity.Company = product.Company;

                    context.SaveChanges();
                }
            }
        }

        public void Delete(Product product)
        {
            using (var context = new ApplicationContext())
            {
                context.Products.Remove(product);

                context.SaveChanges();
            }
        }

    }
}
