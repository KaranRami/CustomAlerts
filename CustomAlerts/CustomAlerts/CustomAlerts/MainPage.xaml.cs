using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomAlerts
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnCommonAlert_Clicked(object sender, EventArgs e)
        {
            // of type string since we need a string return
            string result = await LaunchPopup<string>(new CommonAlert("Common Alert", "This is common alert with Ok Button.", "Ok"));
        }

        private async void BtnCommonChoiceAlert_Clicked(object sender, EventArgs e)
        {
            // of type string since we need a string return
            string result = await LaunchPopup<string>(new CommonChoiceAlert("Common Alert", "This is common choice alert with Ok and Cancel Buttons.", "Ok","Cancel"));
        }
        private async void btnActionSheetPopup_Clicked(object sender, EventArgs e)
        {
            // of type string since we need a string return
            string result = await LaunchPopup<string>(new ActionSheetPopup());
        }

        public async Task<T> LaunchPopup<T>(ContentView view, bool overrideBackButton = false)
        {
            var popup = new InputAlertDialogBase<T>(view, overrideBackButton) {
                Animation = new Rg.Plugins.Popup.Animations.MoveAnimation()
            };

            // Push the page to Navigation Stack
            await PopupNavigation.Instance.PushAsync(popup);

            // await for the user to press Button
            var result = await popup.PageClosedTask;

            // Pop the page from Navigation Stack
            await PopupNavigation.Instance.PopAsync();

            // return user pressed button text value
            return result;
        }
    }
}
