using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Draw.src.GUI
{
    public partial class NameForm : Form
    {
        private DialogProcessor dialog;

        public NameForm(DialogProcessor dialog)
        {
            InitializeComponent();
            this.dialog = dialog;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                this.Close();
                return;
            }
            dialog.Name(textBox1.Text);
            this.Close();
        }
    }
}
