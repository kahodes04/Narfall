using UnityEngine;
using UnityEngine.Advertisements;
public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string playStoreID = "3831230";
    private string appStoreID = "3831231";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;

    void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
        isTestAd = true;
        isTargetPlayStore = true;
    }

    private void InitializeAdvertisement()
    {
        if (isTargetPlayStore)
            Advertisement.Initialize(playStoreID, isTestAd);
        else
            Advertisement.Initialize(appStoreID, isTestAd);
    }

    public void PlayInterstitialAd()
    {
        if (Advertisement.IsReady(interstitialAd))
            Advertisement.Show(interstitialAd);
    }

    public void PlayRewardedVideoAd()
    {
        if (Advertisement.IsReady(rewardedVideoAd))
            Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == rewardedVideoAd)
                    Debug.Log("player finished watching rewardedvideoad");
                if (placementId == interstitialAd)
                    Debug.Log("player finished interstitialad");
                break;
        }
    }
}
