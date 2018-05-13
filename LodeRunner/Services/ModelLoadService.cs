namespace LodeRunner.Services
{
    using LodeRunner.Model;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class ModelLoadService : IModelLoadService
    {
        private static BinaryFormatter formatter = new BinaryFormatter();

        public Model Load(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (Model)formatter.Deserialize(fs);
            }
        }

        public void Save(string path, Model model)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, model);
            }
        }
    }
}
