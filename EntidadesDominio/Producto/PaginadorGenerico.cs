using System.Collections.Generic;

namespace EntidadesDominio.Producto
{
    public class PaginadorGenerico<T> where T : class
    {
        /// <summary>
        /// Página devuelta por la consulta actual.
        /// </summary>
        public int PaginaActual { get; set; }
        /// <summary>
        /// Número de registros de la página devuelta.
        /// </summary>
        public int RegistrosPorPagina { get; set; }
        /// <summary>
        /// Total de registros de consulta.
        /// </summary>
        public int TotalRegistros { get; set; }
        /// <summary>
        /// Total de páginas de la consulta.
        /// </summary>
        public int TotalPaginas { get; set; }
        /// <summary>
        /// Texto de búsqueda de la consuta actual.
        /// </summary>
        public string BusquedaActual { get; set; }
        /// Resultado devuelto por la consulta a la tabla
        /// en función de todos los parámetros anteriores.
        /// </summary>
        public IEnumerable<T> Resultado { get; set; }
    }
}
