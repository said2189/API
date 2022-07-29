using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Producto
{
    [Table("Tbl_Productos")]
    public class Productos
    {
        [Key]
        public int Pk_Producto { get; set; }
        [MaxLength(200)]
        [Required]
        public string strDescripcion { get; set; }
        public int intEstado { get; set; } // 1- Inactivo 0- Activo
        [DataType(DataType.Date)]
        public DateTime dtFechaFabricacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime dtFechaValidez { get; set; }
        [MaxLength(10)]
        public string strCodigoProveedor { get; set; }
        [MaxLength(100)]
        public string strDescripcionProveedor { get; set; }
        [MaxLength(50)]

        public string strTelefonoProveedor { get; set; }
    }
}
