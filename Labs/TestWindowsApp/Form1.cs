using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            textBox1.Text = GetTargetFrameWorkFromAssembly();
        }

        //Using Attribute to get the current .net framework that the App was built for.
        private string GetTargetFrameWorkFromAssembly()
        {
            var assembly = Assembly.GetEntryAssembly();
            if (assembly == null) return string.Empty;

            var attribute = (TargetFrameworkAttribute[])assembly.GetCustomAttributes(typeof(TargetFrameworkAttribute));

            return attribute.Length > 0 ? attribute[0].FrameworkDisplayName : string.Empty;
        }
    }
}
