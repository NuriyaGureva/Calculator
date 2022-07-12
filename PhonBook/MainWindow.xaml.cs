using System;
using System.Data;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();


            foreach(UIElement element in MainView.Children)
            {
                if(element is Button)
                {
                    ((Button)element).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            if (str == "CE")
            {
                var text = textLabel.Text.Trim();

                int plusIndex = text.LastIndexOf('+');
                int minusIndex = text.LastIndexOf('-');
                int divIndex = text.LastIndexOf('/');
                int multIndex = text.LastIndexOf('*');

                var indexes = new int[] { plusIndex, minusIndex, divIndex, multIndex };                
                var maxIndex = indexes.Max()+1;

                var lenght = text.Substring(0, maxIndex);
                textLabel.Text = lenght;
            } 
            else if (str == "C")
            {
                textLabel.Text = " ";

            }           
            else if (str == "<")
            {
                textLabel.Text = textLabel.Text.Remove(textLabel.Text.Length - 1);

            }
            else if (str == "=")
            {
                string? value = new DataTable().Compute(textLabel.Text, null).ToString();
                textLabel.Text = value;
            }                   
            else 
            {
                textLabel.Text += str;          
            }
        }
    }    
}
