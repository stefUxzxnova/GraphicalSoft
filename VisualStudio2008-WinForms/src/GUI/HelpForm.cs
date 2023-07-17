﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace Draw.src.GUI
{
    public partial class HelpForm : Form
    {

        public HelpForm()
        {
            InitializeComponent();
            InformationText.Text = "Помощ: \n\n* CTRL + G -> ГРУПИРАНЕ; \n* CTRL + U -> РАЗГРУПИРАНЕ; \n* CTRL + С -> КОПИРАНЕ; \n* CTRL + V -> ПОСТАВЯНЕ; \n* CTRL + Х -> ИЗТРИВАНЕ; \n* CTRL + A -> СЕЛЕКТИРАНЕ НА ВСИЧКИ; \n* CTRL + R -> ОТСЕЛЕКТИРАНЕ НА ВСИЧКИ ";
                
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
