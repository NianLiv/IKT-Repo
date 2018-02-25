using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace Delopgave_4
{
    public class Agents : ObservableCollection<Agent>, INotifyPropertyChanged
    {
        ICommand _addCommand;
        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(AddAgent)); }
        }

        private void AddAgent()
        {
            Add(new Agent(null, "New Agent", null, null, null));
            CurrentIndex = Count - 1;
        }

        private ICommand _removeCommand;
        public ICommand RemoveCommand
        {
            get { return _removeCommand ?? (_removeCommand = new RelayCommand(RemoveAgent));}
        }

        private void RemoveAgent()
        {
            RemoveAt(CurrentIndex);
        }

        private ICommand _leftCommand;
        public ICommand LeftCommand
        {
            get { return _leftCommand ?? (_leftCommand = new RelayCommand(LeftAgent)); }
        }

        private void LeftAgent()
        {
            currentIndex = currentIndex -1;
        }

        ICommand _nextCommand;
        public ICommand NextCommand
        {
            get { return _nextCommand ?? (_nextCommand = new RelayCommand(NextAgent)); }
        }

        private void NextAgent()
        {
            if (currentIndex == Count-1) currentIndex = -1;
            ++CurrentIndex;
            
        }

        #region Properties

        int currentIndex = -1;

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (currentIndex != value)
                {
                    currentIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
