using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinUP2018.Views;

namespace XamarinUP2018.ViewModels
{
    public sealed class HomeViewModel : ViewModelBase
    {
        private readonly IPageDialogService pageDialogService;

        public HomeViewModel(INavigationService navigationService
            , IPageDialogService pageDialogService) : base(navigationService)
        {
            this.pageDialogService = pageDialogService;
            ShowAlert = new DelegateCommand(async () => await ExecuteShowAllert()).ObservesCanExecute(() => IsNotBusy);
        }

        private string text;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public ICommand ShowAlert { get; }

        private async Task ExecuteShowAllert()
        {
            await ExecuteBusyAction(async () =>
            {
                await NavigationService.NavigateAsync($"{nameof(HomePage)}?selectedTab={nameof(MovieList)}");
            });
        }
    }
}
