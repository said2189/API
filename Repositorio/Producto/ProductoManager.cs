using AutoMapper;
using EntidadesDominio.Producto;
using Interfaces.Producto;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Producto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Producto
{
    public class ProductoManager : IProducto
    {
        public IList<EDProducto> GetProductos(DataContext db)
        {
            try
            {
                var result = (from x in db.Tbl_Productos
                              where x.intEstado == 0
                              select new EDProducto
                              {
                                  Pk_Producto = x.Pk_Producto,
                                  strDescripcion = x.strDescripcion,
                                  strCodigoProveedor = x.strCodigoProveedor,
                                  strDescripcionProveedor = x.strDescripcionProveedor,
                                  strTelefonoProveedor = x.strTelefonoProveedor,
                                  dtFechaFabricacion = x.dtFechaFabricacion,
                                  dtFechaValidez = x.dtFechaValidez,
                                  intEstado = x.intEstado // 1- Inactivo 0- Activo
                              }).ToList();

                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public EDProducto GetProducto(int id, DataContext db)
        {
            try
            {
                var result = (from x in db.Tbl_Productos
                              where x.intEstado == 0 && x.Pk_Producto == id
                              select new EDProducto
                              {
                                  Pk_Producto = x.Pk_Producto,
                                  strDescripcion = x.strDescripcion,
                                  strCodigoProveedor = x.strCodigoProveedor,
                                  strDescripcionProveedor = x.strDescripcionProveedor,
                                  strTelefonoProveedor = x.strTelefonoProveedor,
                                  dtFechaFabricacion = x.dtFechaFabricacion,
                                  dtFechaValidez = x.dtFechaValidez,
                                  intEstado = x.intEstado // 1- Inactivo 0- Activo
                              }).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GuardarProducto(EDProducto producto, DataContext db, IMapper _mapper)
        {
            try
            {
                Productos eDProducto = _mapper.Map<Productos>(producto);

                db.Tbl_Productos.Add(eDProducto);
                db.SaveChanges();

                return eDProducto.Pk_Producto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int BorrarProducto(int id, DataContext db)
        {
            try
            {
                var producto = db.Tbl_Productos.Where(x => x.Pk_Producto == id).FirstOrDefault();

                if (producto != null)
                {
                    producto.intEstado = 1; // 1- Inactivo 0- Activo
                    db.Entry(producto).State = EntityState.Modified;
                    db.SaveChanges();
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception)
            {
                return 1;
            }
        }


        public int ModificarProducto(int id, EDProducto producto, DataContext db)
        {
            try
            {
                var product = db.Tbl_Productos.Where(x => x.Pk_Producto == id).FirstOrDefault();

                if (product.Pk_Producto == id)
                {
                    product.strDescripcion = producto.strDescripcion;
                    product.strCodigoProveedor = producto.strCodigoProveedor;
                    product.strDescripcionProveedor = producto.strDescripcionProveedor;
                    product.strTelefonoProveedor = producto.strTelefonoProveedor;
                    product.dtFechaFabricacion = producto.dtFechaFabricacion;
                    product.dtFechaValidez = producto.dtFechaValidez;
                    product.intEstado = producto.intEstado; // 1- Inactivo 0- Activo

                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception)
            {
                return 1;
            }
        }

    }
}
