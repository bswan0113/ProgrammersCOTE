using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace _02_Scripts.Utils
{
    public static class Extensions
    {

        public static string ToDebugString(this object obj)
        {
            if (obj == null) return "null";

            var visited = new HashSet<object>(new ReferenceEqualityComparer());
            var sb = new StringBuilder();

            ToDebugStringRecursive(obj, sb, 0, visited);
            return sb.ToString();
        }

        private static void ToDebugStringRecursive(object obj, StringBuilder sb, int indentLevel, HashSet<object> visited)
        {
            if (obj == null)
            {
                sb.Append("null");
                return;
            }

            var type = obj.GetType();

            if (type.IsPrimitive || type == typeof(string) || type.IsEnum || type == typeof(decimal) || type == typeof(DateTime))
            {
                sb.Append(obj is string s ? $"\"{s}\"" : obj.ToString());
                return;
            }

            if (!type.IsValueType && visited.Contains(obj))
            {
                sb.Append($"[Circular Reference: {type.Name}]");
                return;
            }
            if (!type.IsValueType) visited.Add(obj);

            var indent = new string(' ', indentLevel * 2);
            var innerIndent = new string(' ', (indentLevel + 1) * 2);

            if (obj is IEnumerable enumerable && type != typeof(string))
            {
                if (obj is IDictionary dictionary)
                {
                    sb.AppendLine($"Dictionary<{type.GenericTypeArguments[0].Name}, {type.GenericTypeArguments[1].Name}>[{dictionary.Count}] {{");
                    foreach (DictionaryEntry entry in dictionary)
                    {
                        sb.Append($"{innerIndent}[");
                        ToDebugStringRecursive(entry.Key, sb, indentLevel + 1, visited);
                        sb.Append("]: ");
                        ToDebugStringRecursive(entry.Value, sb, indentLevel + 1, visited);
                        sb.AppendLine();
                    }
                    sb.Append($"{indent}}}");
                }
                else
                {
                    sb.AppendLine($"Collection<{type.Name}>[");
                    int count = 0;
                    foreach (var item in enumerable)
                    {
                        if (count > 0) sb.AppendLine(",");
                        sb.Append($"{innerIndent}[{count}]: ");
                        ToDebugStringRecursive(item, sb, indentLevel + 1, visited);
                        count++;
                        if (count > 50) {
                            sb.AppendLine().Append($"{innerIndent}...");
                            break;
                        }
                    }
                    sb.AppendLine();
                    sb.Append($"{indent}]");
                }
            }
            else
            {
                sb.AppendLine($"{type.Name} {{");

                var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var prop in properties.Where(p => p.GetIndexParameters().Length == 0))
                {
                    sb.Append($"{innerIndent}{prop.Name}: ");
                    try
                    {
                        ToDebugStringRecursive(prop.GetValue(obj), sb, indentLevel + 1, visited);
                    }
                    catch (Exception) { sb.Append("[Could not get value]"); }
                    sb.AppendLine();
                }

                foreach (var field in fields)
                {
                    if (field.Name.Contains("k__BackingField")) continue;

                    sb.Append($"{innerIndent}{field.Name}: ");
                    try
                    {
                        ToDebugStringRecursive(field.GetValue(obj), sb, indentLevel + 1, visited);
                    }
                    catch (Exception) { sb.Append("[Could not get value]"); }
                    sb.AppendLine();
                }

                sb.Append($"{indent}}}");
            }

            if (!type.IsValueType) visited.Remove(obj);
        }

        private class ReferenceEqualityComparer : IEqualityComparer<object>
        {
            bool IEqualityComparer<object>.Equals(object x, object y) => ReferenceEquals(x, y);
            public int GetHashCode(object obj) => System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj);
        }
    }
}