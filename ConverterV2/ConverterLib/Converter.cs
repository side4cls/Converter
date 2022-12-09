using ConverterLib.Values;
using System.Reflection;

namespace ConverterLib
{
    public class Converter
    {
        public Converter()
        {
            SetValuesList();

        }

        /// <summary>
        /// Список физических величин
        /// </summary>
        private static List<IValue> _physicValues = new List<IValue>();

        private static void SetValuesList()
        {
            Assembly asm = Assembly.LoadFrom("ValuesLib.dll");
            Type[] types = asm.GetTypes();
            foreach (Type type in types)
            {
                if ((type.IsInterface == false) && (type.IsAbstract == false) && (type.GetInterface("IValue") != null))
                {
                    IValue value = (IValue)Activator.CreateInstance(type);
                    _physicValues.Add(value);
                }
            }
        }

        /// <summary>
        /// Метод возвращает список физических величин
        /// </summary>
        /// <returns>Список физических величин</returns>
        public List<string> GetPhysicValuesList()
        {
            List<string> physicValueList = new List<string>();
            foreach (IValue value in _physicValues)
            {
                physicValueList.Add(value.GetNameValue());
            }
            return physicValueList;
        }
        private IValue _value;

        private void SetIValue(string valueName)
        {
            foreach (var value in _physicValues)
            {
                if (value.GetNameValue() == valueName)
                {
                    _value = value;
                }
            }
        }

     
        public List<string> GetMeassureList(string physicValue)
        {
            SetIValue(physicValue);
            List<string> list = new List<string>();
            foreach (var str in _value.GetCoefficients())
                list.Add(str.Key);
            return list;
        }

        
        public double GetConvertedValue(string physicValue, double value, string from, string to)
        {
            SetIValue(physicValue);
            value *= _value.GetCoefficients()[from];
            value /= _value.GetCoefficients()[to];
            return value;
        }

    }
}