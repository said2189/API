using AutoMapper;
using EntidadesDominio.Producto;
using Logica.Producto;
using Microsoft.EntityFrameworkCore;
using Models;
using NUnit.Framework;
using System;

namespace TestProject1
{
    public class Tests
    {
        LNProducto lnProd = new LNProducto();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GuardarProducto()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "Prueba").Options;

            using (var context = new DataContext(options))
            {
                //auto mapper configuration
                var mockMapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProducto());
                });

                var mapper = mockMapper.CreateMapper();

                EDProducto EDProducto = new EDProducto();
                EDProducto.strDescripcion = "Producto test";
                EDProducto.strCodigoProveedor = "000";
                EDProducto.strDescripcionProveedor = "Proveedor test";
                EDProducto.strTelefonoProveedor = "0000";
                EDProducto.dtFechaFabricacion = DateTime.Now;
                EDProducto.dtFechaValidez = DateTime.Now.AddDays(1);
                EDProducto.intEstado = 1; // 1- Inactivo 0- Activo
                var result = lnProd.GuardarProducto(EDProducto, context, mapper);
                Assert.IsNotNull(result, "Ok");
                //fin
            }

        }


    }
}