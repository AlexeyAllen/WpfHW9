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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfHW9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool isTrue;

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = (sender as ComboBox).SelectedItem.ToString();
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = (sender as ComboBox).SelectedItem.ToString();
            if (textBox != null)
            {
                textBox.FontSize = Convert.ToDouble(fontSize);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontStyle = FontStyles.Normal;
            textBox.TextDecorations = null;
            textBox.FontWeight = FontWeights.Bold;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox.FontWeight = FontWeights.Normal;
            textBox.TextDecorations = null;
            textBox.FontStyle = FontStyles.Italic;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            textBox.FontStyle = FontStyles.Normal;
            textBox.FontWeight = FontWeights.Normal;
            textBox.TextDecorations = TextDecorations.Underline;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (isTrue && textBox != null)
            {
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (isTrue == false && textBox != null)
            {
                textBox.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt| Все файлы(*.*)| *.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt| Все файлы(*.*)| *.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.SafeFileName, textBox.Text);
            }
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            Uri uri1 = new Uri("White.xaml", UriKind.Relative);
            ResourceDictionary resource1 = Application.LoadComponent(uri1) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resource1);
            isTrue = true;
            if (isTrue && textBox!=null)
            {
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (isTrue == false && textBox != null)
            {
                textBox.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            Uri uri2 = new Uri("Dark.xaml", UriKind.Relative);
            ResourceDictionary resource2 = Application.LoadComponent(uri2) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resource2);
            isTrue = false;
            if (isTrue && textBox != null)
            {
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (isTrue == false && textBox != null)
            {
                textBox.Foreground = new SolidColorBrush(Colors.White);
            }
        }

    }
}
