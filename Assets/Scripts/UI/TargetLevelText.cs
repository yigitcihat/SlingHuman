using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetLevelText : MonoBehaviour
{
    public TextMeshProUGUI Level;
    private void Awake()
    {
        Level = GetComponent<TextMeshProUGUI>();
    }
}
