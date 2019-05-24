namespace SIS.MvcFramework
{
    public class MvcContext
    {
        private static MvcContext Instance;

        private MvcContext(){ }

        public static MvcContext Get => Instance ?? (Instance = new MvcContext());

        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllersSufix = "Controller";

        public string ViewsFolder { get; set; } = "Views";

        public string ModelsFolder { get; set; }
    }
}
