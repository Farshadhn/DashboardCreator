using DashboardCreator.Models;
using DashboardCreator.Utility;

using static DashboardCreator.Utility.FileExtension;

namespace DashboardCreator.Phases.Controller
{
    public class ControllerPhase : IPhase
    {
        public void Create(string baseAdd, string modelPhysicalAdd, FoundClass foundClass)
        {
            string projectname = foundClass.NameSpace;
            string modelAdd = foundClass.ClassName;
            string realModelName = foundClass.ClassName;


            var mAdd = $"{baseAdd}\\{projectname}.Api\\Models\\{modelPhysicalAdd}";
            Dto(projectname, mAdd, modelPhysicalAdd, realModelName,foundClass);
            SelectDto(projectname, mAdd, modelPhysicalAdd, realModelName, foundClass);
           

            var cadd = $"{baseAdd}\\{projectname}.api\\controllers\\v1\\";
            Controller(projectname, cadd, modelPhysicalAdd, realModelName);


            static void Controller(string projectname, string baseAdd, string modelAdd, string realModelName)
            {
                var content = Replacer.Replace("Controller",projectname, modelAdd, realModelName);
                CreateFile(baseAdd, realModelName + "Controller.cs", content);

            }


            static void Dto(string projectname, string baseAdd, string modelAdd, string realModelName, FoundClass foundClass)
            {
                var content = Replacer.Replace("Dto", projectname, modelAdd, realModelName);
                content = Replacer.ReplaceContentHolder(foundClass, content);
                CreateFile(baseAdd, realModelName + "Dto.cs", content);

            }
            static void SelectDto(string projectname, string baseAdd, string modelAdd, string realModelName, FoundClass foundClass)
            {
                var content = Replacer.Replace("SelectDto", projectname, modelAdd, realModelName);
                content = Replacer.ReplaceContentHolder(foundClass, content);
                CreateFile(baseAdd, realModelName + "SelectDto.cs", content);

            }
        }
 
    }
}
