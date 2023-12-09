using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using AppSistemaVenta.Modelos;

namespace AppSistemaVenta
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Login log = new Login
            {
                Correo = txtEmail.Text,
                Clave = txtPin.Text
            };

            Uri RequestUri = new Uri("https://rcairo09.bsite.net/api/LoginApi/login");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json,Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);
            if (response.StatusCode==HttpStatusCode.OK) 
            {
                await Navigation.PushAsync(new BotonesInicio());
            }
            else
            {
                await DisplayAlert("Mensaje", "Datos no válidos", "Ok");
            }
        }
        

        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);          

    }
}
