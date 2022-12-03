using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoUnipar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LinkOficial : ContentPage
    {
        public ICommand TapCommand => new Command<string>(AbrirNavegador);
        public LinkOficial()
        {
            InitializeComponent();
            BindingContext = this;
        }

        void AbrirNavegador(string url)
        {
            Device.OpenUri(new Uri(url));
        }

    }
}