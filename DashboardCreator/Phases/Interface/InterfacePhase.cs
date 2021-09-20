using DashboardCreator.Models;
using DashboardCreator.Utility;
using static DashboardCreator.Utility.FileExtension;

namespace DashboardCreator.Phases
{
    public class InterfacePhase : IPhase
    {

        public void Create(string baseAdd, string modelPhysicalAdd, FoundClass foundClass)
        {
            string projectname = foundClass.NameSpace;
            string modelAdd = foundClass.ClassName;
            string realModelName = foundClass.ClassName;
            baseAdd = $"{baseAdd}\\{projectname}.Core\\Infrastructure\\{modelPhysicalAdd}";
            var contect = Replacer.Replace("Interface",projectname, modelPhysicalAdd, realModelName);
            CreateFile(baseAdd, "I" + realModelName + "Service.cs", contect);


        }

        
    }
}
