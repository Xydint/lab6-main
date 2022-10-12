using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using lab6.Models;

namespace lab6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public List<Plan> ItemsAll { get; set; }

        ViewModelBase content;
        public MainWindowViewModel()
        {
            Button_Add = ReactiveCommand.Create<Unit, Unit>(
                (unit) =>
                {
                    var newItem = new Plan("", "", Fv.CurrentDate);
                    var sv = new SecondViewModel(newItem);
                    Observable.Merge(
                sv.OK,
                sv.Cancel.Select(_ => Unit.Default))
                .Take(1)
                .Subscribe(unit =>
                {
                    ItemsAll.Add(newItem);
                    Fv.changeItems();
                    Content = Fv;
                });
                    Content = sv;
                    return Unit.Default;
                });
            Button_Zoom = ReactiveCommand.Create<Plan, Unit>(
                (item) =>
                {
                    var sv = new SecondViewModel(item);
                    Observable.Merge(
                sv.OK,
                sv.Cancel.Select(_ => Unit.Default))
                .Take(1)
                .Subscribe(unit =>
                {
                    Fv.changeItems();
                    Content = Fv;
                });
                    Content = sv;
                    return Unit.Default;
                });
            Button_Delete = ReactiveCommand.Create<Plan, Unit>((item) =>
            {
                ItemsAll.Remove(item);
                Fv.changeItems();
                return Unit.Default;
            });
            ItemsAll = BuildAllPlans();
            Content = Fv = new FirstViewModel(ItemsAll);
        }

        public ViewModelBase Content
        {
            set => this.RaiseAndSetIfChanged(ref content, value);
            get => content;
        }
        public FirstViewModel Fv
        {
            get;
        }
        public ReactiveCommand<Unit, Unit> Button_Add { get; }
        public ReactiveCommand<Plan, Unit> Button_Zoom { get; }
        public ReactiveCommand<Plan, Unit> Button_Delete { get; }
        public ReactiveCommand<Plan, Unit> Button_Ok { get; }
        public ReactiveCommand<Plan, Unit> Button_Cancel { get; }
        private List<Plan> BuildAllPlans()
        {
            return new List<Plan>
            {
                new Plan("plan1","todo1", DateTime.Today.AddDays(0)),
                new Plan("plan2","todo2", DateTime.Today.AddDays(0)),
                new Plan("plan3","todo3", DateTime.Today.AddDays(0)),
                new Plan("plan4","todo4", DateTime.Today.AddDays(0)),
                new Plan("plan5","todo5", DateTime.Today.AddDays(0)),
                new Plan("plan6","todo6", DateTime.Today.AddDays(-1)),
                new Plan("plan7","todo7", DateTime.Today.AddDays(-1)),
                new Plan("plan8","todo8", DateTime.Today.AddDays(-1)),
                new Plan("plan9","todo9", DateTime.Today.AddDays(-1)),
                new Plan("plan10","todo10", DateTime.Today.AddDays(-1)),
                new Plan("plan11","todo11", DateTime.Today.AddDays(1)),
                new Plan("plan12","todo12", DateTime.Today.AddDays(1)),
                new Plan("plan13","todo13", DateTime.Today.AddDays(1)),
                new Plan("plan14","todo14", DateTime.Today.AddDays(1)),
                new Plan("plan15","todo15", DateTime.Today.AddDays(1)),
                new Plan("plan16","todo16", DateTime.Today.AddDays(-2)),
                new Plan("plan17","todo17", DateTime.Today.AddDays(-2)),
                new Plan("plan18","todo18", DateTime.Today.AddDays(-2)),
                new Plan("plan19","todo19", DateTime.Today.AddDays(-2)),
                new Plan("plan16","todo16", DateTime.Today.AddDays(-2)),
                new Plan("plan17","todo17", DateTime.Today.AddDays(2)),
                new Plan("plan18","todo18", DateTime.Today.AddDays(2)),
                new Plan("plan19","todo19", DateTime.Today.AddDays(2)),
                new Plan("plan16","todo16", DateTime.Today.AddDays(2)),
                new Plan("plan17","todo17", DateTime.Today.AddDays(2))
            };
        }
    }
}
