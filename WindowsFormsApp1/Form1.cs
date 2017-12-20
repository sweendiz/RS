using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms.VisualStyles;


namespace WindowsFormsApp1
{
    public partial class RS : Form
    {
        static HttpClient client = new HttpClient();



        public RS()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            
            Display.Items.Clear();
            int skill = 0;
            string index =comboBox1.SelectedItem.ToString();
            if(index == "Firemaking")
            {
                skill = 13;
            }
            List<string> rsUsers = new List<string>();
            rsUsers.Add("HC Dankmemer");
            rsUsers.Add("Iron Groleau");
            rsUsers.Add("dank_mememan");
            string sURL;
            foreach (string name in rsUsers) {
                sURL = "http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player=" + name;
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(sURL);
                WebProxy myProxy = new WebProxy("myproxy", 80);
                myProxy.BypassProxyOnLocal = true;

                wrGETURL.Proxy = WebProxy.GetDefaultProxy();

                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                string sLine = "";
                int i = 0;
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();

                    if (i == skill)
                    {
                        List<string> result = sLine.Split(',').ToList();
                        Display.Items.Add(name + " has a firemaking lvl of " + result[1]);
                    }
                }
                Console.ReadLine();

            }
        }

        private void skillComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}



