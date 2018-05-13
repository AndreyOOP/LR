using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace LodeRunnerTests
{
    public class Reflection
    {
        public static T GetPrivateField<T>(object obj, string name)
        {
            FieldInfo fieldInfo = obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);

            return (T)fieldInfo.GetValue(obj);
        }

        public static MemoryStream SerializeToMemory(object obj)
        {
            var memoryStream = new MemoryStream();
            new BinaryFormatter().Serialize(memoryStream, obj);
            return memoryStream;
        }

        public static T DeserializeFromMemory<T>(MemoryStream stream)
        {
            var formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(stream);
        }
    }
}
