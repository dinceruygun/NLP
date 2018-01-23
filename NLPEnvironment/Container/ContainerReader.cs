using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Container
{

    public enum ContainerName
    {
        SHORTLIST,
        MORPHOLOGICAL
    }


    public class ContainerReader
    {
        public string Read(ContainerName containerName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"NLPEnvironment.Container.{GetContainerFileName(containerName)}";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }


        protected string GetContainerFileName (ContainerName containerName)
        {
            switch (containerName)
            {
                case ContainerName.SHORTLIST:
                    return "ShortList.txt";
                case ContainerName.MORPHOLOGICAL:
                    return "Morphological.txt";
                default:
                    return null;
            }
        }
    }
}
