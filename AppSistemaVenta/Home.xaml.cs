using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace AppSistemaVenta
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent ();
		}
        public class IdCategoriaNavigation
        {
            public int idCategoria { get; set; }
            public string descripcion { get; set; }
            public bool esActivo { get; set; }
            public DateTime fechaRegistro { get; set; }
        }

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
            public IdCategoriaNavigation idCategoriaNavigation { get; set; }
        }

        public async Task CargarListaProductos()
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

                ListDemo.ItemsSource = resultado;
            }
        }
    }
}