
using DashboardCreator.Models;

namespace DashboardCreator.Utility
{

    public static class Replacer
    {
        public static string Replace(string fileName, string projectName, string modelAdd, string modelName,string Side = "BackEnd")
        {
            var interfaceFile = System.IO.File.ReadAllText(@$".\\{Side}\\{fileName}Template.cs");
            interfaceFile = interfaceFile.Replace("#ProjectName", projectName);
            interfaceFile = interfaceFile.Replace("#ModelName", modelName); 
            interfaceFile = interfaceFile.Replace("#ModelAdd", modelAdd);//ModelName has to be in plural form 
            return interfaceFile;
        }   
        public static string ReplaceContentHolder(FoundClass foundClass,string oldContent,bool displayName = false)
        { 
            var Content = string.Empty;
            foreach (var item in foundClass.Properties)
            {
                if (item.PropertyType.Assembly.FullName.Contains(foundClass.NameSpace))
                    continue;
                if (item.PropertyName.Trim() is not "LastEditedDateTime" and not "LastEditedUserId" and not "LastEditedUser" and not "IsDeleted")
                {
                    if(displayName)
                        Content = $"{Content} [Display(Name = \"{item.PropertyName}\")] \r\n";
                    Content = $"{Content} \tpublic {item.PropertyType.Name} {item.PropertyName} {{get;set;}} \r\n\r\n\r\n";
                }
            }
            oldContent = oldContent.Replace("#ContentHolder", Content);
            return oldContent;
        }
        

    }
}
