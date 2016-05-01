using Android.App;
using Android.Widget;
using Android.OS;
using Android.Net;
using System;

namespace NetworkInfoApp
{
    [Activity(Label = "Newtwork Information", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity
    {
        TextView txtConnectedValue,txtWifiValue,txtRoamingValue;
        Button btnRefresh;
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

            HandleEvents();

            GetNetworkInfomation();

        }

        private void GetNetworkInfomation()
        {
            // Get the reference of Connectivity Service
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);

            // Get the network information
            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            if (activeConnection != null)
            {
                txtConnectedValue.Text = activeConnection.IsConnected ? "Yes" : "No";
            }

            NetworkInfo wifiInfo = connectivityManager.GetNetworkInfo(ConnectivityType.Wifi);
            if (wifiInfo != null)
            {
                txtWifiValue.Text = wifiInfo.IsConnected ? "Yes" : "No";
            }

            NetworkInfo mobileInfo = connectivityManager.GetNetworkInfo(ConnectivityType.Mobile);
            if (mobileInfo != null)
            {
                txtRoamingValue.Text = (mobileInfo.IsConnected && mobileInfo.IsRoaming) ? "Yes" : "No";
            }
        }

        private void HandleEvents()
        {
            btnRefresh.Click += BtnRefresh_Click;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetNetworkInfomation();
        }

        private void FindView()
        {
            txtConnectedValue = FindViewById<TextView>(Resource.Id.txtConnectedValue);
            txtWifiValue = FindViewById<TextView>(Resource.Id.txtWifiValue);
            txtRoamingValue = FindViewById<TextView>(Resource.Id.txtRoamingValue);
            btnRefresh = FindViewById<Button>(Resource.Id.btnRefresh);
        }
    }
}

