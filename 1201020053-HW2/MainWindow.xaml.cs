using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1201020053_HW2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();

        }

        #endregion


        public void BaseConvert(string convertString,string comboBase,string comboNewBase)

        {
            switch(comboBase)

            {
                case "Binary":
                    tblResult.Text = BinToAny(convertString, comboNewBase).ToString();
                    tblResult.Visibility = Visibility.Visible;
                    tblResultIs.Visibility = Visibility.Visible;
                    break;

            }
            

        }

      
        // Binary to Decimal,Octal and Hex converter function
        public double BinToAny(string convertString, string toBase)
        {


            char[] characters = convertString.ToCharArray();

            foreach (var c in characters)
            {
                if (c != '0' && c != '1')
                {
                    MessageBox.Show("Binary must be 1 or 0");
                    return 0;
                }

            }


            Array.Reverse(characters);

            double result = 0,value=0;

            switch (toBase)
            {
                case "Binary":
                    return Int32.Parse(convertString);

                case "Octal":

                    var numbers = new double[characters.Length];
                    string a=string.Empty;
                
                    Char[][] newChar = characters
                                        .Select((s, i) => new { Value = s, Index = i })
                                        .GroupBy(x => x.Index / 3)
                                        .Select(grp => grp.Select(x => x.Value).ToArray())
                                        .ToArray();

                    for (int i = 0; i < newChar.Length; i++)
                    {
                        value = 0;
                        result = 0;

                        foreach (var item in newChar[i])
                        {
                            result += Int32.Parse(item.ToString()) * Math.Pow(2, value);
                            value++;
                        }

                        a += result.ToString();

                    }

                    char[] charArray = a.ToCharArray();
                    Array.Reverse(charArray);
                    a = new string(charArray);
                    
                    return Int32.Parse(a);


                case "Decimal":
                  
                    foreach (char c in characters)
                    {

                        result += Int32.Parse(c.ToString()) * Math.Pow(2, value);
                        value++;
                    }

                    return result;

                case "Hexadecimal":

                    var numbers1 = new double[characters.Length];
                    string b = string.Empty;

                    Char[][] newChar1 = characters
                                        .Select((s, i) => new { Value = s, Index = i })
                                        .GroupBy(x => x.Index / 4)
                                        .Select(grp => grp.Select(x => x.Value).ToArray())
                                        .ToArray();

                    for (int i = 0; i < newChar1.Length; i++)
                    {
                        value = 0;
                        result = 0;

                        foreach (var item in newChar1[i])
                        {
                            result += Int32.Parse(item.ToString()) * Math.Pow(2, value);
                            value++;
                        }

                        b += result.ToString();

                    }

                    char[] charArray1 = b.ToCharArray();
                    Array.Reverse(charArray1);
                    a = new string(charArray1);

                    return Int32.Parse(b);

                default:
                    return 0;
            }
       
        }


        /// <summary>
        /// Handle some button events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {          
            BaseConvert(tbxConvert.Text, cmbFromBase.Text, cmbToBase.Text);
        }




    }
}
