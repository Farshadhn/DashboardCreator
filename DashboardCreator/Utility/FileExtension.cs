using DashboardCreator.Models;
using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DashboardCreator.Utility
{
    public static class FileExtension
    {
        // Process all files in the directory passed in, recurse on any directories
        // that are found, and process the files they contain.
        public static List<FoundClass> ListAllFiles(string targetDirectory)
        {
            var assembly = Assembly.LoadFrom(targetDirectory);
            List<Type> myTypes = assembly.GetTypes().Where(typeof(IEntity).IsAssignableFrom).ToList();


            List<FoundClass> foundProperties =
                myTypes.ConvertAll(x =>
                {
                    return new FoundClass() { FullNamespace = x.FullName.Split("."),ClassName = x.Name,FullName = x.FullName,NameSpace = x.FullName.Split(".")[0], Properties = x.GetProperties().Select(x=> new FoundProperty() {PropertyName = x.Name,PropertyType = x.PropertyType }).ToList() };
                });

            var commonNamespace = foundProperties.FirstOrDefault().FullNamespace;
            foundProperties.ForEach(x => 
            {
                commonNamespace = commonNamespace.Intersect(x.FullNamespace).ToArray();
            });
            foundProperties.ForEach(x =>
            {
                x.CommonNameSpace = commonNamespace;
                x.RelatedNamespace = x.FullNamespace.Except(commonNamespace)
                .ToList();
            });

            return foundProperties;

        
        }
   
        public static void CreateFile(string targetDirectory, string Name, string Content = "")
        {

            Directory.CreateDirectory($"{ targetDirectory}");
            if (!File.Exists($"{targetDirectory}\\{Name}"))
                File.WriteAllText($"{targetDirectory}\\{Name}", Content);

        }
    }
}
