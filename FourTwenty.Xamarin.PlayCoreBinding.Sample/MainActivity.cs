using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Com.Google.Android.Play.Core.Appupdate;
using Com.Google.Android.Play.Core.Install.Model;
using Com.Google.Android.Play.Core.Tasks;
using Object = Java.Lang.Object;

namespace FourTwenty.Xamarin.PlayCoreBinding.Sample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
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

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            
            CheckForUpdates();
            View view = (View)sender;
            Snackbar.Make(view, "Checking for updates", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
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


        private void CheckForUpdates()
        {
            var appUpdateManager = GetManager();
            // Returns an intent object that you use to check for an update.
            var appUpdateInfoTask = appUpdateManager.AppUpdateInfo;
            appUpdateInfoTask.AddOnSuccessListener(new AppUpdateSuccessListener(appUpdateManager, this));
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
                if (info.UpdateAvailability() != UpdateAvailability.UpdateAvailable ||
                    !info.IsUpdateTypeAllowed(AppUpdateType.Flexible)) return;

                if (_appUpdateManager.StartUpdateFlowForResult(info, AppUpdateType.Flexible, _mainActivity, 1234))
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

