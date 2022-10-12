using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using lab6.Models;

namespace lab6.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
        public FirstViewModel(List<Plan> ItemsAll)
        {
            itemsAll = ItemsAll;
            currentDate = DateTime.Today;
            changeItems();
        }
        public void changeItems()
        {
            items.Clear();
            foreach (var item in itemsAll)
            {
                if (item.Date.Equals(CurrentDate)) items.Add(item);
            }
            ItemsSelected = new ObservableCollection<Plan>(items);
        }

        public ObservableCollection<Plan> itemsSelected;
        public ObservableCollection<Plan> ItemsSelected
        {
            get
            {
                return itemsSelected;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref itemsSelected, value);
            }
        }
        private List<Plan> items = new List<Plan>();
        private List<Plan> itemsAll;
        DateTimeOffset currentDate;
        public DateTimeOffset CurrentDate
        {
            get { return currentDate; }
            set
            {
                this.RaiseAndSetIfChanged(ref currentDate, value);
                changeItems();
            }
        }
    }
}
