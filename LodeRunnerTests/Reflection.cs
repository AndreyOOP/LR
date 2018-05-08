using System.Reflection;

namespace LodeRunnerTests
{
    public class Reflection
    {
        public static T GetPrivateField<T>(object obj, string name)
        {
            FieldInfo fieldInfo = obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);

            return (T)fieldInfo.GetValue(obj);
        }
    }
}
