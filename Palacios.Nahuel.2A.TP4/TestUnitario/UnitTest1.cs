using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestListaPaquetesCorreo()
        {
            Correo c = new Correo();

            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void TestMismosTrackingId()
        {
            Paquete p1 = new Paquete("A", "111-111-1111");
            Paquete p2 = new Paquete("B", "111-111-1111");
            Correo c = new Correo();

            try
            {
                c += p1;
                c += p2;
                Assert.Fail("Excepcion al agregar un paquete con la misma tracking ID");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }

        }
    }
}
