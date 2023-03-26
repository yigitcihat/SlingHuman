using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    private Button nextLevelButton;
    private Panel panel;
    private void Start()
    {
        panel = GetComponentInParent<Panel>();
        nextLevelButton = GetComponent<Button>();
        nextLevelButton.onClick.AddListener(LoadNextLevel);
    }

    public void LoadNextLevel()
    {
        panel.HidePanel();
        LevelManager.Instance.LoadNextLevel();


    }
}
