using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Advertisement : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener
{

    public string id = "5729647";
    public string bannerAndroid = "Banner_Android";
    public string interstitialAndroid = "Interstitial_Android";
    public string rewardedAndroid = "Rewarded_Android";
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
