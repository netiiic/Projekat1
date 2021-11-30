using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Projekat1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
               
        public static BindingList<Piano> Piano { get; set; }
        public MainWindow()
        {
            if (Piano == null) //U slucaju da nista nije ucitano
            {
                Piano = new BindingList<Piano>(); //nova lista pa cemo u nju dodavati
            }
            DataContext = this; //okidac Data Bindinga
            InitializeComponent();
        }

        private void Click_add(object sender, RoutedEventArgs e)
        {
            AddPiano ap = new AddPiano();
            ap.ShowDialog();
        }

        private void Click_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Click_read(object sender, RoutedEventArgs e)
        {            
            Read r = new Read(tablePiano.SelectedIndex);
            r.ShowDialog();
        }
        private void Click_change(object sender, RoutedEventArgs e)
        {
            int i = tablePiano.SelectedIndex;
            Change c = new Change(i);
            c.ShowDialog();
        }
        private void Click_delete(object sender, RoutedEventArgs e)
        {
            
            MainWindow.Piano[tablePiano.SelectedIndex].Detailed = MainWindow.Piano[tablePiano.SelectedIndex].Name + ".rtf";
            File.Delete(MainWindow.Piano[tablePiano.SelectedIndex].Detailed);
            Piano.RemoveAt(tablePiano.SelectedIndex);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        
    }
}
