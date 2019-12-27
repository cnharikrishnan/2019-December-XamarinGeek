using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismDemo.ViewModels
{
    public class UWPPageViewModel : ViewModelBase
    {
        public UWPPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            :base(navigationService, pageDialogService)
        {
            Title = "UWP Page";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            PlatformInformation = (PlatformInfo)parameters["platformInfo"];
        }
    }
}
