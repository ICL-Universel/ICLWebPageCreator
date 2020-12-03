using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace ICLWebPageCreator
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Dictionary<string, string> contenu = new Dictionary<string, string>();
        static int i;
        static int j;
        static int m;
        public MainWindow()
        {
            InitializeComponent();
            if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Styles"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Styles");
            }
            i = 1;
            j = 1;
            m = 1;
        }

        void Copier_Feuille_de_style(string style)
        {
            string Original = AppDomain.CurrentDomain.BaseDirectory + "\\Styles\\" + style;
            string Copie = AppDomain.CurrentDomain.BaseDirectory + "\\Apercus\\" + Fenetre_titre_de_page.titre_page + "\\style.css";
            if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Apercus\\" + Fenetre_titre_de_page.titre_page))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Apercus\\" + Fenetre_titre_de_page.titre_page);
            }
            File.Copy(Original, Copie, true);
        }

        void Contenu(StreamWriter streamWriter)
        {
            Border border = (Border)stack_conteneur.Children[0];
            StackPanel stack_apercu = (StackPanel)border.Child;

            Border cadre_du_menu = (Border)stack_apercu.Children[0];
            StackPanel stack_barre_menu = (StackPanel)cadre_du_menu.Child;

            UIElementCollection uIElement = (UIElementCollection)stack_apercu.Children;
            UIElementCollection uIElement_barre_menu = (UIElementCollection)stack_barre_menu.Children;

            foreach (ComboBox comboBox in uIElement_barre_menu)
            {

            }

            foreach (TextBox textBox in uIElement)
            {
                if (textBox.FontWeight == FontWeights.Bold)
                {
                    streamWriter.WriteLine("<h1>" + textBox.Text + "</h1>");
                }
                else
                {
                    streamWriter.WriteLine("<p>" + textBox.Text + "</p>");
                }
            }
        }

        void Head(StreamWriter streamWriter, string titre)
        {
            streamWriter.WriteLine("<head>");
            streamWriter.WriteLine("<meta charset=\"UTF-8\"/>");
            streamWriter.WriteLine("<meta name=\"viewport\" content=\"width = device-width, initial - scale = 1.0\"/>");
            streamWriter.WriteLine("<title>" + Fenetre_titre_de_page.titre_page + "</title>");
            streamWriter.WriteLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"style.css\"/>");
            streamWriter.WriteLine("</head>");
        }

        void Body(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("<body>");
            Contenu(streamWriter);
            streamWriter.WriteLine("</body>");
        }

        void Creer_HTML()
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Apercus\\" + Fenetre_titre_de_page.titre_page);
            StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Apercus\\"+Fenetre_titre_de_page.titre_page+"\\index.html");
            streamWriter.WriteLine("<!DOCTYPE html>");
            streamWriter.WriteLine("<html>");
            Head(streamWriter, "essai");
            Body(streamWriter);
            streamWriter.WriteLine("</html>");
            streamWriter.Close();
        }

        

        void Creer_apercu()
        {
            Border border_apercu = new Border();
            border_apercu.Background = Brushes.White;
            border_apercu.Width = 1200;
            border_apercu.MinHeight = 1000;
            border_apercu.BorderBrush = Brushes.DarkGray;
            border_apercu.BorderThickness = new Thickness(2);
            border_apercu.Margin = new Thickness(0, 20, 0, 20);

            StackPanel stack_apercu = new StackPanel();
            border_apercu.Child = stack_apercu;

            stack_conteneur.Children.Add(border_apercu);

        }

        void Creer_apercu_paragraphe(int p)
        {
            Border border = (Border)stack_conteneur.Children[0];
            StackPanel stack_apercu = (StackPanel)border.Child;

            TextBox apercu_titre_paragraphe = new TextBox();
            apercu_titre_paragraphe.FontWeight = FontWeights.Bold;
            apercu_titre_paragraphe.FontSize = 20;
            apercu_titre_paragraphe.Text = "Titre du paragraphe " + p;

            TextBox apercu_corps_paragraphe = new TextBox();
            apercu_corps_paragraphe.Text = "Corps du paragraphe " + p;

            stack_apercu.Children.Add(apercu_titre_paragraphe);
            stack_apercu.Children.Add(apercu_corps_paragraphe);

        }

        void Creer_apercu_paragraphe_sans_titre(int p)
        {
            Border border = (Border)stack_conteneur.Children[0];
            StackPanel stack_apercu = (StackPanel)border.Child;
            
            TextBox apercu_corps_paragraphe = new TextBox();
            apercu_corps_paragraphe.Text = "Corps du paragraphe " + p;

            
            stack_apercu.Children.Add(apercu_corps_paragraphe);

        }

        void Creer_apercu_barre_de_menu()
        {
            Border border = (Border)stack_conteneur.Children[0];
            StackPanel stack_apercu = (StackPanel)border.Child;

            Border cadre_du_menu = new Border();
            cadre_du_menu.BorderThickness = new Thickness(1);
            cadre_du_menu.BorderBrush = Brushes.Gray;

            StackPanel stack_barre_menu = new StackPanel();
            stack_barre_menu.Orientation = Orientation.Horizontal;
            stack_barre_menu.HorizontalAlignment = HorizontalAlignment.Stretch;
            stack_barre_menu.Height = 25;

           

            cadre_du_menu.Child = stack_barre_menu;


            stack_apercu.Children.Add(cadre_du_menu);
        }

        void Ajouter_menu()
        {            
            Window window1 = new Fenetre_intitule_du_menu();
            window1.ShowDialog();
            if (Fenetre_intitule_du_menu.str_intitulé != "")
            {
                Border border = (Border)stack_conteneur.Children[0];
                StackPanel stack_apercu = (StackPanel)border.Child;

                Border cadre_du_menu = (Border)stack_apercu.Children[0];
                StackPanel stack_barre_menu = (StackPanel)cadre_du_menu.Child;

                ComboBox menu = new ComboBox();
                List<string> liste = new List<string> { Fenetre_intitule_du_menu.str_intitulé, "Ajouter un sous-menu" };
                menu.ItemsSource = liste;
                menu.SelectedIndex = 0;
                menu.IsEditable = true;
                menu.SelectionChanged += ((e, EventArgs) =>
                {
                    if (menu.SelectedItem != null)
                    {
                        if (menu.SelectedItem.ToString() == "Ajouter un sous-menu")
                        {
                            Window window = new Fenetre_ajouter_sous_menu();
                            window.ShowDialog();
                            if (Fenetre_ajouter_sous_menu.str_intitulé != "")
                            {
                                Ajouter_sous_menu(menu, stack_barre_menu, liste);

                            }
                        }
                        
                    }
                });
                menu.MouseLeftButtonUp += ((e, EventArgs) =>
                {
                    if (menu.Text != "")
                    {
                        List<string> _liste = (List<string>)menu.ItemsSource;
                        Window window = new Fenetre_gerer_liens(menu.Text,_liste);
                        window.ShowDialog();
                    }
                });
                stack_barre_menu.Children.Add(menu);
                m++;
            }
            
        }

        void Ajouter_sous_menu(ComboBox menu,StackPanel stack_barre_menu, List<string> liste)
        {
            //int position_du_combobox = stack_barre_menu.Children.IndexOf(menu);
            stack_barre_menu.Children.Remove(menu);
            liste.Remove("Ajouter un sous-menu");
            liste.Add(Fenetre_ajouter_sous_menu.str_intitulé);
            liste.Add("Ajouter un sous-menu");
            ComboBox menu2 = new ComboBox();
            menu2.ItemsSource = liste;
            menu = menu2;
            menu.SelectedIndex = 0;
            menu.IsDropDownOpen = true;
            menu.IsEditable = true;
            menu.SelectionChanged += ((e, EventArgs) =>
            {
                if (menu.SelectedItem != null)
                {
                    if (menu.SelectedItem.ToString() == "Ajouter un sous-menu")
                    {
                        Window window = new Fenetre_ajouter_sous_menu();
                        window.ShowDialog();
                        if (Fenetre_ajouter_sous_menu.str_intitulé != "")
                        {
                            Ajouter_sous_menu(menu, stack_barre_menu, liste);

                        }
                    }
                }
            });
            menu.MouseLeftButtonUp += ((e, EventArgs) =>
            {
                if (menu.Text != "")
                {
                    List<string> _liste = (List<string>)menu.ItemsSource;
                    Window window = new Fenetre_gerer_liens(menu.Text, _liste);
                    window.ShowDialog();
                }
            });
            stack_barre_menu.Children.Add(menu);
            //stack_barre_menu.Children[position_du_combobox] = menu;
        }

        void Importer_image()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                /*{
                    Uri fileUri = new Uri(openFileDialog.FileName);
                    image.Source = new BitmapImage(fileUri);
                    image_miniature = new Image { Source = new BitmapImage(fileUri), Height = 50, Width = 50, VerticalAlignment = VerticalAlignment.Center, Stretch = Stretch.Fill, Margin = new Thickness(5) };
                    stack.Children.Add(image_miniature);
                    Photos.Add(openFileDialog.FileName.ToString());
                    localisation.Text = openFileDialog.FileName.ToString();
                    if (image.Source != null)
                    {
                        //assistant.Message("Cliquez à présent sur le bouton, enregistrer.");
                    }
                }*/
            }
        }

        /*void Inserrer_paragraphe(StackPanel stack)
        {
            StackPanel stack_0 = new StackPanel();
            stack_0.Background = Brushes.LightYellow;
            stack_0.VerticalAlignment = VerticalAlignment.Top;
            stack_0.Margin = new Thickness(5);

            Label label0 = new Label();
            label0.Margin = new Thickness(5);
            label0.Content = "Paragraphe " + j;
            label0.HorizontalAlignment = HorizontalAlignment.Center;
            label0.FontWeight = FontWeights.Bold;

            Label titre_paragraphe = new Label();
            titre_paragraphe.Margin = new Thickness(5);
            titre_paragraphe.Content = "Titre du paragraphe";
            TextBox textBox_titre_paragraphe = new TextBox();
            textBox_titre_paragraphe.Margin = new Thickness(5);
            

            Label corps_paragraphe = new Label();
            corps_paragraphe.Margin = new Thickness(5);
            corps_paragraphe.Content = "Corps du paragraphe";
            TextBox textBox_corps_paragraphe = new TextBox();
            textBox_corps_paragraphe.Margin = new Thickness(5);

            Button button_inserer_image = new Button();
            button_inserer_image.Content = "Inserrer une image";
            button_inserer_image.Margin = new Thickness(5);
            button_inserer_image.Click += ((e, EventArgs) => { Importer_image(); });

            stack_0.Children.Add(label0);
            stack_0.Children.Add(titre_paragraphe);
            stack_0.Children.Add(textBox_titre_paragraphe);
            stack_0.Children.Add(corps_paragraphe);
            stack_0.Children.Add(textBox_corps_paragraphe);
            stack_0.Children.Add(button_inserer_image);

            stack.Children.Add(stack_0);
            Creer_apercu_paragraphe(j);
            j++;
            
        }*/

        void Nouveau()
        {
            /*RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = GridLength.Auto;
            grid.RowDefinitions.Add(gridRow1);
            

            StackPanel stack = new StackPanel();
            stack.Background = Brushes.Yellow;
            stack.VerticalAlignment = VerticalAlignment.Top;
            stack.Margin = new Thickness(5);

            Label label0 = new Label();
            label0.Margin = new Thickness(5);
            label0.Content = "Page " + i;
            label0.HorizontalAlignment = HorizontalAlignment.Center;
            label0.FontWeight = FontWeights.Bold;

            Label titre_page = new Label();
            titre_page.Margin = new Thickness(5);
            titre_page.Content = "Titre de la page";
            TextBox textBox_titre_page = new TextBox();
            textBox_titre_page.Margin = new Thickness(5);

            StackPanel stack_paragraphes = new StackPanel();            
            stack_paragraphes.VerticalAlignment = VerticalAlignment.Top;
            stack_paragraphes.Margin = new Thickness(5);

            Button button_inserer_paragraphe = new Button();
            button_inserer_paragraphe.Content = "Inserrer un paragraphe";
            button_inserer_paragraphe.Margin= new Thickness(5);            
            button_inserer_paragraphe.Click += ((e, EventArgs) => { Inserrer_paragraphe(stack_paragraphes); });
            stack_paragraphes.Children.Add(button_inserer_paragraphe);

            

            stack.Children.Add(label0);
            stack.Children.Add(titre_page);
            stack.Children.Add(textBox_titre_page);
            stack.Children.Add(stack_paragraphes);
            

            Grid.SetRow(stack, i);
            Grid.SetColumn(stack, 0);

            grid.Children.Add(stack);
            i++;*/
            Creer_apercu();

        }

        

        private void menu_apercu_Click(object sender, RoutedEventArgs e)
        {
            Creer_HTML();
            Process.Start(@"cmd.exe", @"/C" + AppDomain.CurrentDomain.BaseDirectory + "\\Apercus\\index.html");
        }

        
        private void page_vierge_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Fenetre_titre_de_page();
            window.ShowDialog();
            if (Fenetre_titre_de_page.titre_page != "")
            {
                Nouveau();
            }
            
        }

        private void paragraphe_titre_Click(object sender, RoutedEventArgs e)
        {
            Creer_apercu_paragraphe(j);
            j++;
        }

        private void paragraphe_sans_titre_Click(object sender, RoutedEventArgs e)
        {
            Creer_apercu_paragraphe_sans_titre(j);
            j++;
        }

        private void afficher_apercu_Click(object sender, RoutedEventArgs e)
        {
            Creer_HTML();
            //Process.Start(@"cmd.exe", @"/C" + AppDomain.CurrentDomain.BaseDirectory + "\\Apercus\\index.html");
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Apercus\\" + Fenetre_titre_de_page.titre_page + "\\index.html");
            proc.Start();
        }

        private void theme1_Click(object sender, RoutedEventArgs e)
        {
            Copier_Feuille_de_style("style1.css");
            afficher_apercu_Click(sender, e);
        }

        private void theme2_Click(object sender, RoutedEventArgs e)
        {
            Copier_Feuille_de_style("style2.css");
            afficher_apercu_Click(sender, e);
        }

        private void ajouter_barre_menu_Click(object sender, RoutedEventArgs e)
        {
            Creer_apercu_barre_de_menu();
        }

        private void ajouter_menu_Click(object sender, RoutedEventArgs e)
        {
            Ajouter_menu();
        }
    }
}
