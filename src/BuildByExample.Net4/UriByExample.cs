using System;
using System.Linq;
using System.Linq.Expressions;

namespace BuildByExample
{
    public static class UriByExample
    {
        public static Uri GetXamlUri<T>(string rootNamespace, Expression<Func<T>> typeInitializer)
        {
            var parts = DictionaryByExample.Build(typeInitializer)
                .Where(x => x.Value.GetType().IsValueType)
                .Select(x => x.Key + "=" + x.Value);

            var targetType = typeInitializer.Body.Type;

            var target = String.Format("{0}/{1}.xaml",
                                       targetType.Namespace.Remove(0, rootNamespace.Length).Replace(".", "/"),
                                       targetType.Name);

            if (parts.Any())
            {
                target += parts.Aggregate("?", (x, y) => (x == "?") ? x + y : x + "&" + y);
            }

            return new Uri(target, UriKind.RelativeOrAbsolute);
        }
    }
}