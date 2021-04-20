using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;
using CodingChallenge.Data.Classes.Enum;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ShapeCollectionManager.Imprimir(new List<Shape>()));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {

            ShapeCollectionManager.CambiarIdioma(Language.English);
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ShapeCollectionManager.Imprimir(new List<Shape>()));
        }

        public void TestResumenListaVaciaFormasEnPolaco()
        {

            ShapeCollectionManager.CambiarIdioma(Language.Polaco);
            Assert.AreEqual("<h1>Pusta lista kształtów!</h1>",
                ShapeCollectionManager.Imprimir(new List<Shape>()));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            ShapeCollectionManager.CambiarIdioma(Language.Castellano);
            var cuadrados = new List<Shape> {new Shape(ShapeType.Cuadrado, 5)};
            var resumen = ShapeCollectionManager.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            ShapeCollectionManager.CambiarIdioma(Language.English);
            var cuadrados = new List<Shape>
            {
                new Shape(ShapeType.Cuadrado, 5),
                new Shape(ShapeType.Cuadrado, 1),
                new Shape(ShapeType.Cuadrado, 3)
            };

            var resumen = ShapeCollectionManager.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            ShapeCollectionManager.CambiarIdioma(Language.English);
            var formas = new List<Shape>
            {
                new Shape(ShapeType.Cuadrado, 5),
                new Shape(ShapeType.Circulo, 3),
                new Shape(ShapeType.TrianguloEquilatero, 4),
                new Shape(ShapeType.Cuadrado, 2),
                new Shape(ShapeType.TrianguloEquilatero, 9),
                new Shape(ShapeType.Circulo, 2.75m),
                new Shape(ShapeType.TrianguloEquilatero, 4.2m)
            };

            var resumen = ShapeCollectionManager.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            ShapeCollectionManager.CambiarIdioma(Language.Castellano);
            var formas = new List<Shape>
            {
                new Shape(ShapeType.Cuadrado, 5),
                new Shape(ShapeType.Circulo, 3),
                new Shape(ShapeType.TrianguloEquilatero, 4),
                new Shape(ShapeType.Cuadrado, 2),
                new Shape(ShapeType.TrianguloEquilatero, 9),
                new Shape(ShapeType.Circulo, 2.75m),
                new Shape(ShapeType.TrianguloEquilatero, 4.2m)
            };

            var resumen = ShapeCollectionManager.Imprimir(formas);
            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
        //Mis casos de prueba
        //Con trapecio
        [TestCase]
        public void TestResumenListaConMasTiposYTrapecioEnCastellano()
        {
            ShapeCollectionManager.CambiarIdioma(Language.Castellano);
            var formas = new List<Shape>
            {
                new Shape(ShapeType.Cuadrado, 5),
                new Shape(ShapeType.Circulo, 3),
                new Shape(ShapeType.TrianguloEquilatero, 4),
                new Shape(ShapeType.Cuadrado, 2),
                new Shape(ShapeType.TrianguloEquilatero, 9),
                new Shape(ShapeType.Circulo, 2.75m),
                new Shape(ShapeType.TrianguloEquilatero, 4.2m),
                new Shape(ShapeType.TrapecioRectangulo, 5.7m, 4.3m, 7.5m),
                new Shape(ShapeType.TrapecioRectangulo, 4.2m, 2.4m, 3.2m)
            };

            var resumen = ShapeCollectionManager.Imprimir(formas);
            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>2 Trapecios | Area 48,06 | Perimetro 38,6 <br/>TOTAL:<br/>9 formas Perimetro 136,27 Area 139,71",
                resumen);
        }
        //En polaco
        [TestCase]
        public void TestResumenListaConMasTiposYTrapecioEnPolaco()
        {
            ShapeCollectionManager.CambiarIdioma(Language.Polaco);
            var formas = new List<Shape>
            {
                new Shape(ShapeType.Cuadrado, 5),
                new Shape(ShapeType.Circulo, 3),
                new Shape(ShapeType.TrianguloEquilatero, 4),
                new Shape(ShapeType.Cuadrado, 2),
                new Shape(ShapeType.TrianguloEquilatero, 9),
                new Shape(ShapeType.Circulo, 2.75m),
                new Shape(ShapeType.TrianguloEquilatero, 4.2m),
                new Shape(ShapeType.TrapecioRectangulo, 5.7m, 4.3m, 7.5m),
                new Shape(ShapeType.TrapecioRectangulo, 4.2m, 2.4m, 3.2m)
            };

            var resumen = ShapeCollectionManager.Imprimir(formas);
            Assert.AreEqual(
                "<h1>Raport kształtuje </h1>2 Kwadrat | Obszar 29 | perymetr 28 <br/>2 Okrąg | Obszar 13,01 | perymetr 18,06 <br/>3 Trójkąt | Obszar 49,64 | perymetr 51,6 <br/>2 Trapez | Obszar 48,06 | perymetr 38,6 <br/>łączny: <br/>9 kształtuje perymetr 136,27 Obszar 139,71",
                resumen);
        }
    }
}
