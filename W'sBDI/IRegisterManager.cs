using System;
using System.Collections.Generic;
using System.Text;
using W_sBDI.Building;
using W_sBDI.Core;

namespace W_sBDI
{
    internal interface IRegisterManager
    {
        IConfigurationDefiner ConfigurationDefiner { get; set; }
        void AddTypeImplementor(Type tImpl);
        void AddLifeStyle(LyfeStyle lyfeStyle);
    }
}
