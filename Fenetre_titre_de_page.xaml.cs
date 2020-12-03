using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Logique d'interaction pour Fenetre_titre_de_page.xaml
    /// </summary>
    public partial class Fenetre_titre_de_page : Window
    {
        public static string titre_page { get; set; }
        public Fenetre_titre_de_page()
        {
            InitializeComponent();
            titre_page = "";
        }

        
        private void bouton_ok_Click(object sender, RoutedEventArgs e)
        {
            if (titre.Text != "")
            {
                titre_page = titre.Text;
                Close();
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }
    }
}
