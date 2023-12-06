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

namespace AppSistemaVenta
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);

        public class Productos
        {
            public int idProducto { get; set; }
            public string codigoBarra { get; set; }
            public string marca { get; set; }
            public string descripcion { get; set; }
            public int idCategoria { get; set; }
            public int stock { get; set; }
            public string urlImagen { get; set; }
            public string nombreImagen { get; set; }
            public double precio { get; set; }
            public bool esActivo { get; set; }
            public DateTime fechaRegistro { get; set; }
            //public IdCategoriaNavigation idCategoriaNavigation { get; set; }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://cairotest.bsite.net/api/ProductosApi/Lista");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Productos>>(content);

                ListDemo.ItemsSource=resultado;

            }
        }
    }
}
