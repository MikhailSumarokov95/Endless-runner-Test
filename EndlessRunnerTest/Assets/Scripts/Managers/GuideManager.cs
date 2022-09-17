using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToxicFamilyGames.AdsBrowser;

public class GuideManager : MonoBehaviour
{
    [SerializeField] private GameObject _panelGuideForPC;
    [SerializeField] private GameObject _panelGuideForMobile;

    public void ShowGuide()
    {
        if (PlayerPrefs.GetInt("guide", 0) == 0)
        {
            PlayerPrefs.SetInt("guide", 1);
            if (YandexSDK.instance.isMobile()) _panelGuideForMobile.SetActive(true);
            else _panelGuideForPC.SetActive(true);
            Destroy(_panelGuideForPC, 2f);
            Destroy(_panelGuideForMobile, 2f);
        }
    }

    [ContextMenu("CleanGuideProcess")]
    public void CleanGuideProcess() => PlayerPrefs.SetInt("guide", 0);
}
