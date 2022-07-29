using Interfaces.Producto;
using Repositorio.Producto;

namespace InterfacesManager.Producto
{
    public class IMProducto
    {
        public static IProducto Producto()
        {
            return new ProductoManager();
        }
    }
}
