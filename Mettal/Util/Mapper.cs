using System.Linq;
using System.Reflection;

namespace Mettal.Util
{
    public static class Mapper
    {
        public static TTo Map<TFrom, TTo>(TFrom from, TTo to, string[] filetr = null) where TTo : class
        {
            PropertyInfo[] toProperties = typeof(TTo).GetProperties();
            PropertyInfo[] fromProperties = typeof(TFrom).GetProperties();

            foreach (PropertyInfo property in toProperties)
            {
                if (property.PropertyType.IsGenericType || (property.PropertyType.IsClass && property.PropertyType.Name != "String") || (filetr != null && filetr.Contains(property.Name)))
                {
                    continue;
                }

                if (property.CanWrite)
                {
                    PropertyInfo source = fromProperties.FirstOrDefault(i => i.Name == property.Name);

                    if (source != null)
                    {
                        object value = source.GetValue(from);
                        property.SetValue(to, value);
                    }
                }
            }

            return to;
        }
    }
}