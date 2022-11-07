using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Reklam : MonoBehaviour
{
    private InterstitialAd interReklam;
    public string AndroidReklamKimligi;
    public string �osBannerReklamKimligi;
    string Reklamid;

    void Start()
    {
        RequestGecis();
    }

    void RequestGecis()
    {
        #if UNITY_ANDROID
                Reklamid = AndroidReklamKimligi;
        #elif UNITY_IPHONE
                Reklamid=�osBannerReklamKimligi;
        #else
                Reklamid = "Tan�ms�z Platform";
        #endif

        interReklam = new InterstitialAd(Reklamid);

        AdRequest request = new AdRequest.Builder().Build();
        interReklam.LoadAd(request);
    }

    public void GameOver()
    {

        if (interReklam.IsLoaded())
        {
            interReklam.Show();

        }
        else
        {
            RequestGecis();
        }
    }
}
