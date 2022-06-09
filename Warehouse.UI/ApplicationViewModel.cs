using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.UI
{
    internal class ApplicationViewModel:INotifyPropertyChanged
    {
        private Product selectedProduct;

        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public ApplicationViewModel()
        {
            Products = new ObservableCollection<Product>
            {
                new Product { Title="iPhone 7", Company="Apple", Price=56000 },
                new Product {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
                new Product {Title="Elite x3", Company="HP", Price=56000 },
                new Product {Title="Mi5S", Company="Xiaomi", Price=35000 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
