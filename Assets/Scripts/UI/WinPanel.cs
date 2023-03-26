using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : Panel
{
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI PercentText;
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnOpenWinPanel.AddListener(ShowPanel);
        LevelManager.Instance.OnLevelFinish.AddListener(HidePanel);
    }
    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnOpenWinPanel.AddListener(ShowPanel);
        LevelManager.Instance.OnLevelFinish.RemoveListener(HidePanel);
    }

    public void SetTexts(string percent)
    {
        LevelText.text = "Level " + PlayerPrefs.GetInt(PlayerPrefKeys.FakeLevel,1).ToString() ;
        PercentText.text = "%" +percent; 
    }
}
