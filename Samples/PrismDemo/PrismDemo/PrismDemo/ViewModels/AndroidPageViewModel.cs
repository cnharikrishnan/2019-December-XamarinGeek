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
    public class AndroidPageViewModel : ViewModelBase
    {
        public AndroidPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base (navigationService, pageDialogService)
        {
            Title = "Android Page";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            PlatformInformation = (PlatformInfo)parameters["platformInfo"];
            base.OnNavigatedTo(parameters);
        }
    }
}
