using DashboardCreator.Models;
using DashboardCreator.Phases.UI.Page;
using System.Linq;

namespace DashboardCreator.Phases
{
    public class FrontEnd
    { 
        public void LetsBurnIt(string api, FoundClass model)
        {

            //var model = modelName.Trim('\\').Split("\\").ToList();
            //var realModelName = model.Last().Replace(".cs", "");
            //model.RemoveAt(model.Count - 1);
            //var modelAdd = model.Aggregate("", (a, b) => $"{a}.{b}").Trim('.');
            //var modelPhysicalAdd = model.Aggregate("", (a, b) => $"{a}\\{b}").Trim('\\');
            string modelPhysicalAdd = model.RelatedNamespace.Aggregate("", (a, b) =>
            {
                return (b != model.ClassName) ? $"{a}\\{b}" : $"{a}";
            }).Trim('\\'); ;

            new PagePhase().Create(api, modelPhysicalAdd, model);
            







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
