using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomAlerts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommonChoiceAlert : ContentView
    {
        public CommonChoiceAlert(string title, string description, string okTitle, string cancelTitle)
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblDescription.Text = description;
            btnOk.Text = okTitle;
            btnCancel.Text = cancelTitle;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            SetResult(sender);
        }
        private void SetResult(object sender)
        {
            if (sender is Button)
                (this.Parent as InputAlertDialogBase<string>).PageClosedTaskCompletionSource.SetResult((sender as Button).Text);
        }
    }
}