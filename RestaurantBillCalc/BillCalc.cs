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
    public partial class BillCalc : Form
    {
        List<string> _items = new List<string>();
        private double subTotal = 0.0;
        private double tax = 0.0;
        private double total = 0.0;
        private int numberOfPeople = 0; // Variable to store the number of people

        public BillCalc()
        {
            InitializeComponent();
            AskNumberOfPeople(); // Call a method to prompt for the number of people when the form is loaded
        }

        // Inside the BillCalc class
        private void AskNumberOfPeople()
        {
            NumberOfPeopleForm numberOfPeopleForm = new NumberOfPeopleForm();

            if (numberOfPeopleForm.ShowDialog() == DialogResult.OK)
            {
                int numberOfPeople = numberOfPeopleForm.NumberOfPeople;

                // Perform your actions based on the number of people
                CalculateTips(numberOfPeople);
            }
            else
            {
                // Handle the case where the user cancels or closes the number of people form
            }
        }

        private void CalculateTips(int numberOfPeople)
        {
            // Your bill calculation logic and other operations...
            // Assume subTotal, tax, and total are calculated previously in your code

            if (numberOfPeople > 6)
            {
                // Add 15% tips for more than 6 people
                double tipsPercentage = 0.15;
                double tipAmount = subTotal * tipsPercentage;

                // Add tips to the total
                total += tipAmount;
                totalTextBox.Text = total.ToString("N2");

                // Display or use the tip amount as needed
                MessageBox.Show($"Added 15% tips for more than 6 people.", "Tips Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Here, you can allow the user to enter the tips amount manually
                // Or perform a different calculation for 6 or fewer people
                // You can handle this part according to your specific requirements
            }
        }


        private void ApplyTipsForMoreThanSix()
        {
            // Calculate 15% tips
            double tipsPercentage = 0.15;
            double tipAmount = subTotal * tipsPercentage;

            // Add tips to the total
            total += tipAmount;
            totalTextBox.Text = total.ToString("N2");

            // Display or use the tip amount as needed
            MessageBox.Show($"Added 15% tips for more than 6 people. Tips: {tipAmount:C}", "Tips Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void appetizercComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var price = getPrice(appetizercComboBox.SelectedIndex, "appetizer");
            _items.Add(appetizercComboBox.Text + "\t" + price.ToString("C2"));
            receiptListBox.DataSource = null;
            receiptListBox.DataSource = _items;
            subTotal += price;
            subtotalTextBox.Text = subTotal.ToString("N2");
            tax = .075 * subTotal;
            taxTextBox.Text = tax.ToString("N2");
            total = subTotal + tax;
            totalTextBox.Text = total.ToString("N2");
        }

        private void beverageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var price = getPrice(beverageComboBox.SelectedIndex, "beverage");
            _items.Add(beverageComboBox.Text + "\t" + price.ToString("C2"));
            receiptListBox.DataSource = null;
            receiptListBox.DataSource = _items;
            subTotal += price;
            subtotalTextBox.Text = subTotal.ToString("N2");
            tax = .075 * subTotal;
            taxTextBox.Text = tax.ToString("N2");
            total = subTotal + tax;
            totalTextBox.Text = total.ToString("N2");
        }

        private void dessertComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var price = getPrice(dessertComboBox.SelectedIndex, "dessert");
            _items.Add(dessertComboBox.Text + "\t" + price.ToString("C2"));
            receiptListBox.DataSource = null;
            receiptListBox.DataSource = _items;
            subTotal += price;
            subtotalTextBox.Text = subTotal.ToString("N2");
            tax = .075 * subTotal;
            taxTextBox.Text = tax.ToString("N2");
            total = subTotal + tax;
            totalTextBox.Text = total.ToString("N2");
        }

        private void mainCourseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var price = getPrice(mainCourseComboBox.SelectedIndex, "mainCourse");
            _items.Add(mainCourseComboBox.Text + "\t" + price.ToString("C2"));
            receiptListBox.DataSource = null;
            receiptListBox.DataSource = _items;
            subTotal += price;
            subtotalTextBox.Text = subTotal.ToString("N2");
            tax = .075 * subTotal;
            taxTextBox.Text = tax.ToString("N2");
            total = subTotal + tax;
            totalTextBox.Text = total.ToString("N2");
        }

        public double getPrice(int indexNum, string itemType)
        {
            double price = 0.0;
            if (itemType == "beverage")
            {
                switch (indexNum)
                {
                    case 0:
                        price = 1.95;
                        break;
                    case 1:
                        price = 1.50;
                        break;
                    case 2:
                        price = 1.25;
                        break;
                    case 3:
                        price = 2.50;
                        break;
                    case 4:
                        price = 1.50;
                        break;
                }
            }
            else if (itemType == "appetizer")
            {
                switch (indexNum)
                {
                    case 0:
                        price = 8.95;
                        break;
                    case 1:
                        price = 3.95;
                        break;
                    case 2:
                        price = 7.95;
                        break;
                    case 3:
                        price = 5.95;
                        break;
                }
            }
            else if (itemType == "dessert")
            {
                switch (indexNum)
                {
                    case 0:
                        price = 5.95;
                        break;
                    case 1:
                        price = 2.95;
                        break;
                    case 2:
                        price = 4.95;
                        break;
                }
            }
            else
            {
                switch (indexNum)
                {
                    case 0:
                        price = 11.95;
                        break;
                    case 1:
                        price = 19.95;
                        break;
                    case 2:
                        price = 18.95;
                        break;
                    case 3:
                        price = 15.95;
                        break;
                    case 4:
                        price = 17.95;
                        break;
                }
            }

            return price;
        }

        private void clearBillButton_Click(object sender, EventArgs e)
        {
            subTotal = 0.0;
            tax = 0.0;
            total = 0.0;
            _items.Clear();
            receiptListBox.DataSource = null;
            receiptListBox.DataSource = _items;
            subtotalTextBox.Text = subTotal.ToString("N2");
            taxTextBox.Text = tax.ToString("N2");
            totalTextBox.Text = total.ToString("N2");
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = receiptListBox.SelectedIndex;
            string parseItem = _items.ElementAt(selectedIndex);
            string[] words = parseItem.Split(Convert.ToChar("$"));
            subTotal -= Convert.ToDouble(words[1]);
            subtotalTextBox.Text = subTotal.ToString("N2");
            tax = .075 * subTotal;
            taxTextBox.Text = tax.ToString("N2");
            total = subTotal + tax;
            totalTextBox.Text = total.ToString("N2");
            _items.RemoveAt(selectedIndex);
            receiptListBox.DataSource = null;
            receiptListBox.DataSource = _items;
        }

        private void receiptListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
