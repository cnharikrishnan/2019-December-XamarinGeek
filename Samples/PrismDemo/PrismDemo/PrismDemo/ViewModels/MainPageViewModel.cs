using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private List<PlatformInfo> _platformList;

        public List<PlatformInfo> PlatformsList
        {
            get { return _platformList; }
            set { SetProperty(ref _platformList, value); }
        }

        public DelegateCommand<PlatformInfo> NavigateToPlatformCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            Title = "Main Page";
            NavigateToPlatformCommand = new DelegateCommand<PlatformInfo>(OnNavigateToPlatform);
        }

        private async void OnNavigateToPlatform(PlatformInfo platformInfo)
        {
            var parameter = new NavigationParameters();
            parameter.Add("platformInfo", platformInfo);
            if(!platformInfo.IsChecked)
            {
                //await NavigationService.NavigateAsync("AndroidPage/iOSPage/UWPPage", parameter);

                await DialogService.DisplayAlertAsync("Warning...", "Please ensure to check the platform before you navigate.", "OK");
                return;
            }
            await NavigationService.NavigateAsync(platformInfo.PlatformName + "Page", parameter);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            this.GetContactsList();
        }

        private void GetContactsList()
        {
            if (this.PlatformsList == null)
                this.PlatformsList = new List<PlatformInfo>();

            this.PlatformsList.Add(new PlatformInfo() { IsChecked = true, PlatformName = "Android" });
            this.PlatformsList.Add(new PlatformInfo() { IsChecked = true, PlatformName = "iOS" });
            this.PlatformsList.Add(new PlatformInfo() { IsChecked = false, PlatformName = "UWP" });
        }
    }
}
