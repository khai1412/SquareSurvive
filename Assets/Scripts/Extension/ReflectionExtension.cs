namespace Extension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class ReflectionExtension
    {
        public static List<Type> GetAllClassThatDeliverType<TTargetType>()
        {
            var targetType = typeof(TTargetType);

            var types = Assembly.GetExecutingAssembly().GetTypes();

            var implementingTypes = types
                .Where(type => type.IsClass && targetType.IsAssignableFrom(type) && !type.IsAbstract)
                .ToList();

            return implementingTypes;
        }
    }
}