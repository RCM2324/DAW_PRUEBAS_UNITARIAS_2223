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
        public void validarReintegro2()
        {
            //Prueba 2 de validarReintegro (cantidad > saldo)  //RCM2324
            double saldoInicial = 100;
            double reintegro = 250;
            double saldoEsperado = -150;

            GestionBancariaApp miApp = new
            GestionBancariaApp(saldoInicial);

            //Metodo a probar  //?RCM2324
            miApp.RealizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el reintegro, saldo " + "incorrecto.");

        }

        [TestMethod]
        public void validarReintegro3()
        {
            //Prueba 3 de validarReintegro (cantidad < 0)  //RCM2324
            double saldoInicial = 0;
            double reintegro = -60;
            double saldoEsperado = -60;

            GestionBancariaApp miApp = new
            GestionBancariaApp(saldoInicial);

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

            GestionBancariaApp miApp = new
            GestionBancariaApp(saldoInicial);

            //Metodo a probar   //RCM2324
            miApp.RealizarIngreso(ingreso);

            Assert.AreEqual(SaldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el ingreso, saldo " + "incorrecto");

        }


        [TestMethod]
        public void validarIngreso2()
        {
            //Prueba 2 validarIngreso (Cantidad = 0)   //RCM2324
            double saldoInicial = 55;
            double ingreso = 0;
            double SaldoEsperado = 55;

            GestionBancariaApp miApp = new
            GestionBancariaApp(saldoInicial);

            //Metodo a probar   //RCM2324
            miApp.RealizarIngreso(ingreso);

            Assert.AreEqual(SaldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el ingreso, saldo " + "incorrecto");
        }


        [TestMethod]
        public void validarIngreso3()
        {
            //Prueba 3 validarIngreso (Cantidad < 0)   //RCM2324
            double saldoInicial = 0;
            double ingreso = -40;
            double SaldoEsperado = -40;

            GestionBancariaApp miApp = new
            GestionBancariaApp(saldoInicial);

            //Metodo a probar   //RCM2324
            miApp.RealizarIngreso(ingreso);

            Assert.AreEqual(SaldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el ingreso, saldo " + "incorrecto");
        }
    }

}






