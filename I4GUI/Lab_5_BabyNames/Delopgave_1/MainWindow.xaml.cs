using System;
using System.IO;
using System.Text;
using System.Windows;

namespace Delopgave_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindowLoaded);
        }

        public void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
                
            
            FileStream fStream = null;
            StreamReader sReader = null;
            try
            {
                fStream =
                    new FileStream(
                        @"C:\Users\nande\source\repos\IKT_Repo\I4GUI\Lab_5_BabyNames\Delopgave_1\05-babynames.txt",
                        FileMode.Open);
                sReader = new StreamReader(fStream, Encoding.Default);

                for (var i = 0; i < 10; i++)
                {
                    IstDecadeTopNames.Items.Add(sReader.ReadLine());
                }
            }
            catch (Exception)
            {
                Application.Current.Shutdown();
            }
            finally
            {
                if (sReader != null)
                    sReader.Close();
                if (fStream != null)
                    fStream.Close();
            }
        }
    }
}
