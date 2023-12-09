using System;
using System.Collections.Generic;
using System.Text;

namespace AppSistemaVenta.Modelos
{
    class Productos
    {
        public class IdCategoriaNavigation
        {
            public int idCategoria { get; set; }
            public string descripcion { get; set; }
            public bool esActivo { get; set; }
            public DateTime fechaRegistro { get; set; }
        }

        public class ProductosList
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
    }
}
