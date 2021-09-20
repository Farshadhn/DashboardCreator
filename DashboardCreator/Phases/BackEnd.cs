using DashboardCreator.Models;
using DashboardCreator.Phases.Controller;
using DashboardCreator.Phases.Service;
using DashboardCreator.Phases.Share;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardCreator.Phases
{
    public class BackEnd
    {
        public enum ProcessFlow
        {
            Interface
        }
        public void LetsBurnIt(string api, FoundClass model)
        {
     
            string modelPhysicalAdd = model.RelatedNamespace.Aggregate("", (a, b) =>
            {
                return (b != model.ClassName) ? $"{a}\\{b}" : $"{a}";
            }).Trim('\\'); ;
            new InterfacePhase().Create(api, modelPhysicalAdd, model);
            new ServicePhase().Create(api, modelPhysicalAdd, model);
            new SharePhase().Create(api, modelPhysicalAdd, model);
            new ControllerPhase().Create(api, modelPhysicalAdd, model);







            static string GetIntendedFolder(string[] folders)
            {
                foreach (var folder in folders)
                {
                    if (folder.Contains("Core"))
                    {
                        return folder;
                    }
                }

                return "";
            }
        }



    }
}
