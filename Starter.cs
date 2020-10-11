using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ECMU.Interface;

namespace Creaous.WebServer
{
    public class Starter:PluginImplementer 
    {
        public string PluginName()
        {
            return "Web Server";
        }

        public string PluginVersion()
        {
            return "1.0.0.0";
        }

        public string PluginAuthor()
        {
            return "Creaous";
        }

        public string PluginDescription()
        {
            return "This module is to show off what plugins can be like. The code is based off of the FreePOS web server.";
        }

        public Icon PluginIcon()
        {
            return Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
        }

        public void ButtonAdder(System.Windows.Forms.Button btn)
        {
            btn.Click += button_Click;
        }

        public void button_Click(object sender, EventArgs e)
        {
            // Hide this form and show the menu.
            var formToShow = Application.OpenForms.Cast<Form>()
            .FirstOrDefault(c => c is frmMain);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            else
            {
                frmMain menu = new frmMain();
                menu.Show();
            }
        }
    }
}
