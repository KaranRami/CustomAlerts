using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomAlerts
{
    public class InputAlertDialogBase<T> : PopupPage
    {
        // the awaitable task
        public Task<T> PageClosedTask { get { return PageClosedTaskCompletionSource.Task; } }

        // the task completion source
        public TaskCompletionSource<T> PageClosedTaskCompletionSource { get; set; }

        bool ShouldOverrideBackButton { get; set; }

        public InputAlertDialogBase(View contentBody, bool overrideBackButton)
        {
            Content = contentBody;
            ShouldOverrideBackButton = overrideBackButton;
            // init the task completion source
            PageClosedTaskCompletionSource = new System.Threading.Tasks.TaskCompletionSource<T>();
            this.BackgroundColor = new Color(0, 0, 0, 0.4);
        }

        protected override bool OnBackButtonPressed()
        {
            if (ShouldOverrideBackButton)
                PageClosedTaskCompletionSource.SetResult(default(T));
            return true;
        }

        // Invoced when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Prevent background clicked action
            //return base.OnBackgroundClicked();
            return false;
        }
    }
}
