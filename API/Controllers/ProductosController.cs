using AutoMapper;
using EntidadesDominio.Producto;
using Logica.Producto;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DataContext db;
        private readonly IMapper _mapper;
        LNProducto lnProd = new LNProducto();

        public ProductosController(DataContext db, IMapper _mapeper)
        {
            this.db = db;
            _mapper = _mapeper;
        }

        [HttpGet]
        public IActionResult GetProductos(string buscar, int pagina = 1, int registros_por_pagina = 10)
        {
            try
            {
                PaginadorGenerico<EDProducto> _Paginador;

                var result = lnProd.GetProductos(db);

                // Filtramos el resultado por el 'texto de búqueda'
                if (!string.IsNullOrEmpty(buscar))
                {
                    foreach (var item in buscar.Split(new char[] { ' ' },
                             StringSplitOptions.RemoveEmptyEntries))
                    {
                        result = result.Where(x => x.strDescripcion.Contains(item) ||
                                                      x.strDescripcionProveedor.Contains(item) ||
                                                      x.strTelefonoProveedor.Contains(item) ||
                                                      x.strCodigoProveedor.Contains(item))
                                                      .ToList();
                    }
                }


                int _TotalRegistros = 0;
                int _TotalPaginas = 0;

                // Número total de registros de la tabla Customers
                _TotalRegistros = result.Count();

                // Obtenemos la 'página de registros' de la tabla producto
                result = result.Skip((pagina - 1) * registros_por_pagina)
                                                 .Take(registros_por_pagina)
                                                 .ToList();

                // Número total de páginas de la tabla producto
                _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);

                // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
                _Paginador = new PaginadorGenerico<EDProducto>()
                {
                    RegistrosPorPagina = registros_por_pagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    BusquedaActual = buscar,
                    Resultado = result
                };

                return Ok(_Paginador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetProducto")]
        public IActionResult GetProducto(int id)
        {
            try
            {
                var resul = lnProd.GetProducto(id, db);

                if (resul == null)
                {
                    return BadRequest("Error! Producto no encontrado");
                }
                else
                {
                    return Ok(resul);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult GuardarProducto(EDProducto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (producto.dtFechaFabricacion >= producto.dtFechaValidez)
                    {
                        return BadRequest("Error! Fecha de fabricacion no puede ser mayor o igual a la fecha de validez");
                    }
                    else
                    {
                        var resul = lnProd.GuardarProducto(producto, db, _mapper);
                        return CreatedAtRoute("GetProducto", new { id = resul }, producto);
                    }
                }
                else
                {
                    return BadRequest("Error en la petición");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult ModificarProducto(int id, [FromBody] EDProducto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (producto.dtFechaFabricacion >= producto.dtFechaValidez)
                    {
                        return BadRequest("Error! Fecha de fabricacion no puede ser mayor o igual a la fecha de validez");
                    }
                    else
                    {
                        var resul = lnProd.ModificarProducto(id, producto, db);

                        if (resul == 0)
                        {
                            return CreatedAtRoute("GetProducto", new { id = producto.Pk_Producto }, producto);
                        }
                        else
                        {
                            return BadRequest("Error en la peticion");
                        }
                    }
                }
                else
                {
                    return BadRequest("Error en la peticion");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarProducto(int id)
        {
            try
            {
                var resul = lnProd.BorrarProducto(id, db);

                if (resul > 0)
                {
                    return BadRequest("Error! producto no encontrado");
                }
                else
                {
                    return Ok("Producto Inactivo");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }














    }
}
