using Android.Content;
using Android.Gms.Tasks;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Xamarin.Google.Android.Play.Core.AppUpdate;
using Xamarin.Google.Android.Play.Core.AppUpdate.Install.Model;
using Exception = Java.Lang.Exception;
using Object = Java.Lang.Object;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;
using View = Android.Views.View;

namespace FourTwenty.Xamarin.PlayCoreBinding.Sample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar? toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
                SetSupportActionBar(toolbar);

            FloatingActionButton? fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            if (fab != null)
                fab.Click += FabOnClick;
        }

        protected override void OnResume()
        {
            base.OnResume();

            CheckForUpdates();
        }

        public override bool OnCreateOptionsMenu(IMenu? menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object? sender, EventArgs eventArgs)
        {

            if (sender is null)
                return;

            CheckForUpdates();
            View view = (View)sender;
            if (Window?.DecorView.RootView is null)
                return;
            Snackbar.Make(Window.DecorView.RootView, "Checking for updates", BaseTransientBottomBar.LengthLong)
                .SetAction("Ok", (v) => { }).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            //Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 1234 && resultCode == Result.Ok)
            {

            }
        }


        private void OnError(string error)
        {
            if (Window?.DecorView.RootView is null)
                return;
            Snackbar.Make(Window.DecorView.RootView, error, BaseTransientBottomBar.LengthLong)
                .SetAction("Ok", (v) => { }).Show();
        }

        private void CheckForUpdates()
        {

            var appUpdateManager = GetManager();
            // Returns an intent object that you use to check for an update.
            var appUpdateInfoTask = appUpdateManager.AppUpdateInfo;
            appUpdateInfoTask.AddOnSuccessListener(new AppUpdateSuccessListener(appUpdateManager, this));
            appUpdateInfoTask.AddOnFailureListener(new AppUpdateFailureListener(this));
        }

        private class AppUpdateFailureListener : Java.Lang.Object, IOnFailureListener
        {
            private readonly MainActivity _mainActivity;
            public AppUpdateFailureListener(MainActivity mainActivity)
            {
                _mainActivity = mainActivity;
            }
            public void OnFailure(Exception p0)
            {
                _mainActivity.OnError(p0.LocalizedMessage ?? p0.Message ?? p0.ToString());
            }
        }
        private class AppUpdateSuccessListener : Java.Lang.Object, IOnSuccessListener
        {
            private readonly IAppUpdateManager _appUpdateManager;
            private readonly Activity _mainActivity;

            public AppUpdateSuccessListener(IAppUpdateManager appUpdateManager, Activity mainActivity)
            {
                _appUpdateManager = appUpdateManager;
                _mainActivity = mainActivity;
            }

            public void OnSuccess(Object p0)
            {
                if (!(p0 is AppUpdateInfo info)) return;


                var availability = info.UpdateAvailability();
                if (availability != IUpdateAvailability.UpdateAvailable ||
                    !info.IsUpdateTypeAllowed(IAppUpdateType.Immediate))
                {
                    if (availability != IUpdateAvailability.DeveloperTriggeredUpdateInProgress)
                        return;
                }

                if (_appUpdateManager.StartUpdateFlowForResult(info, _mainActivity, AppUpdateOptions.DefaultOptions(IAppUpdateType.Immediate), 1234))
                {
                    // _mainActivity.
                }
            }
        }

        private IAppUpdateManager GetManager()
        {
            // Creates instance of the manager.
            return AppUpdateManagerFactory.Create(this);
        }
    }
}

