using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Propaganda : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener
{

    public string id = "5729647";
    public string bannerAndroid = "Banner_Android";
    public string interstitialPulavel = "Interstitial_Android";
    public string intertitial = "Intertitital_pulavel";
    public string rewardedAndroid = "Rewarded_Android";
    public float relogio;
    public bool registro;
    public float relogio2;
    public bool controladorInt;
    public bool podePular;
    public static Propaganda instance;
   


    public delegate void rwd();
    public rwd reward;

    private void Awake()
    {
        instance = this;
    }

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

    public void VoltarAoJogo()
    {
        Advertisement.Show(rewardedAndroid, this) ;
        Advertisement.Banner.Hide();
        reward = Reviver;

    }

    public void Insterstitial()
    {
        
        if(EnemySpawner.instance.enemiesAlive == 0)
        {
            if (podePular)
            {

                Advertisement.Show(interstitialPulavel, this);
                relogio = 0;
                relogio2 = 0;
                Time.timeScale = 0;
                Advertisement.Banner.Hide();
                podePular = false;
               
            }
            else
            {
                Advertisement.Show(intertitial, this);
                relogio = 0;
                relogio2 = 0;
                Time.timeScale = 0;
                Advertisement.Banner.Hide();
                podePular = true;
                
            }
        }
    }

    public void Reviver()
    {
        LevelManager.instance.gameOverPanel.SetActive(false);
    }

    public void GanharDinheiro()
    {
        LevelManager.instance.currency += 50;
    }

    public void OnInitializationComplete()
    {
        
    }
    public void Reward()
    {
        Advertisement.Show(rewardedAndroid, this);
        Advertisement.Banner.Hide();
        Time.timeScale = 0;
        reward = GanharDinheiro;
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
        if (placementId == interstitialPulavel || placementId == intertitial || placementId == rewardedAndroid)

        {

            if (showCompletionState == UnityAdsShowCompletionState.COMPLETED || showCompletionState == UnityAdsShowCompletionState.SKIPPED)

            {
                Time.timeScale = 1;
                

            }

  

        }

        if (placementId == rewardedAndroid )
        {
            if(showCompletionState == UnityAdsShowCompletionState.COMPLETED || showCompletionState == UnityAdsShowCompletionState.SKIPPED)
            {
                reward();
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
