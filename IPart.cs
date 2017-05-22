﻿using MPS.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.PartFactory
{
    interface IPart
    {
        ProjectConfig LoadConfig();
    }
}
