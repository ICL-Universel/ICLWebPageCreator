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
using System.Windows.Shapes;

namespace ICLWebPageCreator
{
    /// <summary>
    /// Logique d'interaction pour Fenetre_gerer_liens.xaml
    /// </summary>
    public partial class Fenetre_gerer_liens : Window
    {
        //static string a;
        //Dictionary<string, string> liens_barre_de_menu;
        public Fenetre_gerer_liens(string intitule_menu,List<string> _liste)
        {
            InitializeComponent();
            //Intitulé_menu.Text = intitule_menu;
            Charger_Sous_menus(_liste);
            Liens();
        }

        void Charger_Sous_menus(List<string> _liste)
        {
            if (_liste.Count != 0)
            {
                Donnees.liens_barre_de_menu = new Dictionary<string, string>();
                for (int i = 0; i < _liste.Count-1; i++)
                {
                    RowDefinition gridRow1 = new RowDefinition();
                    gridRow1.Height = GridLength.Auto;
                    grid.RowDefinitions.Add(gridRow1);

                    RowDefinition gridRow2 = new RowDefinition();
                    gridRow2.Height = GridLength.Auto;
                    grid.RowDefinitions.Add(gridRow2);


                    Label label1 = new Label();
                    if (i == 0)
                    {
                        label1.Content = "Intitulé du menu";
                    }
                    else if(i>0)
                    {
                        label1.Content = "Intitulé du sous-menu " + i;
                    }
                    label1.Margin = new Thickness(5, 5, 5, 0);
                    label1.FontWeight = FontWeights.Bold;

                    Label label2 = new Label();
                    label2.Content = "Lien vers";
                    label2.Margin = new Thickness(5, 5, 5, 0);
                    label2.FontWeight = FontWeights.Bold;

                    TextBox textBox1 = new TextBox();
                    textBox1.Margin = new Thickness(5, 0, 5, 5);
                    textBox1.Text = _liste[i];

                    TextBox textBox2 = new TextBox();
                    textBox2.Margin = new Thickness(5, 0, 5, 5);

                    Grid.SetColumn(label1, 0);
                    Grid.SetRow(label1, (2 * i));                    

                    Grid.SetColumn(label2, 1);
                    Grid.SetRow(label2, (2 * i));

                    Grid.SetColumn(textBox1, 0);
                    Grid.SetRow(textBox1, 1 +(2 * i));

                    Grid.SetColumn(textBox2, 1);
                    Grid.SetRow(textBox2, 1 + (2 * i));

                    grid.Children.Add(label1);                    
                    grid.Children.Add(label2);
                    grid.Children.Add(textBox1);
                    grid.Children.Add(textBox2);

                    Donnees.liens_barre_de_menu[textBox1.Text] = textBox2.Text;

                }
            }
        }

        void Liens()
        {
            string a = "";
            foreach(KeyValuePair<string, string> g in Donnees.liens_barre_de_menu)
            {
                a = a + "\n" + g.Key + ", " + g.Value;
            }
            MessageBox.Show(a);
        }

        private void bouton_enregistrer_Click(object sender, RoutedEventArgs e)
        {
            //string a = "";
            int Nbre_de_lignes_de_grid = grid.Children.Count / 2;            
            for(int i = 0; i < Nbre_de_lignes_de_grid/2; i++)
            {
                TextBox textBox1 = (TextBox)grid.Children[2 + 4 * i];
                TextBox textBox2 = (TextBox)grid.Children[(2 + 4 * i) + 1];
                Donnees.liens_barre_de_menu[textBox1.Text] = textBox2.Text;
                //a=a+"\n"+ liens[textBox1.Text]+", "+ textBox2.Text;
            }
            Close();
            //MessageBox.Show(a);
        }
    }
}
