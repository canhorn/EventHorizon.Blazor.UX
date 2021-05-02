namespace EventHorizon.Blazor.Mockup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TypeExtensions
    {
        public static List<PropertyDescription> GetPropertyDescriptions(this Type type, int depth = 0)
        {
            var propertyDescriptions = new List<PropertyDescription>();
            foreach (var propertyInfo in type.GetProperties())
            {
                var propertyDescription = new PropertyDescription
                {
                    PropertyName = propertyInfo.Name,
                    TypeName = propertyInfo.PropertyType.GetFriendlyName(),
                    Type = propertyInfo.PropertyType,
                };

                if (!propertyDescription.IsPrimitive
                    // String is not a primitive type
                    && propertyInfo.PropertyType != typeof(string))
                {
                    propertyDescription.IsPrimitive = false;
                    if (depth > 0)
                    {
                        propertyDescription.Properties = GetPropertyDescriptions(
                            propertyInfo.PropertyType,
                            depth - 1
                        );
                    }
                }
                else
                {
                    propertyDescription.IsPrimitive = true;
                }

                var propertyAttributes = new List<PropertyAttribute>();
                foreach (var attributeInfo in propertyInfo.GetCustomAttributes(true))
                {
                    var propertyAttribute = new PropertyAttribute
                    {
                        Name = attributeInfo.GetType().Name,
                        Type = attributeInfo.GetType().GetFriendlyName(),
                    };
                    propertyAttributes.Add(propertyAttribute);
                }
                propertyDescription.Attributes = propertyAttributes;

                propertyDescriptions.Add(propertyDescription);
            }
            return propertyDescriptions;
        }

        public static string GetFriendlyName(this Type type, bool fullName = false)
        {
            var types = new Dictionary<Type, string>
            {
                [typeof(int)] = "Int",
                [typeof(short)] = "Short",
                [typeof(byte)] = "Byte",
                [typeof(bool)] = "Bool",
                [typeof(long)] = "Long",
                [typeof(float)] = "Float",
                [typeof(double)] = "Double",
                [typeof(decimal)] = "Decimal",
                [typeof(string)] = "String",
            };

            var firstType = types.FirstOrDefault(
                a => a.Key == type
            ).Value;

            if (firstType != null)
            {
                return firstType;
            }

            if (type.IsGenericType)
                return type.Name.Split('`')[0] + "<" + string.Join(", ", type.GetGenericArguments().Select(x => GetFriendlyName(x)).ToArray()) + ">";
            else
                return fullName
                    ? type.FullName ?? type.Name
                    : type.Name;
        }
    }
}
