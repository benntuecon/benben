using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using P = SimpleCase.ParamDef;
using C = SimpleCase.Common;

namespace SimpleCase
{
	public partial class CA_Form : Form
	{
		OpenFileDialog pfile = new OpenFileDialog();

		P.AccountInfo acct_ca;

		public CA_Form(ref P.AccountInfo acct)
		{
			InitializeComponent();
			this.acct_ca= acct;
			this.Text= String.Format("{0}-{1}-{2}-{3}", C.AccountTypeToName(acct_ca.cAcctType), (char)acct_ca.cAcctType, acct_ca.szBranchNo, acct_ca.szAccount);
		}

		private void button_CertFile_Click(object sender, EventArgs e)
		{
			pfile.Filter = "CA files (*.pfx)|*.pfx|(*.p12)|*.p12";
            pfile.InitialDirectory= "C:";
            pfile.ShowDialog();
		}

		private void CA_Load(object sender, EventArgs e)
		{
            pfile.FileOk += new CancelEventHandler(this.button_CA_FileOK);
		}

		private void button_CA_FileOK(object sender, CancelEventArgs e)
        {
            textBox_CertFile.Text = pfile.FileName;
        }

		private void button_ok_Click(object sender, EventArgs e)
		{
			/*
             * if (textBox_CertFile.Text.Length == 0 || textBox_CertPassword.Text.Length == 0) {
				MessageBox.Show("輸入錯誤!", "CA", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			MainPage._inst.CheckCA(ref acct_ca, textBox_CertFile.Text, textBox_CertPassword.Text);

			//Restore ???
			for(int i=0; i< MainPage._inst.OdrAcctList.Count;i++) {
				P.AccountInfo acct= MainPage._inst.OdrAcctList[i];

				if((acct_ca.cAcctType==acct.cAcctType) &&
				   (acct_ca.szBranchNo.CompareTo(acct.szBranchNo)==0) &&
				   (acct_ca.szAccount.CompareTo(acct.szAccount)==0) &&
                   (acct_ca.szId.CompareTo(acct.szId)==0))
				{
                    MainPage._inst.OdrAcctList[i]= acct_ca;
				}			
			}
			this.Dispose();*/
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
