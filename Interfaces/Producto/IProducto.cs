using AutoMapper;
using EntidadesDominio.Producto;
using Models;
using System.Collections.Generic;

namespace Interfaces.Producto
{
    public interface IProducto
    {
        IList<EDProducto> GetProductos(DataContext db);
        EDProducto GetProducto(int id, DataContext db);
        int GuardarProducto(EDProducto producto, DataContext db, IMapper _mapper);
        int BorrarProducto(int id, DataContext db);
        public int ModificarProducto(int id, EDProducto producto, DataContext db);
    }
}
