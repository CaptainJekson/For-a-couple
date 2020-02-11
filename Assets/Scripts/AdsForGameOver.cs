using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsForGameOver : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private GameObject startWatchingButton;

    private string gameId = "3466634";
    private string myPlacementId = "video";
    private bool testMode = true;           //Не забыть поменять на false!!!!

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);

        startWatchingButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            Advertisement.Show(myPlacementId);
        });
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (showResult == ShowResult.Skipped)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (showResult == ShowResult.Failed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacementId)
        {
            startWatchingButton.SetActive(true);
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }
}
