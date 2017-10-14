using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Binance.API.Csharp.Client.Utils
{
    /// <summary>
    /// Class to define extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Extension method to get a enum description.
        /// </summary>
        /// <param name="value">Enum to get the description from.</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            return ((DescriptionAttribute)Attribute.GetCustomAttribute(
                value.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Single(x => x.GetValue(null).Equals(value)),
                typeof(DescriptionAttribute)))?.Description ?? value.ToString();
        }
    }
}
