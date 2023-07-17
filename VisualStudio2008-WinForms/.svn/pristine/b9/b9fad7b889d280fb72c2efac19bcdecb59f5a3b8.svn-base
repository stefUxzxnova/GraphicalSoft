using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Draw.src.GUI
{
    public partial class ResizeForm : Form
    {
        private DialogProcessor dialog;
        public ResizeForm(DialogProcessor dialog)
        {
            InitializeComponent();
            this.dialog = dialog;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float width = (float)widthNumericUpDown1.Value;
            float height = (float)heightNumericUpDown2.Value;
            
            dialog.ScalePrimitive(width, height);
            this.Close();
        }
    }
}
