using AutoMapper;
using Models.Producto;

namespace EntidadesDominio.Producto
{
    public class MappingProducto : Profile
    {
        public MappingProducto()
        {
            CreateMap<EDProducto, Productos>();
        }
    }
}
