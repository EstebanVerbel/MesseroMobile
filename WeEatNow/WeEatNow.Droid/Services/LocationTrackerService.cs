using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using WeEatNow.Services.Interfaces;
using Android.Locations;
using WeEatNow.Models.DataObjects;
using Xamarin.Forms;

[assembly: Dependency(typeof(WeEatNow.Droid.Services.LocationTrackerService))]

namespace WeEatNow.Droid.Services
{
    public class LocationTrackerService : Java.Lang.Object, ILocationTracker, ILocationListener
    {
        LocationManager locationManager;
        
        public event EventHandler<GeographicLocation> LocationChanged;

        public LocationTrackerService()
        {
            Activity activity = Toolkit.Activity;

            if (activity == null)
                throw new InvalidOperationException(
                    "Must call Toolkit.Init before using LocationProvider");

            locationManager =
                activity.GetSystemService(Context.LocationService) as LocationManager;
        }

        // Two methods to implement ILocationProvider (the dependency service interface).
        public void StartTracking()
        {
            IList<string> locationProviders = locationManager.AllProviders;

            foreach (string locationProvider in locationProviders)
            {
                locationManager.RequestLocationUpdates(locationProvider, 1000, 1, this);
            }
        }

        public void PauseTracking()
        {
            locationManager.RemoveUpdates(this);
        }

        // Four methods to implement ILocationListener (the Android interface).
        public void OnLocationChanged(Location location)
        {
            EventHandler<GeographicLocation> handler = LocationChanged;

            if (handler != null)
            {
                handler(this, new GeographicLocation(location.Latitude,
                                                     location.Longitude));
            }
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status,
                                    Bundle extras)
        {
        }
    }
}