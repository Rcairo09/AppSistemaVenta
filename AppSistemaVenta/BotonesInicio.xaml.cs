using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSistemaVenta
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BotonesInicio : ContentPage
	{
		public BotonesInicio ()
		{
			InitializeComponent ();
		}


        private async void Productos_Clicked(object sender, EventArgs e)
        {
            Home homePage = new Home();
            await homePage.CargarListaProductos();
            await Navigation.PushAsync(homePage);
        }

        private async void HistorialVentas_Clicked(object sender, EventArgs e)
        {
            HistorialVentas historial = new HistorialVentas();
            await historial.CargarHistorial();
            await Navigation.PushAsync(historial);
        }
    }
}