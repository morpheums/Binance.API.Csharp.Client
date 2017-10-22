using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binance.API.Csharp.Client.Tester
{
    public class FrmBase : Form
    {
        protected TextBox txtEndpoint;
        protected Label label1;

        public FrmBase()
        {
        }

        public FrmBase(Form mdiParent)
        {
            InitializeComponent();
            MdiParent = mdiParent;

        }

        private void InitializeComponent()
        {
            this.txtEndpoint = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ControlBox = false;
            Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);

            this.SuspendLayout();
            // 
            // txtEndpoint
            // 
            this.txtEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndpoint.Location = new System.Drawing.Point(66, 13);
            this.txtEndpoint.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.ReadOnly = true;
            this.txtEndpoint.Size = new System.Drawing.Size(292, 20);
            this.txtEndpoint.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Endpoint:";
            // 
            // FrmBase
            // 
            this.ClientSize = new System.Drawing.Size(372, 284);
            this.Controls.Add(this.txtEndpoint);
            this.Controls.Add(this.label1);
            this.Name = "FrmBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
