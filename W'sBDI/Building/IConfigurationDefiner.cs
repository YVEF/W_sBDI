using System;
using System.Collections.Generic;
using System.Text;
using W_sBDI.Core;

namespace W_sBDI.Building
{
    internal interface IConfigurationDefiner
    {
        void AddImplementorTypes(IList<Type> type);
        LifeTimeManagement LifeTimeManagement { get; set; }
        object GetInstance();
        void StartupBuildingObject();
    }
}
