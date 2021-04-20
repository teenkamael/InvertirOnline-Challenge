using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.Data.Classes.Enum;
using System.Threading;
using System.Globalization;

namespace CodingChallenge.Data.Classes
{
    public class ShapeCollection
    {
        #region Private Variables
        private ShapeType _type;
        private List<Shape> _shapes;
        #endregion

        public ShapeType Tipo { get { return _type; } }

        public List<Shape> Formas { get { return _shapes; } }

        public ShapeCollection(ShapeType Tipo, List<Shape> Formas)
        {
            try
            {
                _type = Tipo;
                foreach (Shape forma in Formas)
                {
                    if (forma.Tipo.getEnumId() != _type.getEnumId())
                        throw new Exception(Resources.Resources.ShapeCollectionErrorType);
                }

                _shapes = Formas;
            }
            catch (Exception ex)
            {

                throw new Exception(Resources.Resources.ShapeCollectionError + " " + ex.Message);
            }
        }

        #region Public Methods
        public void InsertarFormaEnColeccion(Shape Forma)
        {
            _shapes.Add(Forma);
        }
        //Método ObtenerLineaDeTotal
        public string ObtenerLineaDeColeccion()
        {
            if (Formas.Count > 0)
            {
                return (Formas.Count.ToString() + " " + obtenerNombreDeFormaEspecifico() + " | " + Resources.Resources.Area + " " 
                    + ObtenerAreaDeColeccion().ToString("#.##").Replace('.', ',') + " | " + Resources.Resources.Perimeter.ToString() + " " + ObtenerPerimetroDeColeccion().ToString("#.##").Replace('.', ',') + " <br/>");
            }

            return string.Empty;
        }

        public decimal ObtenerAreaDeColeccion()
        {
            decimal area = 0m;
            foreach (Shape forma in Formas)
                area += forma.CalcularArea();
            

            return area;
        }

        public decimal ObtenerPerimetroDeColeccion()
        {
            decimal perimetro = 0m;
            foreach (Shape forma in Formas)
                perimetro += forma.CalcularPerimetro();

            return perimetro;
        }

        #endregion

        #region Private Methods
        //Metodo ObtenerNombreEspecifico
        private string obtenerNombreDeFormaEspecifico()
        {
            string pluralString = "";
            switch(Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "en-US":
                    pluralString = "s";
                    break;
                case "es-ES":
                    pluralString = "s";
                    break;
            }
            return Tipo.toString() + (Formas.Count > 1 ? pluralString : "");
        }

        #endregion
    }
}
