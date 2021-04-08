using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotheque.IHM
{
    public static class Helper
    {
        public static Object GetPropValue(this Object aobj, string astrName)
        {
            foreach (string part in astrName.Split('.'))
            {
                if (aobj == null) { return null; }

                Type type = aobj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                aobj = info.GetValue(aobj, null);
            }
            return aobj;
        }
        public static T GetPropValue<T>(this Object aobj, string astrName)
        {
            Object retval = GetPropValue(aobj, astrName);
            if (retval == null) { return default(T); }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }
        public static void SetFieldValue<T>(this Object aobj, string astrName, T aValue)
        {
            foreach (string part in astrName.Split('.'))
            {
                if (aobj != null)
                {
                    Type type = aobj.GetType();
                    FieldInfo info = type.GetField(part);
                    if (info != null) info.SetValue(aobj, aValue);
                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class PropertyName : Attribute
    {
        public string Value { get; set; }
        public PropertyName(string aValue)
        {
            Value = aValue;
        }
    }
}
