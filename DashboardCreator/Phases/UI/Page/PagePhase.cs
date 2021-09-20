using DashboardCreator.Models;
using DashboardCreator.Utility;
using static DashboardCreator.Utility.FileExtension;

namespace DashboardCreator.Phases.UI.Page
{
    public class PagePhase : IPhase
    {
        public void Create(string baseAdd, string modelPhysicalAdd, FoundClass foundClass)
        {
            string projectname = foundClass.NameSpace;
            string modelAdd = foundClass.ClassName;
            string realModelName = foundClass.ClassName;
            var mAdd = $"{baseAdd}\\{projectname}.UI\\Models\\{modelPhysicalAdd}";
            Dto(projectname, mAdd, modelAdd, realModelName);
            SelectDto(projectname, mAdd, modelAdd, realModelName);


            var padd = $"{baseAdd}\\{projectname}.UI\\Pages\\{modelPhysicalAdd}";
            Page(projectname, padd, modelAdd, realModelName);


            static void Page(string projectname, string baseAdd, string modelAdd, string realModelName)
            {
                var content = Replacer.Replace("Page", projectname, modelAdd, realModelName, "FrontEnd");
                CreateFile(baseAdd, realModelName + ".razor", content);

            }


            static void Dto(string projectname, string baseAdd, string modelAdd, string realModelName)
            {
                var content = Replacer.Replace("Dto", projectname, modelAdd, realModelName, "FrontEnd");
                CreateFile(baseAdd, realModelName + "Dto.cs", content);

            }
            static void SelectDto(string projectname, string baseAdd, string modelAdd, string realModelName)
            {
                var content = Replacer.Replace("SelectDto", projectname, modelAdd, realModelName, "FrontEnd");
                CreateFile(baseAdd, realModelName + "SelectDto.cs", content);

            }
        }

     
    }
}
