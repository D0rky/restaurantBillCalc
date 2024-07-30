using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantBillCalc
{
    partial class NumberOfPeopleForm : Form
    {
        public NumberOfPeopleForm()
        {
            InitializeComponent();
        }

        public int NumberOfPeople { get; internal set; }

        private void Button_Click_Click(object sender, EventArgs e)
{
    // Check if the textBox contains a valid number of people
    if (int.TryParse(textBox1.Text, out int numberOfPeople) && numberOfPeople > 0)
    {
        NumberOfPeople = numberOfPeople;

        // Close the NumberOfPeopleForm
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
    else
    {
        MessageBox.Show("Please enter a valid number of people.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}

    }
}
