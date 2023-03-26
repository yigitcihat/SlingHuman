using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InGamePanel : Panel
{
 
    bool isLevelStarted;
    public bool IsLevelStarted { get { return isLevelStarted; } set { isLevelStarted = value; } }
    
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelStart.AddListener(ShowPanel);
        EventManager.OnOpenWinPanel.AddListener(HidePanel);
        EventManager.OnOpenFailPanel.AddListener(HidePanel);
    }
    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelStart.RemoveListener(ShowPanel);
        EventManager.OnOpenWinPanel.RemoveListener(HidePanel);
        EventManager.OnOpenFailPanel.RemoveListener(HidePanel);
    }
}
