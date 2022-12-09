using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    public class Weight : IValue
    {
        private string _NameValue = "Вес";
        public string GetNameValue()
        {
            return _NameValue;
        }

        private Dictionary<string, double> _coeff = new Dictionary<string, double>()
        {
            {"Килограммы", 1},
            {"граммы", 0.001},
            {"Тонны", 1000},
            {"Центнеры", 100},
        };

        public Dictionary<string, double> GetCoefficients()
        {
            return _coeff;
        }
    }
}
