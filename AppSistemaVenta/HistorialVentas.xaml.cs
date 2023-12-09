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
using static AppSistemaVenta.HistorialVentas;

namespace AppSistemaVenta
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistorialVentas : ContentPage
	{
		public HistorialVentas ()
		{
			InitializeComponent ();
		}
        public class DetalleVentas
        {
            public int idProducto { get; set; }
            public string marcaProducto { get; set; }
            public string descripcionProducto { get; set; }
            public string categoriaProducto { get; set; }
            public int cantidad { get; set; }
            public string precio { get; set; }
            public string total { get; set; }
        }

        public class Ventas
        {
            public int idVenta { get; set; }
            public string numeroVenta { get; set; }
            public int idTipoDocumentoVenta { get; set; }
            public string tipoDocumentoVenta { get; set; }
            public int idUsuario { get; set; }
            public string usuario { get; set; }
            public string documentoCliente { get; set; }
            public string nombreCliente { get; set; }
            public string subTotal { get; set; }
            public string impuestoTotal { get; set; }
            public string total { get; set; }
            public string fechaRegistro { get; set; }
            public List<DetalleVentas> detalleVenta { get; set; }
        }
        public class VentaDetalleViewModel
        {
            public string NumeroVenta { get; set; }
            public string Usuario { get; set; }
            public string FechaRegistro { get; set; }
            public string MarcaProducto { get; set; }
            public string Cantidad { get; set; }
            public string Total { get; set; } 
            
            
        }

        public async Task CargarHistorial()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://rcairo09.bsite.net/api/HistorialApi/ventas?fechaInicio=01/01/1900&fechaFin=31/12/3000&numeroVenta=000004");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var ventas = JsonConvert.DeserializeObject<List<Ventas>>(content);

                var ventaDetalleViewModels = ventas
                    .SelectMany(venta => venta.detalleVenta, (venta, detalle) => new VentaDetalleViewModel
                    {
                        NumeroVenta = venta.numeroVenta,
                        Usuario = venta.usuario,
                        FechaRegistro = venta.fechaRegistro.ToString(),
                        MarcaProducto = detalle.marcaProducto,
                        Cantidad = detalle.cantidad.ToString(),
                        Total = detalle.total.ToString(),
                    })
                    .Reverse()
                    .ToList();

                ListVenta.ItemsSource = ventaDetalleViewModels;
            }
        }
    }
}