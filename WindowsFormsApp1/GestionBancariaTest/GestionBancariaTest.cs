using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionBancariaAppNS;

namespace GestionBancariaTest    //?RCM2324
{

    [TestClass]
    public class GestionBancariaTest
    {
        [TestMethod]
        public void validarReintegro1()
        {
            //Prueba 1 de validarReintegro (cantidad <= saldo)  //RCM2324
            double saldoInicial = 1000;
            double reintegro = 250;
            double saldoEsperado = 750;

            GestionBancariaApp miApp = new
            GestionBancariaApp(saldoInicial);

            //Metodo a probar  //?RCM2324
            miApp.RealizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el reintegro, saldo " + "incorrecto.");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarReintegroCantidadNoValida()
        {
            //Prueba 1 de validarReintegroCantidadNoValida (cantidad < 0)  //RCM2324
            double saldoInicial = 1000;
            double reintegro = -250;
            double saldoEsperado = saldoInicial - reintegro;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            //Metodo a probar  //?RCM2324
            miApp.RealizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el reintegro, saldo " + "incorrecto.");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarReintegroSaldoInsuficiente()
        {
            //Prueba 2 de validarReintegroSaldoInsuficiente (cantidad > saldo)  //RCM2324
            double saldoInicial = 250;
            double reintegro = 1000;
            double saldoEsperado = saldoInicial - reintegro;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            //Metodo a probar  //?RCM2324
            miApp.RealizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el reintegro, saldo " + "incorrecto.");

        }

       
        [TestMethod]
        public void validarIngreso1()
        {
            //Prueba 1 validarIngreso (Cantidad > 0)   //RCM2324
            double saldoInicial = 0;
            double ingreso = 55;
            double SaldoEsperado = 55;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            //Metodo a probar   //RCM2324
            miApp.RealizarIngreso(ingreso);

            Assert.AreEqual(SaldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el ingreso, saldo " + "incorrecto");

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarIngresoCantidadNoValida1()
        {
            //Prueba 1 validarIngresoCantidadNoValida1 (Cantidad = 0)   //RCM2324
            double saldoInicial = 1000;
            double ingreso = 0;
            double SaldoEsperado = saldoInicial + ingreso;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            //Metodo a probar   //RCM2324
            miApp.RealizarIngreso(ingreso);

            Assert.AreEqual(SaldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el ingreso, saldo " + "incorrecto");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarIngresoCantidadNoValida2()
        {
            //Prueba 2 validarIngresoCantidadNoValida2 (Cantidad < 0)   //RCM2324
            double saldoInicial = 1000;
            double ingreso = -250;
            double SaldoEsperado = saldoInicial + ingreso;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            //Metodo a probar   //RCM2324
            miApp.RealizarIngreso(ingreso);

            Assert.AreEqual(SaldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el ingreso, saldo " + "incorrecto");
        }
    }

}






