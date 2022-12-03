using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoUnipar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Anotacoes : ContentPage
    {
        public List<string> ListaAnotacoes { get; set; }
        public string Materia { get; set; }
        public DateTime Data { get; set; }
        public string Anotacao { get; set; }

        public Anotacoes()
        {
            InitializeComponent();

            PickerMaterias.Focused += delegate
            {
                ListaMaterias();
            };



        }

        public void ListaMaterias()
        {
            var item = new List<string>();

            item.Add("Banco de dados");
            item.Add("Engenharia de Software");
            item.Add("Algoritimo");
            item.Add("Redes de computadores");
            item.Add("Sistemas Operacionais");
            item.Add("IHC");
            item.Add("Dispositivos Móveis");

            PickerMaterias.ItemsSource = item;

        }

        public bool validardados()
        {
            if (PickerMaterias.SelectedItem == null)
            {
                DisplayAlert("Unipar", "Selecione uma matéria", "OK");

                return false;
            }
            if (dataAnotacao.Date < DateTime.Now.AddDays(-1))
            {
                DisplayAlert("Unipar", "Anotações retroativas não nos levam a lugar nenhum! ", "Ok");
                return false;

            }
            if (campoAnotacao.Text == null)
            {
                DisplayAlert("Unipar", "Vamos lá, escreva algo!", "OK");
                return false;
            }

            return true;
        }




        public void PreencherValores()
        {
            Materia = PickerMaterias.SelectedItem.ToString();
            Data = dataAnotacao.Date;
            Anotacao = campoAnotacao.Text;


        }

        public void LimparCampos()
        {
            PickerMaterias.SelectedItem = null;
            dataAnotacao.Date = DateTime.Now;
            campoAnotacao.Text = "";

        }

        public void AtribuirValores()
        {
            StackLayout stackLayout = new StackLayout();
            Label labelmateria = new Label();
            Label labeldata = new Label();
            Label labelanotacao = new Label();

            AnotacoesSalvas.Children.Add(stackLayout);
            stackLayout.Children.Add(labelmateria);
            stackLayout.Children.Add(labeldata);
            stackLayout.Children.Add(labelanotacao);


            frameAnot.BorderColor = Color.Red;
            frameAnot.CornerRadius = 20;
            stackLayout.BackgroundColor = Color.White;
            stackLayout.Margin = 5;

            labelmateria.Text = $"Matéria: {Materia}";
            labelmateria.TextColor = Color.Red;
            labelmateria.FontSize = 20;

            labeldata.Text = $" Data: {Data.ToString("dd/MM/yyyy")}";
            labeldata.TextColor = Color.Red;
            labeldata.FontSize = 20;

            labelanotacao.Text = $"Anotação: {Anotacao}";
            labelanotacao.TextColor = Color.Red;
            labelanotacao.FontSize = 20;



            if (btBold.BackgroundColor == Color.Firebrick)
            {
                labelmateria.FontAttributes = FontAttributes.Bold;
                labeldata.FontAttributes = FontAttributes.Bold;
                labelanotacao.FontAttributes = FontAttributes.Bold;

            }
            else if (btItalic.BackgroundColor == Color.Firebrick)
            {

                labelmateria.FontAttributes = FontAttributes.Italic;
                labeldata.FontAttributes = FontAttributes.Italic;
                labelanotacao.FontAttributes = FontAttributes.Italic;

            }
            else
            {
                labelmateria.FontAttributes = FontAttributes.None;
                labeldata.FontAttributes = FontAttributes.None;
                labelanotacao.FontAttributes = FontAttributes.None;
            }

        }


        private async void AddLista_Clicked(object sender, EventArgs e)
        {
            if (!validardados()) return;
            PreencherValores();
            AtribuirValores();
            LimparCampos();

        }

        private void btBold_Clicked(object sender, EventArgs e)
        {
            if (btBold.BackgroundColor == Color.Transparent)
            {
                btBold.BackgroundColor = Color.Firebrick;
                btItalic.BackgroundColor = Color.Transparent;
            }
            else
            {
                btBold.BackgroundColor = Color.Transparent;
            }
        }

        private void btItalic_Clicked(object sender, EventArgs e)
        {
            if (btItalic.BackgroundColor == Color.Transparent)
            {
                btItalic.BackgroundColor = Color.Firebrick;
                btBold.BackgroundColor = Color.Transparent;

            }
            else
            {
                btItalic.BackgroundColor = Color.Transparent;
            }

        }
    }
}