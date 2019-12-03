using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfApp1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value, 
            [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string GetName([CallerMemberName] string foo = null) => foo;

        private string _Text;
        public string Text
        {
            get => _Text;
            set => SetProperty(ref _Text, value);
        }

        private Person _SelectedPerson;
        public Person SelectedPerson
        {
            get => _SelectedPerson;
            set => SetProperty(ref _SelectedPerson, value);
        }

        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();

        public ICommand ChangeNameCommand { get; }

        public ICommand AddPersonCommand { get; }

        public MainWindowViewModel()
        {
            Text = "Hello World";
            ChangeNameCommand = new Command(OnChangeName);
            AddPersonCommand = new Command(OnAddPerson);

            People.Add(new Person("Kevin", "Bost"));
            People.Add(new Person("Mark", "Mc"));

            SelectedPerson = People.First();
        }

        private void OnAddPerson()
        {
            People.Add(new Person("Foo", $"Bar {People.Count}"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(People)));
        }

        private void OnChangeName()
        {
            Text = "Kevin";
        }
    }
}
