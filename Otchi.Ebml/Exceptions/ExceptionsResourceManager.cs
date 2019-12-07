using System.Reflection;
using System.Resources;

namespace Otchi.Ebml.Exceptions
{
    public static class ExceptionsResourceManager
    {
        public static ResourceManager ResourceManager { get; } = 
            new ResourceManager("Otchi.Ebml.Resources.ExceptionMessages", 
                Assembly.GetAssembly(typeof(ExceptionsResourceManager)));
    }
}