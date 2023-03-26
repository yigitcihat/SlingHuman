using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    public TextMeshProUGUI ProgressText;
    public TextMeshProUGUI InfoText;

    private int totalStructurePart;
    private int progress;
    private bool isOneTime;
    private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
    }
    private void OnEnable()
    {
        EventManager.OnTotalStructurePartNotify.AddListener(SetStructureCount);
        EventManager.OnStructurePartDroped.AddListener(ProgressIncrease);
    }
    private void OnDisable()
    {
        EventManager.OnTotalStructurePartNotify.RemoveListener(SetStructureCount);
        EventManager.OnStructurePartDroped.RemoveListener(ProgressIncrease);
       

    }
    private void ProgressIncrease()
    {
        progress += totalStructurePart / 100;
        slider.value = progress;
        ProgressText.text =  "%" + slider.value;
        if (progress >= 90 && !isOneTime)
        {
            StartCoroutine(OpenWinPanel());
            isOneTime = true;
        }
    }
    private IEnumerator OpenWinPanel()
    {
        yield return new WaitForSeconds(2f);
        EventManager.OnOpenWinPanel.Invoke();
    }
    private void SetStructureCount(int count)
    {
        totalStructurePart= count;
        
    }
}
