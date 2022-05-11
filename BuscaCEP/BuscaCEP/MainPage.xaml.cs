using System;
using Xamarin.Forms;
using Correios.NET;

namespace BuscaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void btnBuscaCep_Clicked(object sender, EventArgs e)
        {
            var cep = entCep.Text;
            GetCep(cep);
        }

        public async void GetCep(string cep)
        {
            try
            {
                var endereco = await new CorreiosService().GetAddressesAsync(cep);
                foreach (var item in endereco)
                {
                    lblBairro.Text = item.Street;
                    lblCidade.Text = item.City;
                    lblUf.Text = item.State;
                    lblDistrito.Text = item.District;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"ERRO: {ex.Message}", "OK");
            }
        }
    }
}
