using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Front
{
    internal class UserDialog
    {
        public void Toast(string text)
        {
            ToastConfig toastConfig = new ToastConfig(text);
            toastConfig.BackgroundColor = Color.FromHex("#DDCDFF");
            toastConfig.SetDuration(5000);
            UserDialogs.Instance.Toast(toastConfig);
        }
    }
}
