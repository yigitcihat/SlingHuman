using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Level
{
    public string name;
    [HideInInspector] public int buildIndex;
}
public class LevelManager : Singleton<LevelManager>
{

    public Level[] levels;
    private int currentLevelIndex = 0;
    bool isLevelStarted;
    public bool IsLevelStarted { get { return isLevelStarted; } set { isLevelStarted = value; } }


    [HideInInspector]
    public UnityEvent OnLevelStart = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnLevelFinish = new UnityEvent();


    public void LoadLevel(int index)
    {
        if (index >= 0 && index < levels.Length)
        {
            OnLevelFinish.Invoke();
            SceneManager.LoadScene(levels[index].buildIndex);
            currentLevelIndex = index;
           
            
        }
    }

    public void LoadNextLevel()
    {
        int nextLevelIndex = currentLevelIndex + 1;
        int levelIndex = PlayerPrefs.GetInt(PlayerPrefKeys.FakeLevel, 1);
        levelIndex++;
        PlayerPrefs.SetInt(PlayerPrefKeys.FakeLevel, levelIndex);
        if (nextLevelIndex < levels.Length)
        {
            LoadLevel(nextLevelIndex);
        }
        else
        {
            LoadLevel(currentLevelIndex);
            
        }
    }
    public void StartLevel()
    {
        if (IsLevelStarted)
            return;
        IsLevelStarted = true;
        OnLevelStart.Invoke();
    }
    public void RestartLevel()
    {
        LoadLevel(currentLevelIndex);
    }
}