using MPS.Common.Model;
using MPS.Common.Serializer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.PartFactory
{
    public class DataBaseHelper
    {
        private readonly string CONST_CONFIG_FOLDER = "DataBase";
        private const string CONST_CONFIG_NAME = "UserDefine.xml";

        public DataBaseHelper(string chipName)
        {
            CONST_CONFIG_FOLDER = string.Format(@"{0}\{1}", CONST_CONFIG_FOLDER, chipName);
        }

        public ProjectConfig GetProjectConfig()
        {
            if (!Directory.Exists(CONST_CONFIG_FOLDER))
                return null;
            var path = Path.Combine(CONST_CONFIG_FOLDER, "DefaultDatasheet.Spec");
            if (File.Exists(path))
            {
                return SerializeHelper.XMLDeserialize<ProjectConfig>(path);
            }

            return null;
        }
        private void checkFolder()
        {
            var folderPath = string.Format(@"{0}\{1}", Environment.CurrentDirectory, CONST_CONFIG_FOLDER);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}
