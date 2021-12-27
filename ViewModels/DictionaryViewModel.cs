using AccountingTestWPF.Data;
using AccountingTestWPF.Models;
using AccountingTestWPF.Mvvm;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AccountingTestWPF.ViewModels
{
    public class DictionaryViewModel : BindableBase
    {
        private ObservableCollection<Category> _categories;
        private ObservableCollection<Recipient> _recipients;
        private string _recipientName;
        private string _categoryName;

        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set => SetProperty(ref _categories, value);
        }

        public ObservableCollection<Recipient> Recipients
        {
            get => _recipients;
            set => SetProperty(ref _recipients, value);
        }
        
        public string RecipientName
        {
            get => _recipientName;
            set => SetProperty(ref _recipientName, value);
        }

        public string CategoryName
        {
            get => _categoryName;
            set => SetProperty(ref _categoryName, value);
        }

        public ICommand AddCatCommand { get; private set; }
        public ICommand AddRecCommand { get; private set; }

        public DictionaryViewModel()
        {
            LoadData();

            AddCatCommand = new RelayCommand(OnAddCategory);
            AddRecCommand = new RelayCommand(OnAddRecipient);
        }

        private void LoadData()
        {
            Categories = new ObservableCollection<Category>(DataAccess.GetAllCategories());
            Recipients = new ObservableCollection<Recipient>(DataAccess.GetAllRecipients());
        }

        private void OnAddRecipient()
        {
            DataAccess.AddRecipient(RecipientName);
            LoadData();
            RecipientName = "";
        }

        private void OnAddCategory()
        {
            DataAccess.AddCategory(CategoryName);
            LoadData();
            CategoryName = "";
        }
    }
}
