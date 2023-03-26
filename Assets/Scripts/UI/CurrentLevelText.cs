using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentLevelText : MonoBehaviour
{
    public TextMeshProUGUI Level;
    private void Awake()
    {
        Level = GetComponent<TextMeshProUGUI>();
    }
}
