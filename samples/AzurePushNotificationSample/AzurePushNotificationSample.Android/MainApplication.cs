using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.AzurePushNotification;
using System;

namespace AzurePushNotificationSample.Droid
{
    [Application]
    public class MainApplication : Application
    {
        protected MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            
            //Set the default notification channel for your app when running Android Oreo
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                //Change for your default notification channel id here
                AzurePushNotificationManager.DefaultNotificationChannelId = "DefaultChannel";

                //Change for your default notification channel name here
                AzurePushNotificationManager.DefaultNotificationChannelName = "General";
            }
            
            #if DEBUG
                 AzurePushNotificationManager.Initialize(this, AzureConstants.ListenConnectionString, AzureConstants.NotificationHubName, true);
            #else
                 AzurePushNotificationManager.Initialize(this, AzureConstants.ListenConnectionString, AzureConstants.NotificationHubName, false);
            #endif


            //Handle notification when app is closed here
            CrossAzurePushNotification.Current.OnNotificationReceived += (s, p) =>
            {


            };            
        }

        
    }
}
