using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCase
{
    public partial class LoginPanel : Form
    {
        private OrderApi oapi = OrderApi.inst;
        public LoginPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: modify ip, port by your favor
            oapi.OrderLogin(0, "", userTB.Text.ToUpper(), pwdTB.Text, "140.112.30.44", (ushort)Int32.Parse("80"));
            Console.Write(userTB.Text + ", " + pwdTB.Text);
            (new MainPage()).Show();
            Hide();
        }
        
        private void LoginPanel_Load(object sender, EventArgs e)
        {
           
        }
    }
}
