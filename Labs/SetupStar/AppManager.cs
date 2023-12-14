using SetupStar.Domain;
using SetupStar.Helpers;

namespace SetupStar
{
    public class AppManager
    {
        public AppManager()
        {
            LoadScripts();


            var test = Steps.PowerShell("test", "{'MassaKod bara'}");
            test.Execute();
        }

        private void LoadScripts()
        {
            //Load scripts from script folder
            CreateScriptPathIfNotExists();
            var scriptPath = GetScriptPath();

            foreach (var file in Directory.GetFiles(scriptPath))
            {

            }
        }

        private string GetScriptPath()
        {
            return Common.ScriptsPath;
        }

        private void CreateScriptPathIfNotExists()
        {
            if (!Directory.Exists(Common.ScriptsPath))
                Directory.CreateDirectory(Common.ScriptsPath);
        }
    }
}
