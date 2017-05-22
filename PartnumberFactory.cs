using MPS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.PartFactory
{
    public class PartnumberFactory
    {
        public static AbstractPart CreateInstance(EnumPartnumber partnumber)
        {
            switch (partnumber)
            {
                case EnumPartnumber.MP8855:

                    return new PartMP8855(partnumber.ToString());
                default:
                    return new PartCommon(partnumber.ToString());

            }
        }
    }

}
