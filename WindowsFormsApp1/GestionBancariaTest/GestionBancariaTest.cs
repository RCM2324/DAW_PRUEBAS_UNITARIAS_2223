﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionBancariaAppNS;

namespace GestionBancariaTest    //?RCM2324
{

    [TestClass]
    public class GestionBancariaTest
    {
        [TestMethod]
        [DataRow(1000, 250, 750)]
        [DataRow(1000, 1000, 0)]
        [DataRow(2000, 500, 1500)]
        [DataRow(100, 20, 80)]
        [DataRow(5, 2.5, 2.5)]
        //Modifico el codigo para parametrizar la prueba //RCM2324
        public void validarReintegro1(double saldoInicial, double reintegro, double saldoEsperado)
        {
            //Prueba 1 de validarReintegro (cantidad <= saldo)  //RCM2324
            //double saldoInicial = 1000;
            //double reintegro = 250;
            //double saldoEsperado = 750;

            GestionBancariaApp miApp = new
            GestionBancariaApp(saldoInicial);

            //Metodo a probar  //RCM2324
            miApp.RealizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el reintegro, saldo " + "incorrecto.");

        }

        [TestMethod]
        [DataRow(1000, -250, 1250)]
        [DataRow(1000, -1000, 0)]
        [DataRow(2000, -500, 1500)]
        [DataRow(100, -20, 80)]
        [DataRow(5, -2.5, 2.5)]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarReintegroCantidadNoValida( double saldoInicial, double reintegro, double saldoEsperado)
        {
            //Prueba 1 de validarReintegroCantidadNoValida (cantidad < 0)  //RCM2324
            //double saldoInicial = 1000;
            //double reintegro = -250;
            //double saldoEsperado = saldoInicial - reintegro;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarReintegro (reintegro);//?RCM2324
            }
            catch (ArgumentOutOfRangeException exception)
            { 
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);

                return;
            }
            Assert.Fail("Error. Se debia haber producido una excepción.");


            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
               "Se produjo un error al realizar el reintegro, saldo " + "incorrecto.");
        }
       
        [TestMethod]
        [DataRow(250, 1000, -750)]
        [DataRow(1000, 1500, -500)]
        [DataRow(0, 500, -500)]
        [DataRow(100, 200, -100)]
        [DataRow(2.5, 5, -2.5)]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarReintegroSaldoInsuficiente(double saldoInicial, double reintegro, double saldoEsperado)
        {
            //Prueba 2 de validarReintegroSaldoInsuficiente (cantidad > saldo)  //RCM2324
            //double saldoInicial = 250;
            //double reintegro = 1000;
            //double saldoEsperado = saldoInicial - reintegro;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarReintegro(reintegro);//?RCM2324
            }
            catch(ArgumentOutOfRangeException exception)
            {
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_SALDO_INSUFICIENTE);

                return;
            }
            Assert.Fail("Error. Se debia haber producido una excepción.");

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
               "Se produjo un error al realizar el reintegro, saldo " + "incorrecto.");
        }

       
        [TestMethod]
        [DataRow(1000, 250, 1250)]
        [DataRow(1000, 1000, 2000)]
        [DataRow(2000, 500, 2500)]
        [DataRow(100, 20, 120)]
        [DataRow(5, 2.5, 7.5)]
        public void validarIngreso1(double saldoInicial,double ingreso, double saldoEsperado)
        {
            //Prueba 1 validarIngreso (Cantidad > 0)   //RCM2324
            //double saldoInicial = 0;
            //double ingreso = 55;
            //double saldoEsperado = 55;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            //Metodo a probar   //RCM2324
            miApp.RealizarIngreso(ingreso);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el ingreso, saldo " + "incorrecto");

        }


        [TestMethod]
        [DataRow(1000, 0, 1000)]
        [DataRow(1000, 0, 1000)]
        [DataRow(2000, 0, 2000)]
        [DataRow(100, 0, 100)]
        [DataRow(5, 0, 5)]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarIngresoCantidadNoValida1(double saldoInicial, double ingreso, double saldoEsperado)
        {
            //Prueba 1 validarIngresoCantidadNoValida1 (Cantidad = 0)   //RCM2324
            //double saldoInicial = 1000;
            //double ingreso = 0;
            //double saldoEsperado = saldoInicial + ingreso;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarIngreso(ingreso);//RCM2324
            }
            catch (ArgumentOutOfRangeException exception)
            {
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);

                return;
            }
            Assert.Fail("Error. Se debia haber producido una excepción.");

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
               "Se produjo un error al realizar el ingreso, saldo " + "incorrecto.");
        }


        [TestMethod]
        [DataRow(1000, -250, 1250)]
        [DataRow(1000, -1000, 0)]
        [DataRow(2000, -500, 1500)]
        [DataRow(100, -20, 80)]
        [DataRow(5, -2.5, 2.5)]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarIngresoCantidadNoValida2(double saldoInicial, double ingreso, double saldoEsperado)
        {
            //Prueba 2 validarIngresoCantidadNoValida2 (Cantidad < 0)   //RCM2324
            //double saldoInicial = 1000;
            //double ingreso = -250;
            //double saldoEsperado = saldoInicial + ingreso;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarIngreso(ingreso);//RCM2324
            }  
            catch(ArgumentOutOfRangeException exception)
            {
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);

                return;
            }
            Assert.Fail("Error. Se debia haber producido una excepción.");

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
               "Se produjo un error al realizar el ingreso, saldo " + "incorrecto.");



        }
    }

}






