using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using ReactiveUI;
using lab6.Models;

namespace lab6.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        public SecondViewModel(Plan item)
        {
            Name = item.Name;
            Todo = item.Todo;
            var okEnabled = this.WhenAnyValue(
                    x => x.Name,
                    x => !string.IsNullOrWhiteSpace(x));

            OK = ReactiveCommand.Create<Unit, Unit>(
                (unit) =>
                {
                    item.Name = Name;
                    item.Todo = Todo;
                    return Unit.Default;
                }, okEnabled);
            Cancel = ReactiveCommand.Create(() => { });
        }
        string name;
        string todo;
        public string Name
        {
            get { return name; }
            set { this.RaiseAndSetIfChanged(ref name, value); }
        }
        public string Todo
        {
            get { return todo; }
            set { this.RaiseAndSetIfChanged(ref todo, value); }
        }
        public ReactiveCommand<Unit, Unit> OK { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}
