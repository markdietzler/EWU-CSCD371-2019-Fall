using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ShoppingList.Models;

namespace ShoppingList.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region classVariables
        
        public event PropertyChangedEventHandler? PropertyChanged;

        private const string _TextBoxDefault = "Enter new item here.";

        private const string _TextBoxError = "You have to type SOMETHING.";               

        private string _Item = "";

        public string Item
        {
            get => _Item;
            set => SetProperty(ref _Item, value);
        }

        private ShoppingListItemModel _Model = null!;

        public ShoppingListItemModel Model
        {
            get => _Model;
            set => SetProperty(ref _Model, value);
        }

        public ObservableCollection<ShoppingListItemModel> Items { get; } = new ObservableCollection<ShoppingListItemModel>();

        public ICommand AddItem { get; }

        #endregion
        public MainWindowViewModel()
        {
            Item = _TextBoxDefault;
            AddItem = new Command(OnAddItem);
            Items.Add(new ShoppingListItemModel("Cereal"));
            Items.Add(new ShoppingListItemModel("Milk"));
            Items.Add(new ShoppingListItemModel("Bacon"));
            Model = Items[0];
        }

        private void OnAddItem()
        {
            if (HasItemBoxChanged())
            {
                Items.Add(new ShoppingListItemModel(Item));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
            } else
            {
                Item = _TextBoxError;
            }

        }

        private void SetProperty<T>(ref T field, T value,
                [CallerMemberName]string propertyName = null) //<- this is an optional parameter so we dont have to pass a value to use the method
        {
            if (!EqualityComparer<T>.Default.Equals(field, value)) //if using custom classes need to implement equals
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool HasItemBoxChanged()
        {
            if (string.IsNullOrEmpty(Item)) {
                return false;
            }
            if (string.IsNullOrWhiteSpace(Item))
            {
                return false;
            }
            if (Item.Contains(_TextBoxDefault))
            {
                return false;
            }
            if(Item.Contains(_TextBoxError))
            {
                return false;
            }
            return true;
        }

    }    
}
