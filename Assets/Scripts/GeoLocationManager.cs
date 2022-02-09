using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEditor;
using UnityEngine.UI;
using System;

public class GeoLocationManager : MonoBehaviour
{
    public Text debugText;

    private float _elapsedTime = 0f;
    private float _updateCycleLength = 2f;
    private double _berlinLatitude = 52.520008;
    private double _berlinLongitude = 13.404954;
    private double _currentLatitude = 0;
    private double _currentLongitude = 0;
    private double _currentAltitude = 0;
    private double _currentDistanceToBerlin = 0;

    void Start()
    {
        #if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission (Permission.FineLocation))
        {
                Permission.RequestUserPermission (Permission.FineLocation);
        }
         #elif UNITY_IOS
                //   PlayerSettings.iOS.locationUsageDescription = "Details to use location";
         #endif
         StartCoroutine(StartLocationService()); // Triggers the permission request
    }

    void Update() {
        if ((Time.time - _elapsedTime) > _updateCycleLength) {
            StartCoroutine(StartLocationService());
            debugText.text = "Try again";
            _elapsedTime = Time.time;
        };
    }

    private IEnumerator StartLocationService() {
        yield return new WaitForSeconds(1f); // Only for visualization purposes. Can be removed.

        if (!Input.location.isEnabledByUser)
        {
                debugText.text = "User has not enabled location";
                yield break;
         }
         Input.location.Start();
         while(Input.location.status == LocationServiceStatus.Initializing)
         {
                  yield return new WaitForSeconds(1);
         }
         if (Input.location.status == LocationServiceStatus.Failed)
         {
                  debugText.text = "Unable to determine device location";
                  yield break;
         }
         _currentLatitude = Input.location.lastData.latitude;
         _currentLongitude = Input.location.lastData.longitude;
         _currentAltitude = Input.location.lastData.altitude;
         _currentDistanceToBerlin = GetDistance(_currentLongitude, _currentLatitude, _berlinLongitude, _berlinLatitude);

        debugText.text = $"Time {_elapsedTime} || lat {_currentLatitude}, long {_currentLongitude}, alt {_currentAltitude} || Distance to Berlin {_currentDistanceToBerlin}m";
    }

    // Helper Methods

   
    public double GetDistance(double longitude, double latitude, double otherLongitude, double otherLatitude)
{
    var d1 = latitude * (Math.PI / 180.0);
    var num1 = longitude * (Math.PI / 180.0);
    var d2 = otherLatitude * (Math.PI / 180.0);
    var num2 = otherLongitude * (Math.PI / 180.0) - num1;
    var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
    
    return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
}
}
