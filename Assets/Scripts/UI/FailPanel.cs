using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPanel : Panel
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnOpenFailPanel.AddListener(ShowPanel);
    }
    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnOpenFailPanel.AddListener(ShowPanel);
    }
}
