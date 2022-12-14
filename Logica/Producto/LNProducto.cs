using AutoMapper;
using EntidadesDominio.Producto;
using Interfaces.Producto;
using InterfacesManager.Producto;
using Models;
using System.Collections.Generic;

namespace Logica.Producto
{
    public class LNProducto
    {
        private static IProducto Prod = IMProducto.Producto();
     
        public IList<EDProducto> GetProductos(DataContext db)
        {
            return Prod.GetProductos(db);
        }
        public EDProducto GetProducto(int id, DataContext db)
        {
            return Prod.GetProducto(id, db);
        }

        public int GuardarProducto(EDProducto producto, DataContext db, IMapper _mapper)
        {
            return Prod.GuardarProducto(producto, db, _mapper);
        }
        public int BorrarProducto(int id, DataContext db)
        {
            return Prod.BorrarProducto(id, db);
        }
        public int ModificarProducto(int id, EDProducto producto, DataContext db)
        {
            return Prod.ModificarProducto(id, producto, db);
        }

    }
}
