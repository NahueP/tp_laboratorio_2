using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using ClasesAbstractas;
using ClasesInstanciables;
using System.Collections.Generic;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarNacionalidadInvalidaExcepcion()
        {
            try
            {
                Alumno a1 = new Alumno(2, "Torres", "Martin", "40456578", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
                Assert.Fail("Debe lanzar error de nacionalidad");

            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
        public void ValidarValorNumerico()
        {
            Profesor p1 = new Profesor(4, "Perez", "Victor", "31454123", Persona.ENacionalidad.Argentino);
            Assert.IsInstanceOfType(p1.DNI, typeof(int));
        }


        [TestMethod]
        public void ValidarAtributoColeccion()
        {
            Universidad u1 = new Universidad();
        

            List<Alumno> alumnos = u1.Alumnos;
           
            Assert.IsNotNull(alumnos);


            
            
        }

    }
}
