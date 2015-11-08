using System;

namespace MP3Boss.Source.Forms
{
    public partial class CheckMessageForm : System.Windows.Forms.Form
    {
        public CheckMessageForm()
        {
            InitializeComponent();
        }

        private void btnMsgBoxYes_Click(object sender, EventArgs e)
        {
            msgBoxResult = "Yes";
            this.Close();
        }

        private void btnMsgBoxContinue_Click(object sender, EventArgs e)
        {
            msgBoxResult = "Continue";
            this.Close();
        }

        private void btnMsgBoxSkip_Click(object sender, EventArgs e)
        {
            msgBoxResult = "Skip";
            this.Close();
        }

        private static string msgBoxResult = null;
        public string MsgBoxResult
        {
            get { return msgBoxResult; }
        }

        private static bool applyToAll = false;
        public bool ApplyToAll
        {
            get { return applyToAll; }
            set { applyToAll = value; }
        }

        private void cMsgBoxApplyToAll_CheckedChanged(object sender, EventArgs e)
        {
            this.ApplyToAll = cMsgBoxApplyToAll.Checked;
        }
    }
}
