using System.Collections;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {

        static ArrayList airport = new ArrayList();
        static string warning = "Fügen sie zuerst flugzeuge hinzu";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string to_add;

            to_add = Convert.ToString(Input.Text);

            if (!airport.Contains(to_add))
            {
                airport.Add(to_add);

                Output.Text = to_add + " wurde hinzugefügt";
            }
            else
            {
                Output.Text = to_add + " ist bereits vorhanden.";
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (airport.Count != 0)
            {
                if (airport.Contains(Input.Text))
                {
                    airport.Remove(Input.Text);
                    Output.Text = (Input.Text + " wurde entfernt");
                }
                else
                {
                    Output.Text = Input.Text + " ist nicht vorhanden";
                }
            }
            else
            {
                Output.Text = warning;
            }
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            if (airport.Count != 0)
            {
                airport.Sort();

                Output.Text = "Flugzeuge wurden sortiert.";
            }
            else
            {
                Output.Text = warning;
            }
        }

        private void PrintAll_Click(object sender, RoutedEventArgs e)
        {
            int i;

            if (airport.Count != 0)
            {
                string final = "";

                for (i = 0; i < airport.Count; i++)
                {
                    if (i < airport.Count - 1)
                    {
                        final += (airport[i] + ", ");
                    }
                    else
                    {
                        final += airport[i] + ". ";
                    }
                }
                Output.Text = final;
            }
            else
            {
                Output.Text = warning;
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (airport.Count != 0)
            {
                if (airport.Contains(Input.Text))
                {
                    Output.Text = Input.Text + " ist vorhanden";
                }
                else
                {
                    Output.Text = Input.Text + " ist nicht vorhanden";
                }
            }
            else
            {
                Output.Text = warning;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}