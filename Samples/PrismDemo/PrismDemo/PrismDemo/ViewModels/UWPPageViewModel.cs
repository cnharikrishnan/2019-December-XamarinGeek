using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismDemo.ViewModels
{
    public class UWPPageViewModel : ViewModelBase
    {
        public UWPPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "UWP Page";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            PlatformInformation = (PlatformInfo)parameters["platformInfo"];
            base.OnNavigatedTo(parameters);
        }
    }
}
