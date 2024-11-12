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
    public float relogio2;

    private void Update()
    {
        relogio2 += Time.deltaTime;
        relogio += Time.deltaTime;
        Contagem();

        if (relogio2 >= 6)
        {
            Insterstitial();
        }
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

    public void Insterstitial()
    {
        if(EnemySpawner.instance.enemiesAlive == 0)
        {
            Advertisement.Show(interstitialAndroid, this);
            relogio = 0;
            relogio2 = 0;
            Time.timeScale = 0;
            Advertisement.Banner.Hide();
        }
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
        Advertisement.Banner.Show(bannerAndroid);
        if (placementId == interstitialAndroid)

        {

            if (showCompletionState == UnityAdsShowCompletionState.COMPLETED || showCompletionState == UnityAdsShowCompletionState.SKIPPED)

            {
                Time.timeScale = 1;

            }

  

        }

    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
       
    }

    public void OnUnityAdsShowStart(string placementId)
    {
       
    }


}
