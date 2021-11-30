using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Projekat1
{
    /// <summary>
    /// Interaction logic for Read.xaml
    /// </summary>
    public partial class Read : Window
    {
        int s;
        public Read(int show)
        {
            s = show;
            InitializeComponent();

            label_show_name.Content = MainWindow.Piano[s].Name;
            label_show_proudction.Content = MainWindow.Piano[s].Production.ToString();
            show_logo.Source = new BitmapImage(new Uri(MainWindow.Piano[s].Logo));
            label_show_founded.Content = MainWindow.Piano[s].Founded;

            MainWindow.Piano[s].Detailed = MainWindow.Piano[s].Name + ".rtf";



            FileStream fileStream = new FileStream(MainWindow.Piano[s].Detailed, FileMode.Open, FileAccess.Read);
            TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
            range.Load(fileStream, DataFormats.Rtf);
            fileStream.Close();

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Click_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
                
    }
}
