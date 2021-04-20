using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CodingChallenge.Data.Classes;
namespace CodingChallenge.Data.Classes.Enum
{
    public class ShapeType
    {
        #region Private Variable
        private String _name;
        private int _sidesQuantity;
        private int _idShapeType;
        #endregion

        #region Props
        public int Caras { get { return _sidesQuantity; } }
        #endregion

        #region Idiomas Enum
        /// <summary>
        /// Cuadrado, solo se especifica un solo lado.
        /// </summary>
        public static ShapeType Cuadrado = new ShapeType(Resources.Resources.Square, 1, 1);
        /// <summary>
        /// Triángulo equilatero, solo se especifica un solo lado.
        /// </summary>
        public static ShapeType TrianguloEquilatero = new ShapeType(Resources.Resources.Triangle, 1, 2);
        /// <summary>
        /// Círculo, solo se especifica la longitud en los lados.
        /// </summary>
        public static ShapeType Circulo = new ShapeType(Resources.Resources.Circle, 1, 3);
        /// <summary>
        /// Trapecio, se especifican ambas bases y la altura.
        /// </summary>
        public static ShapeType TrapecioRectangulo = new ShapeType(Resources.Resources.Trapezoid, 3, 4);
        #endregion

        #region Constructores
        private ShapeType(String name, int sidesQuantity, int idShapeType)
        {

            this._name = name;
            this._sidesQuantity = sidesQuantity;
            this._idShapeType = idShapeType;
        }
        public String toString()
        {
            return _name;
        }
        public int getEnumId()
        {
            return _idShapeType;
        }
        public static ShapeType GetShapeTypeByEnumId(int enumId)
        {
            switch (enumId)
            {
                case 1: return new ShapeType(Resources.Resources.Square, 1, 1);
                case 2: return new ShapeType(Resources.Resources.Triangle, 1, 2);
                case 3: return new ShapeType(Resources.Resources.Circle, 1, 3);
                case 4: return new ShapeType(Resources.Resources.Trapezoid, 3, 4);
            
                default: throw new ArgumentOutOfRangeException(Resources.Resources.UnknownShape);
            }
        }
        #endregion

    }
}
