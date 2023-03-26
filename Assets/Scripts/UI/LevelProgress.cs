using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    public TextMeshProUGUI ProgressText;
    public TextMeshProUGUI InfoText;
    public TextMeshProUGUI CurrentLevelText;
    public TextMeshProUGUI TargetLevelText;
    private int totalStructurePart;
    private int progress;
    private bool isOneTime;
    private bool isFail;
    private Slider slider;
    private WinPanel winPanel;
    private FailPanel failPanel;
    private void Start()
    {
        slider = GetComponent<Slider>();
        winPanel=transform.root.GetComponentInChildren<WinPanel>();
        failPanel= transform.root.GetComponentInChildren<FailPanel>();
        slider.value = 0;
        int fakeLevel = PlayerPrefs.GetInt(PlayerPrefKeys.FakeLevel, 1);
        CurrentLevelText = GetComponentInChildren<CurrentLevelText>().Level;
        TargetLevelText = GetComponentInChildren<TargetLevelText>().Level;
        CurrentLevelText.text = fakeLevel.ToString();
        TargetLevelText.text = (fakeLevel + 1).ToString();
    }
    private void OnEnable()
    {
        EventManager.OnTotalStructurePartNotify.AddListener(SetStructureCount);
        EventManager.OnStructurePartDroped.AddListener(ProgressIncrease);
        EventManager.OnOpenFailPanel.AddListener(FailLevel);

    }
    private void OnDisable()
    {
        EventManager.OnTotalStructurePartNotify.RemoveListener(SetStructureCount);
        EventManager.OnStructurePartDroped.RemoveListener(ProgressIncrease);
        EventManager.OnOpenFailPanel.RemoveListener(FailLevel);
       

    }
    private void ProgressIncrease()
    {
        progress += totalStructurePart / 100;
        slider.value = progress;
        ProgressText.text =  "%" + slider.value;
        if (progress >= 90 && !isOneTime )
        {
            winPanel.SetTexts(progress.ToString());
            StartCoroutine(OpenWinPanel());
            isOneTime = true;
        }
    }
    private IEnumerator OpenWinPanel()
    {
        yield return new WaitForSeconds(2f);
        if (!isFail)
        {
            EventManager.OnOpenWinPanel.Invoke();
        }
       
    }
    private void SetStructureCount(int count)
    {
        totalStructurePart= count;
        
    }
    private void FailLevel()
    {
        failPanel.SetTexts(progress.ToString()); 
        isFail = true;
    }
}
