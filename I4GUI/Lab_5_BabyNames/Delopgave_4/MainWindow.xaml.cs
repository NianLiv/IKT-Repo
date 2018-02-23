using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Delopgave_4
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
            for (int i = 1900; i < 2010; i += 10) lstDecades.Items.Add(i);

            try
            {
                IEnumerable<string> lines =
                    File.ReadLines(
                        @"C:\Users\nande\source\repos\IKT_Repo\I4GUI\Lab_5_BabyNames\Delopgave_3\05-babynames.txt");
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
            if (lstDecades.SelectedItem != null)
            {
                int decade = ((int)lstDecades.SelectedItem - 1900) / 10;

                lstDecadeTopNames.Items.Clear();
                for (int i = 1; i < 11; ++i)
                {
                    lstDecadeTopNames.Items.Add(string.Format("{0,2} {1}", i, rankMatrix[decade, i - 1]));
                }
            }
        }


        private void BtnSearch_OnClick(object sender, RoutedEventArgs e)
        {
            int i;
            for (i = 0; i < babyCollection.Count; ++i)
            {
                if (babyCollection[i].Name == tbxName.Text)
                    break;
            }

            if (i < babyCollection.Count)
            {
                BabyName targetName = babyCollection[i];
                tbxAverageRank.Text = targetName.AverageRank().ToString();
                if (targetName.Trend() > 0)
                    tbxTrend.Text = "More popular";
                else if (targetName.Trend() == 0)
                    tbxTrend.Text = "Inconclusive";
                else
                    tbxTrend.Text = "Less popular";

                lstYearRank.Items.Clear();
                for (int year = 1900; year < 2010; year += 10)
                {
                    lstYearRank.Items.Add(String.Format("{0} \t {1}", year, targetName.Rank(year)));
                }
            }
            else
            {
                tblError.Text = "Name not found.";
                lstYearRank.Items.Clear();
                tbxTrend.Text = "";
                tbxAverageRank.Text = "";
            }


        }

        private void MenuItem_Exit_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Small_OnClick(object sender, RoutedEventArgs e)
        {
            FontSize = 8;
        }

        private void MenuItem_Normal_OnClick(object sender, RoutedEventArgs e)
        {
            FontSize = 12;
        }

        private void MenuItem_Large_OnClick(object sender, RoutedEventArgs e)
        {
            FontSize = 16;
        }

        private void MenuItem_Huge_OnClick(object sender, RoutedEventArgs e)
        {
            FontSize = 18;
        }
    }
}
