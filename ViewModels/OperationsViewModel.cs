using AccountingTestWPF.Data;
using AccountingTestWPF.Internal;
using AccountingTestWPF.Models;
using AccountingTestWPF.Mvvm;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;

namespace AccountingTestWPF.ViewModels
{
    public class OperationsViewModel : BaseViewModel
    {
        #region private fields

        private ObservableCollection<Operation> _operations;
        private Category _selectedCategory;
        private Recipient _selectedRecipient;
        private bool _isIncome;
        private bool _isAuthAdmin;
        private string _note;
        private decimal _sum;

        #endregion

        public List<Category> CategoryList { get; set; }

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set => SetProperty(ref _selectedCategory, value);
        }

        public List<Recipient> RecipientList { get; set; }

        public Recipient SelectedRecipient
        {
            get => _selectedRecipient;
            set => SetProperty(ref _selectedRecipient, value);
        }

        public ObservableCollection<Operation> Operations
        {
            get => _operations;
            set => SetProperty(ref _operations, value);
        }

        public bool IsIncome
        {
            get => _isIncome;
            set => SetProperty(ref _isIncome, value);
        }

        public bool IsAuthAdmin
        {
            get => _isAuthAdmin;
            set => SetProperty(ref _isAuthAdmin, value);
        }

        [MaxLength(100, ErrorMessage = "Максимальное число знаков - 100.")]
        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }
        
        public decimal Sum
        {
            get => _sum;
            set => SetProperty(ref _sum, value);
        }

        public ICommand AddOperationCommand { get; private set; }

        public OperationsViewModel(IEventAggregator ea) : base(ea)
        {
            LoadData();
            IsAuthAdmin = AuthUser.IsAdmin;

            if (CategoryList.Count != 0) SelectedCategory = CategoryList.FirstOrDefault();
            if (RecipientList.Count != 0) SelectedRecipient = RecipientList.FirstOrDefault();

            AddOperationCommand = new RelayCommand(OnAddOperation);
        }

        private void LoadData()
        {
            Operations = new ObservableCollection<Operation>(DataAccess.GetAllOperations());
            CategoryList = DataAccess.GetAllCategories();
            RecipientList = DataAccess.GetAllRecipients();
        }

        private void OnAddOperation()
        {
            DataAccess.AddOperation(AuthUser.Id, SelectedCategory.Id, SelectedRecipient?.Id, IsIncome, Sum, Note);
            LoadData();
        }

    }
}
