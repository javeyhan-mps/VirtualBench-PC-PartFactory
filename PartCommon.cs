using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPS.Common.Model;

namespace MPS.PartFactory
{
    public class PartCommon : AbstractPart
    {

        public PartCommon(string partnumber)
        {
            this.Partnumber = partnumber;
        }
        public ProjectConfig LoadConfig(string partnumber)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(Partnumber);

            var config = dbHelper.GetProjectConfig();

            return config;
        }
        public override ProjectConfig LoadConfig()
        {
            return LoadConfig(this.Partnumber);
        }
    }
}
