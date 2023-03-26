using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : Panel
{
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
}
