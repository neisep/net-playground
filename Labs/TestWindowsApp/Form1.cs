using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datastracture.Datastracture;
using TestWindowsApp.POC;

namespace TestWindowsApp
{
    public partial class Form1 : Form
    {
        private UDPHolePunch _udpHolePunch;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            textBox1.Text = GetTargetFrameWorkFromAssembly();

            _udpHolePunch = new UDPHolePunch();
        }

        //Using Attribute to get the current .net framework that the App was built for.
        private string GetTargetFrameWorkFromAssembly()
        {
            var assembly = Assembly.GetEntryAssembly();
            if (assembly == null) return string.Empty;

            var attribute = (TargetFrameworkAttribute[])assembly.GetCustomAttributes(typeof(TargetFrameworkAttribute));

            return attribute.Length > 0 ? attribute[0].FrameworkDisplayName : string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO DO SOMETHING GREAT!
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var binaryTree = new BinarySearchThree();
            //binaryTree.CreateThree();

            //textBox1.Text = $"{binaryTree.GetLeftNode()} {Environment.NewLine}{binaryTree.GetRightNode()}";

            //label6.Text = binaryTree.GetTopValue().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _udpHolePunch.Server(int.Parse(textBox3.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IPAddress serverIP = IPAddress.Parse(textBox4.Text);
            int port = int.Parse(textBox3.Text);
            IPEndPoint ipEndPoint = new IPEndPoint(serverIP, port);

            textBox1.Text += _udpHolePunch.SendMessageToServer("Hello test message", ipEndPoint);
        }
    }
}
