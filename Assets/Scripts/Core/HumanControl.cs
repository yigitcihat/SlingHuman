using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControl : MonoBehaviour
{
    private int totalHuman;
    private bool isLevelSuccess;

    private void Start()
    {
        totalHuman = transform.childCount +1;
        EventManager.OnTotalHumanCountNotify.Invoke(totalHuman);
    }

    private void OnEnable()
    {
        EventManager.OnHumanThrowed.AddListener(()=>StartCoroutine(CheckHumans()));
        EventManager.OnOpenWinPanel.AddListener(() => isLevelSuccess = true);
    }
    private void OnDisable()
    {
        EventManager.OnHumanThrowed.RemoveListener(() => StartCoroutine(CheckHumans()));
        EventManager.OnOpenWinPanel.RemoveListener(() => isLevelSuccess = true);

    }

    private IEnumerator CheckHumans()
    {
        yield return new WaitForSeconds(8);
        totalHuman--;
        if (totalHuman == 0 && !isLevelSuccess) {

            EventManager.OnOpenFailPanel.Invoke();
        
        }
    }
}
