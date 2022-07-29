using System;
using System.ComponentModel.DataAnnotations;

namespace EntidadesDominio.Producto
{
    public class EDProducto
    {
        public int Pk_Producto { get; set; }
        [Required]
        public string strDescripcion { get; set; }
        public int intEstado { get; set; } // 1- Inactivo 0- Activo
        public DateTime dtFechaFabricacion { get; set; }
        public DateTime dtFechaValidez { get; set; }
        public string strCodigoProveedor { get; set; }
        public string strDescripcionProveedor { get; set; }
        public string strTelefonoProveedor { get; set; }
    }
}
