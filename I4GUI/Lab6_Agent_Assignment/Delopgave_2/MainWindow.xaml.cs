using System.Windows;


namespace Delopgave_2
{
    public partial class MainWindow : Window
    {
        Agents _agents;

        public MainWindow()
        {
            InitializeComponent();
            _agents = new Agents();
            _agents.Add(new Agent("001", "Tom", "Street", "Guns", "Die"));
            _agents.Add(new Agent("002", "Anni", "Street", "Fly", "Die"));
            _agents.Add(new Agent("003", "Nian", "Street", "Swim", "Win In Life"));
            DataContext = _agents;
        }
    }
}
