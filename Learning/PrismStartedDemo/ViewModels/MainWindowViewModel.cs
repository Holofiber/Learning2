using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using PrismStartedDemo.Model;

namespace PrismStartedDemo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        readonly MainWindowModel model = new MainWindowModel();
        public MainWindowViewModel()
        {
            //таким нехитрым способом мы пробрасываем изменившиеся свойства модели во View
            model.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
            AddCommand = new DelegateCommand<string>(str =>
            {
                //проверка на валидность ввода - обязанность VM
                int ival;
                if (int.TryParse(str, out ival)) model.AddValues(ival);
            });
            RemoveCommand = new DelegateCommand<int?>(i =>
            {
                if (i.HasValue) model.RemoveValue(i.Value);
            });
        }
        public DelegateCommand<string> AddCommand { get; }
        public DelegateCommand<int?> RemoveCommand { get; }
        public int Sum => model.Sum;
        public ReadOnlyObservableCollection<int> MyValues => model.MyPyblicValue;
    }
}