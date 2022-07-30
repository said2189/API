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
            GuardarProducto();
        }

        [Test]
        public void GuardarProducto()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "PruebaTest").Options;
            using (var context = new DataContext(options))
            {
                context.Database.EnsureCreated();

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
                EDProducto.intEstado = 0; // 1- Inactivo 0- Activo
                var result = lnProd.GuardarProducto(EDProducto, context, mapper);
                Assert.IsNotNull(result, "Ok");
                //fin
            }

        }

        [Test]
        public void GetProductos()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "PruebaTest").Options;
            using (var context = new DataContext(options))
            {
                var result = lnProd.GetProductos(context);
                Assert.IsNotNull(result, "Ok");
            }
        }


        [Test]
        public void GetProducto()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "PruebaTest").Options;
            using (var context = new DataContext(options))
            {
                var result = lnProd.GetProducto(1, context);
                Assert.IsNotNull(result, "Ok");
            }
        }

        [Test]
        public void ModificarProducto()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "PruebaTest").Options;
            using (var context = new DataContext(options))
            {
                EDProducto EDProducto = new EDProducto();
                EDProducto.strDescripcion = "Update Producto test";
                EDProducto.strCodigoProveedor = "111";
                EDProducto.strDescripcionProveedor = "Update Proveedor test";
                EDProducto.strTelefonoProveedor = "111";
                EDProducto.dtFechaFabricacion = DateTime.Now;
                EDProducto.dtFechaValidez = DateTime.Now.AddDays(3);
                EDProducto.intEstado = 0; // 1- Inactivo 0- Activo

                var result = lnProd.ModificarProducto(1, EDProducto, context);
                Assert.IsNotNull(result, "Ok");
            }
        }


    }
}