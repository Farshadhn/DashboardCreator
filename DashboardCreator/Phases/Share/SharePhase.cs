using DashboardCreator.Models;
using DashboardCreator.Utility;
using static DashboardCreator.Utility.FileExtension;

namespace DashboardCreator.Phases.Share
{
    public class SharePhase : IPhase
    {
        public void Create(string baseAdd, string modelPhysicalAdd, FoundClass foundClass)
        {
            string projectname = foundClass.NameSpace;
            string modelAdd = foundClass.ClassName;
            string realModelName = foundClass.ClassName;
            baseAdd = $"{baseAdd}\\{projectname}.Share\\Models\\{modelPhysicalAdd}";
            var contect = Replacer.Replace("ShareDto", projectname, modelPhysicalAdd, realModelName);
            contect = Replacer.ReplaceContentHolder(foundClass, contect);
            var contectSelect = Replacer.Replace("ShareSelectDto", projectname, modelPhysicalAdd, realModelName);
            CreateFile(baseAdd, "I" + realModelName + "Dto.cs", contect);
            CreateFile(baseAdd, "I" + realModelName + "SelectDto.cs", contectSelect);

        }


    }
}
