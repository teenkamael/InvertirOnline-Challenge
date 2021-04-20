/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using CodingChallenge.Data.Classes.Enum;

namespace CodingChallenge.Data.Classes
{
    public static class ShapeCollectionManager
    {

        public static string Imprimir(List<Shape> formas)
        {

            var sb = new StringBuilder();
            if (!formas.Any())
            {
                sb.Append(Resources.Resources.EmptyShapesList);
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                // default es inglés
                sb.Append(Resources.Resources.ShapesReport);

                List<ShapeCollection> coleccionesDeFormasPorTipo = new List<ShapeCollection>();

                foreach (Shape forma in formas)
                {

                    if (coleccionesDeFormasPorTipo.Exists(x => x.Tipo.getEnumId() == forma.Tipo.getEnumId()))
                    {
                        coleccionesDeFormasPorTipo.Single(x => x.Tipo.getEnumId() == forma.Tipo.getEnumId()).InsertarFormaEnColeccion(forma);
                        continue;
                    }
                    List<Shape> listShapes = new List<Shape>();
                    listShapes.Add(forma);
                    coleccionesDeFormasPorTipo.Add(new ShapeCollection(ShapeType.GetShapeTypeByEnumId(forma.Tipo.getEnumId()), listShapes));
                }

                var cantidadTotal = 0;
                decimal perimetroTotal = 0m;
                decimal areaTotal = 0m;
                foreach (ShapeCollection coleccion in coleccionesDeFormasPorTipo)
                {
                    sb.Append(coleccion.ObtenerLineaDeColeccion());
                    cantidadTotal += coleccion.Formas.Count;
                    perimetroTotal += coleccion.ObtenerPerimetroDeColeccion();
                    areaTotal += coleccion.ObtenerAreaDeColeccion();
                }

                // FOOTER
                sb.Append(Resources.Resources.Total);

                sb.Append(cantidadTotal + " " + Resources.Resources.Shapes + " ");
                sb.Append(Resources.Resources.Perimeter + " " + perimetroTotal.ToString("#.##").Replace('.', ',') + " ");
                sb.Append(Resources.Resources.Area + " " + areaTotal.ToString("#.##").Replace('.', ','));
            }

            return sb.ToString();
        }

        public static void CambiarIdioma(Language idioma)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(idioma.toString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(idioma.toString());
        }

    }
}
