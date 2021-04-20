using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Enum
{
    public class Language
    {
        #region Variables privadas
        private String _siglas;
        #endregion
        #region Idiomas Enum
        public static Language Castellano = new Language("es_ES");
        public static Language English = new Language("en_US");
        public static Language Polaco = new Language("pl_PL");
        #endregion

        #region Constructores
        private Language(String siglas)
        {
            this._siglas = siglas;
        }
        public String toString()
        {
            return _siglas;
        }
        #endregion
    }
}
