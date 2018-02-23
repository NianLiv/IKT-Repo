using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Delopgave_2
{
    public partial class MainWindow : Window
    {
        private List<BabyName> babyCollection;
        private string[,] rankMatrix = new string[11, 10];

        public MainWindow()
        {
            InitializeComponent();
            babyCollection = new List<BabyName>();
            Loaded += new RoutedEventHandler(MainWindowLoaded);

        }

        public void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1900; i < 2010; i += 10) lstDecade.Items.Add(i);
            try
            {
                IEnumerable<string> lines =
                    File.ReadLines(
                        @"C:\Users\nande\source\repos\IKT_Repo\I4GUI\Lab_5_BabyNames\Delopgave_2\05-babynames.txt");
                foreach (var line in lines) babyCollection.Add(new BabyName(line));

                foreach (BabyName name in babyCollection)
                {
                    for (int decade = 1900; decade < 2010; decade += 10)
                    {
                        int rank = name.Rank(decade);
                        int decadeIndex = (decade - 1900) / 10;
                        if (0 < rank && rank < 11)
                            if (rankMatrix[decadeIndex, rank - 1] == null)
                                rankMatrix[decadeIndex, rank - 1] = name.Name;
                            else
                                rankMatrix[decadeIndex, rank - 1] += " and " + name.Name;
                    }
                }
            }
            catch (Exception)
            {
                Application.Current.Shutdown();
            }
        }

        private void LstDecade_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            if (lstDecade.SelectedItem != null)
            {
                int decade = ((int) lstDecade.SelectedItem - 1900) / 10;

                IstDecadeTopNames.Items.Clear();
                for (int i = 1; i < 11; ++i)
                {
                    IstDecadeTopNames.Items.Add(string.Format("{0,2} {1}", i, rankMatrix[decade, i - 1]));
                }
            }
        }
    }
}


