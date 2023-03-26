using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button restartButton;
    private Panel panel;

    private void Start()
    {
        panel= GetComponentInParent<Panel>();
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(Restart);
    }

    public void Restart()
    {
        panel.HidePanel();
        LevelManager.Instance.RestartLevel();

    }
}
