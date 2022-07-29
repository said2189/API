using Logica.Producto;
using Models;
using NUnit.Framework;

namespace LogicaTest
{
    public class Tests
    {
        LNProducto lnProd = new LNProducto();
        private readonly DataContext db;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetProductos()
        {
            var result = lnProd.GetProductos(db);

            //Assert.IsNotNull()
        }
    }
}