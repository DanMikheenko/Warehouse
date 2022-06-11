using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Warehouse.UI
{
    internal class ApplicationContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Config.xml");
            string connectionString = "";
            foreach (XmlNode node in doc.ChildNodes)
            {
                if (node.Name == "ConnectionString")
                    connectionString = node.InnerText;
            }

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
