using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for Change.xaml
    /// </summary>
    public partial class Change : Window
    {
        int b;
        OpenFileDialog window = new OpenFileDialog();

        Color r;
        int kolor = 7;
        public Change(int before)
        {
            InitializeComponent();

            b = before;

            textbox_Name.Text = MainWindow.Piano[b].Name;
            textbox_Production.Text = MainWindow.Piano[b].Production.ToString();
            logo_place.Source = new BitmapImage(new Uri(MainWindow.Piano[b].Logo));
            datepicker.SelectedDate = MainWindow.Piano[b].Founded;

            MainWindow.Piano[b].Detailed = MainWindow.Piano[b].Name + ".rtf";



            FileStream fileStream = new FileStream(MainWindow.Piano[b].Detailed, FileMode.Open, FileAccess.ReadWrite);
            TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
            range.Load(fileStream, DataFormats.Rtf);
            fileStream.Close();


            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            cmbFontColor.ItemsSource = typeof(Colors).GetProperties();


            rtbEditor.Foreground = Brushes.Black;
            cmbFontColor.SelectedItem = typeof(Colors).GetProperties()[7];



            textBox.Text = "Word Count: 0";
            lblCursorPosition.Text = "Line: " + "1" + " Column: " + "1";
        }

        private bool Validation()
        {
            bool end = true;

            if (textbox_Name.Text.Trim() == "")
            {
                label_error_name.Content = "Required!";
                textbox_Name.BorderBrush = Brushes.Yellow;
                end = false;
            }
            else
            {
                label_error_name.Content = "";
                textbox_Name.BorderBrush = Brushes.SlateGray;
            }

            if (textbox_Production.Text.Trim() == "")
            {
                label_error_production.Content = "Required!";
                textbox_Production.BorderBrush = Brushes.Yellow;
                end = false;
            }
            else
            {
                label_error_production.Content = "";
                textbox_Production.BorderBrush = Brushes.SlateGray;
            }                       

            if (datepicker.SelectedDate == null)
            {
                label_error_date.Content = "Required!";
                datepicker.BorderBrush = Brushes.Red;
                end = false;
            }
            else
            {
                label_error_date.Content = "";
                datepicker.BorderBrush = Brushes.SlateGray;


                try
                {

                    DateTime now = DateTime.Now;


                    DateTime unesen_datum = datepicker.SelectedDate.Value.Date;

                    int rezultat = DateTime.Compare(now, unesen_datum);

                    if (rezultat >= 0)
                    {

                    }
                    else
                    {
                        label_error_date.Content = "This date hasn't passed yet!";
                        datepicker.BorderBrush = Brushes.Red;
                        end = false;

                    }


                }
                catch (Exception e)
                {
                    // .......
                    end = false;

                }


            }

            //RICHTEXTBOX VALIDACIJA
            //if()

            return end;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Click_save(object sender, RoutedEventArgs e)
        {
            if (Validation() == true)
            {
                Piano p = new Piano();
                p.Name = textbox_Name.Text;
                p.Production = int.Parse(textbox_Production.Text);

                p.Founded = datepicker.SelectedDate.Value.Date;

                p.Logo = logo_place.Source.ToString();

                p.Detailed = p.Name + ".rtf";
                FileStream fileStream = new FileStream(p.Detailed, FileMode.Create);
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
                fileStream.Close();

                MainWindow.Piano[b] = p;
                this.Close();
            }
            else
            {
                MessageBox.Show("Niste dobro popunili polja!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void Click_logo(object sender, RoutedEventArgs e)
        {
            window.FileName = "";
            window.Title = "Chose logo.";

            // PROMENITI KAD PREMESTIM PROJEKAT...
            window.InitialDirectory = @"Slike\";

            window.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";

            if (window.ShowDialog() == true)
            {
                Uri u = new Uri(window.FileName);
                logo_place.Source = new BitmapImage(u);  // BitmapImage je za dodelu putanje slici 

            }
        }

        private void Click_leave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
            }
        }

              

        private void CmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
            }
            catch
            {
                cmbFontSize.Text = "b";
            }
        }


        private void CmbFontColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontColor.SelectedItem != null)
            {
                kolor = cmbFontColor.SelectedIndex;
                var selectedItem = (PropertyInfo)cmbFontColor.SelectedItem;
                var color = (Color)selectedItem.GetValue(null, null);

                rtbEditor.Selection.ApplyPropertyValue(Inline.ForegroundProperty, color.ToString());
                r = (Color)System.Windows.Media.ColorConverter.ConvertFromString(color.ToString());
            }
        }

        private void RtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // toggle buttons
            object temp = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));

            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

            temp = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            //comboboxs
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;


            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.Text = temp.ToString();

            temp = rtbEditor.Selection.GetPropertyValue(Inline.ForegroundProperty);

            var hexcolor = ((SolidColorBrush)temp).Color.ToString();
            SolidColorBrush sol = (SolidColorBrush)temp;



            

            string s = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd).Text;
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            string[] pom = s.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            textBox.Text = "Word Count: " + pom.Length.ToString();

            TextPointer tp1 = rtbEditor.Selection.Start.GetLineStartPosition(0);
            TextPointer tp2 = rtbEditor.Selection.Start;

            int column = tp1.GetOffsetToPosition(tp2) + 1;

            int someBigNumber = int.MaxValue;
            int lineMoved, currentLineNumber;
            rtbEditor.Selection.Start.GetLineStartPosition(-someBigNumber, out lineMoved);
            currentLineNumber = -lineMoved + 1;

            lblCursorPosition.Text = "Line: " + currentLineNumber.ToString() + " Column: " + column.ToString();
        }
    }
}

