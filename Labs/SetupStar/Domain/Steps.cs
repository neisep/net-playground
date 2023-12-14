using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupStar.Domain
{
    public class Steps
    {
        private readonly string _name;
        private readonly string _payLoad;
        private readonly TypeOfExecution _typeOfExecution;

        public Steps(string name, string payLoad, TypeOfExecution typeOfExecution)
        {
            _name = name;
            _payLoad = payLoad;
            _typeOfExecution = typeOfExecution;
        }

        public void Execute()
        {
            if (_typeOfExecution == TypeOfExecution.powershell)
                PowerShell();
            
        }

        private void PowerShell()
        {
            var scriptArguments = "-ExecutionPolicy Bypass -File \"" + pathToScript + "\"";
            var processStartInfo = new ProcessStartInfo("powershell.exe", scriptArguments);
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;

            using var process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
        }

        //private void Git()
        //{

        //}

        //private void MsBuild()
        //{

        //}


        public static Steps PowerShell(string name, string payload)
        {
            return new Steps(name, payload, TypeOfExecution.powershell);
        }
    }

    public enum TypeOfExecution
    {
        powershell,
        git,
        msbuild
    }
}
