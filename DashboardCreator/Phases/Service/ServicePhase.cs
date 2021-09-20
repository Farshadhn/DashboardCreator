using DashboardCreator.Models;
using DashboardCreator.Utility;
using static DashboardCreator.Utility.FileExtension;

namespace DashboardCreator.Phases.Service
{
    public   class ServicePhase : IPhase
    {

        public void Create(string baseAdd, string modelPhysicalAdd, FoundClass foundClass)
        {
            string projectname = foundClass.NameSpace;
            string modelAdd = foundClass.ClassName;
            string realModelName = foundClass.ClassName;
            baseAdd = $"{baseAdd}\\{projectname}.Service\\Services\\{modelPhysicalAdd}";
            var contect = Replacer.Replace("Service",projectname, modelPhysicalAdd, modelAdd);
            CreateFile(baseAdd, realModelName + "Service.cs", contect);
            

        }
    }
}
