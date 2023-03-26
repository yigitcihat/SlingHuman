using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FailPanel : Panel
{
    public TextMeshProUGUI PercentText;
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
    public void SetTexts( string percent)
    {
        PercentText.text ="%"+ percent;
    }
}
