using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Panel : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    protected CanvasGroup CanvasGroup { get { return (canvasGroup == null) ? canvasGroup = GetComponent<CanvasGroup>() : canvasGroup; } }

    public string PanelID;

    public UnityEvent OnPanelShown = new UnityEvent();
    public UnityEvent OnPanelHide = new UnityEvent();

    private List<string> panelList
    {
        get { return PanelList.PanelIDs; }
    }

    protected virtual void Awake()
    {
        PanelList.Panels[PanelID] = this;
    }


    public virtual void ShowPanel()
    {
        if (CanvasGroup.alpha > 0)
            return;

        SetPanel(1, true, true);
    }

    public virtual void HidePanel()
    {
        if (CanvasGroup.alpha == 0)
            return;

        SetPanel(0, false, false);
    }

    public void SetPanel(float alpha, bool interactable, bool blocksRaycast)
    {
        CanvasGroup.alpha = alpha;
        CanvasGroup.interactable = interactable;
        CanvasGroup.blocksRaycasts = blocksRaycast;
    }

    public virtual void TogglePanel()
    {
        if (CanvasGroup.alpha == 0)
            ShowPanel();
        else HidePanel();
    }
}
