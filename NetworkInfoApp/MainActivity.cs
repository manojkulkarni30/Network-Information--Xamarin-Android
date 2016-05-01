using Android.App;
using Android.Widget;
using Android.OS;
using Android.Net;

namespace NetworkInfoApp
{
    [Activity(Label = "Newtwork Information", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity
    {
        TextView txtConnectedValue,txtWifiValue,txtRoamingValue,txtBlueToothValue;
        protected override int LayoutResource
        {
            get { return Resource.Layout.main; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);


            FindView();

            // Get the reference of Connectivity Service
            ConnectivityManager connectivityManager =(ConnectivityManager) GetSystemService(ConnectivityService);

            // Get the network information
            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            if(activeConnection!=null)
            {
                txtConnectedValue.Text = activeConnection.IsConnected ? "Yes": "No" ;
            }

            NetworkInfo wifiInfo = connectivityManager.GetNetworkInfo(ConnectivityType.Wifi);
            if (wifiInfo != null)
            {
                txtWifiValue.Text = wifiInfo.IsConnected ? "Yes" : "No";
            }

            NetworkInfo mobileInfo = connectivityManager.GetNetworkInfo(ConnectivityType.Mobile);
            if (mobileInfo != null)
            {
                txtRoamingValue.Text = (mobileInfo.IsConnected && mobileInfo.IsRoaming) ? "Yes" :"No";
            }

            NetworkInfo blueToothInfo = connectivityManager.GetNetworkInfo(ConnectivityType.Bluetooth);
            if (blueToothInfo != null)
            {
                txtBlueToothValue.Text = blueToothInfo.IsConnected ? "Yes" : "No";
            }
        }

        private void FindView()
        {
            txtConnectedValue = FindViewById<TextView>(Resource.Id.txtConnectedValue);
            txtWifiValue = FindViewById<TextView>(Resource.Id.txtWifiValue);
            txtRoamingValue = FindViewById<TextView>(Resource.Id.txtRoamingValue);
            txtBlueToothValue = FindViewById<TextView>(Resource.Id.txtBlueToothValue);
        }
    }
}

