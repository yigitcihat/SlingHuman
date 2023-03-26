using System.Collections;
using TMPro;
using UnityEngine;

public class GameStartPanel : Panel
{
    public TextMeshProUGUI LevelDisplayText;

    private void Start()
    {
        ShowPanel();
    }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.RemoveListener(HidePanel);
    }
    public override void ShowPanel()
    {
        base.ShowPanel();
        int fakeLevel = PlayerPrefs.GetInt(PlayerPrefKeys.FakeLevel, 1);
        LevelDisplayText.text =  "Level " + fakeLevel;
    }
    public override void HidePanel()
    {
        base.HidePanel();
        StartCoroutine(StartGame());
    }
    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.2f);
        EventManager.OnLevelStart.Invoke();
    }

    
}
