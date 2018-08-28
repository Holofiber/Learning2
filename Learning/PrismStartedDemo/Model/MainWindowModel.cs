using System.Collections.ObjectModel;
using System.Linq;
using Prism.Mvvm;

namespace PrismStartedDemo.Model
{
    public class MainWindowModel : BindableBase
    {
        private readonly ObservableCollection<int> myValues = new ObservableCollection<int>();

        public readonly ReadOnlyObservableCollection<int> MyPyblicValue;

        public MainWindowModel()
        {
            MyPyblicValue = new ReadOnlyObservableCollection<int>(myValues);
        }

        public void AddValues(int value)
        {
            myValues.Add(value);
            RaisePropertyChanged("Sum");
        }

        public void RemoveValue(int index)
        {
            if (index >= 0 && index < myValues.Count)
            {
                myValues.RemoveAt(index);
                RaisePropertyChanged("Sum");
            }
        }

        public int Sum => MyPyblicValue.Sum();
    }
}