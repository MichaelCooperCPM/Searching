using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KK7___Searching_Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateSearchButton_Click(object sender, EventArgs e)
        {
            LinearCountResultLabel.Text = "";
            int[] array = CreateIntArray();
            LinearSearch(array);
            BinarySearch(array);
        }

        private void CreateSearchCountButton_Click(object sender, EventArgs e)
        {
            BinaryFoundResultLabel.Text = "";
            BinaryPassResultLabel.Text = "";
            int[] array = CreateIntArray();
            LinearSearchCount(array);
        }

        int[] CreateIntArray()
        {
            Random randInt = new Random();

            int arraySize = int.Parse(ArraySizeTextBox.Text);
            int maxInt = int.Parse(MaxIntTextBox.Text);
    
            int[] intArray = new int[arraySize];

            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = randInt.Next(0, maxInt + 1);
            }

            Array.Sort(intArray);

            return intArray;
        }
        
        void LinearSearch(int[] allgrades)
        {
            int pass = 0;
            bool found = false;
            int searchNumber = int.Parse(SearchNumberTextBox.Text);

            while(found == false && pass < allgrades.Length)
            {
                if (allgrades[pass] == searchNumber)
                {
                    found = true;
                }
                pass++;
            }

            if (found == true)
            {
                LinearFoundResultLabel.Text = "Yes";
                LinearPassResultLabel.Text = pass.ToString();
            }
            else
            {
                LinearFoundResultLabel.Text = "No";
                LinearPassResultLabel.Text = pass.ToString();
            }
        }

        void LinearSearchCount(int[] allgrades)
        {
            int pass = 0;
            int count = 0;
            int searchNumber = int.Parse(SearchNumberTextBox.Text);

            while (pass < allgrades.Length)
            {
                if (allgrades[pass] == searchNumber)
                {
                    count++;
                }
                pass++;
            }

            if (count > 0)
            {
                LinearFoundResultLabel.Text = "Yes";
                LinearPassResultLabel.Text = pass.ToString();
                LinearCountResultLabel.Text = count.ToString();
            }
            else
            {
                LinearFoundResultLabel.Text = "No";
                LinearPassResultLabel.Text = pass.ToString();
            }
        }

        void BinarySearch(int[] intArray)
        {
            int low = 0;
            int high = intArray.Length - 1;
            int mid = 0;
            int pass = 0;
            bool found = false;
            int searchNumber = int.Parse(SearchNumberTextBox.Text);

            while (low <= high && found == false)
            {
                pass++;
                mid = (low + high) / 2;
                Console.WriteLine("low = " + low + " mid = " + mid + " high = " + high + " pass = " + pass);
                
                if (searchNumber == intArray[mid])
                {
                    found = true;
                }

                else if(searchNumber < intArray[mid])
                {
                    high = mid - 1;
                }

                else if(searchNumber > intArray[mid])
                {
                    low = mid + 1;
                }
            }

            if (found == true)
            {
                BinaryFoundResultLabel.Text = "Yes";
                BinaryPassResultLabel.Text = pass.ToString();
                Console.WriteLine("Found");
            }
            else
            {
                BinaryFoundResultLabel.Text = "No";
                BinaryPassResultLabel.Text = pass.ToString();
                Console.WriteLine("Not Found");
            }
        }
    }
}