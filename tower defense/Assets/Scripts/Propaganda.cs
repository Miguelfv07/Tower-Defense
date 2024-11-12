using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Propaganda : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener
{

    public string id = "5729647";
    public string bannerAndroid = "Banner_Android";
    public string interstitialAndroid = "Interstitial_Android";
    public string rewardedAndroid = "Rewarded_Android";
    public float relogio;
    public bool registro;

    private void Update()
    {
        relogio += Time.deltaTime;
        Contagem();
    }

    private void Start()
    {
        Banner();
    }

    void Contagem()
    {
        if(relogio >= 10)
        {
      
            Advertisement.Banner.Hide();
            relogio = 0;
            registro = true;
        }

        if (relogio >= 5 &&  registro)
        {
            Advertisement.Banner.Show(bannerAndroid);
            relogio = 0;
            registro = false;
        }
    }

    public void Banner()
    {
            Advertisement.Initialize(id, true, this);
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            Advertisement.Banner.Show(bannerAndroid);
    }

    public void OnInitializationComplete()
    {
        
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
       
    }

    public void OnUnityAdsShowStart(string placementId)
    {
       
    }


}