﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Purchases
{
    public partial class UnitOfMeasurement : Form
    {
        public UnitOfMeasurement()
        {
            InitializeComponent();
        }
        
        private void button_cancel(object sender, EventArgs e)
        {
            this.cleaningWindow();
            /*Closing the window*/
            this.Close();
        }

        private void button_save(object sender, EventArgs e)
        {
            this.cleaningWindow();
            /*Closing the window*/
            this.Close();
        }
        private void cleaningWindow()
        {
            nameUnit.Text = "";
            abbreviation.Text = "";
        }
    }
}
