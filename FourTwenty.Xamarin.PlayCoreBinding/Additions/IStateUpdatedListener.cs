using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Google.Android.Play.Core.Install;

namespace FourTwenty.Xamarin.PlayCoreBinding.Additions
{
    public partial interface IStateUpdatedListener
    {
        [Register("onStateUpdate", "(Lcom/google/android/play/core/install/InstallState;)V", "GetOnStateUpdate_Lcom_google_android_play_core_install_InstallState_Handler:Com.Google.Android.Play.Core.Listener.IStateUpdatedListenerInvoker, FourTwenty.Xamarin.PlayCoreBinding")]
        void OnStateUpdate(InstallState p0);
    }
}