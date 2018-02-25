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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Delopgave_3
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

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            Agents agents = (Agents)this.FindResource("agents");
            agents.Add(new Agent(null, "New Agent", null, null, null));
            lstAgents.SelectedIndex = lstAgents.Items.Count - 1;
            tbxId.Focus();
        }

        private void btnLeft_Click_1(object sender, RoutedEventArgs e)
        {
            if (--lstAgents.SelectedIndex == -1)
                lstAgents.SelectedIndex = lstAgents.Items.Count - 1;
            else if (lstAgents.SelectedIndex != 0)
                lstAgents.SelectedIndex--;
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            if (++lstAgents.SelectedIndex == lstAgents.Items.Count)
                lstAgents.SelectedIndex = 0;
            else if (lstAgents.SelectedIndex < lstAgents.Items.Count - 1)
                lstAgents.SelectedIndex++;
        }
    }
}
