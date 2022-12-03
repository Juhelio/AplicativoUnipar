using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoUnipar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        public Detail()
        {
            InitializeComponent();
            CardImagens();
        }


        public void CardImagens()
        {

            List<CardImagens> imagens = new List<CardImagens>()
            {
            new CardImagens() {Title = "Imagem 1", Imagem = "UniparCarousel1.png"},
            new CardImagens() {Title = "Imagem 2", Imagem = "UniparCarousel2.png" },
            new CardImagens() {Title = "Imagem 3", Imagem = "UniparCarousel3.png" }

            };

            Imagens.ItemsSource = imagens;

            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {
                Imagens.Position = (Imagens.Position + 1) % imagens.Count;
                return true;
            }));
        }





        private void btAnot_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new Anotacoes());


        }

        private void Sobre_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Sobre());
        }

        private void btLink_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LinkOficial());
            this.BindingContext = new LinkOficial();

        }
    }
}