using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.Data.Classes.Enum;
namespace CodingChallenge.Data.Classes
{

    public class Shape
    {
        #region Private Variables
        private decimal[] _sides;
        private ShapeType _type;
        #endregion
        #region Props
        public ShapeType Tipo { get { return _type; } }

        #endregion
        #region Constructores

        /// <summary>
        /// Creación de Trapecio
        /// </summary>
        /// <param name="Tipo">Tipo de Forma</param>
        /// <param name="BaseA">Base A de Forma</param>
        /// <param name="BaseB">Base B de Forma (por si es trapecio)</param>
        /// <param name="Altura">Altura (por si es trapecio o rectángulo)</param>
        public Shape(ShapeType Tipo, decimal BaseA, decimal BaseB, decimal Altura)
        {
            _initSides(Tipo, BaseA, BaseB, Altura);
        }
        //Creación de Rectángulos
        public Shape(ShapeType Tipo, decimal Lado, decimal Altura)
        {
            _initSides(Tipo, Lado, 0, Altura);
        }
        //Creación de Forma como Cuadrado, Circulo o Triángulo
        public Shape(ShapeType Tipo, decimal Lado)
        {
            _initSides(Tipo, Lado, 0, 0);

        }

        #endregion

        #region Public Methods


        //Método CalcularArea
        public decimal CalcularArea()
        {
            if (Tipo == ShapeType.Cuadrado) return _areaCuadrado();
            if (Tipo == ShapeType.Circulo) return _areaCirculo();
            if (Tipo == ShapeType.TrianguloEquilatero) return _areaTrianguloEquilatero();
            if (Tipo == ShapeType.TrapecioRectangulo) return _areaTrapecioRectangulo();

            throw new ArgumentOutOfRangeException(Resources.Resources.UnknownShape);
        }

        //Método CalcularPerímetro
        public decimal CalcularPerimetro()
        {
            if (Tipo.Equals(ShapeType.Cuadrado)) return _perimetroCuadrado();
            if (Tipo.Equals(ShapeType.Circulo)) return _perimetroCirculo();
            if (Tipo.Equals(ShapeType.TrianguloEquilatero)) return _perimetroTrianguloEquilatero();
            if (Tipo.Equals(ShapeType.TrapecioRectangulo)) return _perimetroTrapezioRectangulo();

            throw new ArgumentOutOfRangeException(Resources.Resources.UnknownShape);
        }
        #endregion

        #region private Methods
        private void _initSides(ShapeType type, decimal sideA, decimal sideB, decimal altitude)
        {
            _type = type;
            _sides = new decimal[type.Caras];
            decimal[] tempSides = new decimal[3] { sideA, sideB, altitude };
            for (int i = 0; i < type.Caras; i++)
                _sides[i] = tempSides[i];
        }

        #region area functions
        private decimal _areaCuadrado()
        {
            return _sides[0] * _sides[0];
        }

        private decimal _areaCirculo()
        {
            return (decimal)Math.PI * ((_sides[0] / 2) * (_sides[0] / 2));
        }

        private decimal _areaTrianguloEquilatero()
        {
            return ((decimal)Math.Sqrt(3) / 4) * (_sides[0] * _sides[0]);
        }

        private decimal _areaTrapecioRectangulo()
        {
            return (_sides[0] + _sides[1]) * _sides[2] / 2;
        }

        #endregion

        #region perimeter functions
        private decimal _perimetroCuadrado()
        {
            return _sides[0] * 4;
        }

        private decimal _perimetroCirculo()
        {
            return (decimal)Math.PI * _sides[0];
        }

        private decimal _perimetroTrianguloEquilatero()
        {
            return (decimal)_sides[0] * 3;
        }

        private decimal _perimetroTrapezioRectangulo()
        {
            decimal smallBase = _sides[0] < _sides[1] ? _sides[0] : _sides[1];
            decimal greaterBase = _sides[0] > _sides[1] ? _sides[0] : _sides[1];

            decimal n = greaterBase - smallBase;
            decimal oblicuo = ((decimal)Math.Sqrt((double)((_sides[2] * _sides[2]) + (n * n))));

            return (decimal)_sides[0] + oblicuo + _sides[1] + _sides[2];
        }
        #endregion

        #endregion
    }
}
