using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace LodeRunner.Services
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;

    public class ModelLoadServiceArray : IModelLoadService
    {
        private static BinaryFormatter formatter = new BinaryFormatter();

        public Model Load(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var model = new Model();
                var field = (Type[,])formatter.Deserialize(fs);

                for (int i = 0; i < Const.BlockWidth; i++)
                {
                    for (int j = 0; j < Const.BlockHeigth; j++)
                    {
                        Activator.CreateInstance(field[i, j], new object[] { i * Const.BlockSize, j * Const.BlockSize });
                    }
                }

                return model;
            }
        }

        public void Save(string path, Model model)
        {
            //array of element types
            var field = new Type[Const.BlockWidth, Const.BlockHeigth];

            for (int i = 0; i < Const.BlockWidth; i++)
            {
                for (int j = 0; j < Const.BlockHeigth; j++)
                {
                    field[i, j] = model.Get(i, j).GetType();
                }
            }

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, field);
            }
        }
    }
}
