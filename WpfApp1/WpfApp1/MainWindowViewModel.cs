using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WpfApp1
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _Text;
        public string Text
        {
            get => _Text;
            set => Set(ref _Text, value);
        }

        private Person _SelectedPerson;
        public Person SelectedPerson
        {
            get => _SelectedPerson;
            set => Set(ref _SelectedPerson, value);
        }

        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();

        public RelayCommand ChangeNameCommand { get; }

        public ICommand AddPersonCommand { get; }
        private Func<DateTime> GetNow { get; }

        private bool CanExecute { get; set; }

        public MainWindowViewModel(Func<DateTime> getNow)
        {
            Text = "Hello World";
            ChangeNameCommand = new RelayCommand(OnChangeName, () => CanExecute);
            AddPersonCommand = new RelayCommand(OnAddPerson);

            var dob = getNow().Subtract(TimeSpan.FromDays(30 * 365));

            People.Add(new Person("Kevin", "Bost", dob));
            People.Add(new Person("Mark", "Mc", dob));

            SelectedPerson = People.First();
            GetNow = getNow ?? throw new ArgumentNullException(nameof(getNow));
        }

        private void OnAddPerson()
        {
            var dob = GetNow().Subtract(TimeSpan.FromDays(30 * 365));
            People.Add(new Person("Foo", $"Bar {People.Count}", dob));
            CanExecute = true;
            ChangeNameCommand.RaiseCanExecuteChanged();
        }

        private void OnChangeName()
        {
            Text = "Kevin";
        }
    }
}
