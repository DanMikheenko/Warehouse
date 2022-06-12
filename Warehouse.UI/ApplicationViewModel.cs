using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Warehouse.UI.Base;

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
            
            var productRepository = new ProductRepository();
            Products = productRepository.GetAll();
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Product product = new Product();
                      Products.Insert(0, product);
                      SelectedProduct = product;
                      var productRepository = new ProductRepository();
                      productRepository.Add(product);
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
