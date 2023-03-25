using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructurePartCounter : MonoBehaviour 
{
    [SerializeField] Transform TargetPlatform;

    private int TotalStructurePartCount;
    private void Start()
    {
        TotalStructurePartCount = TargetPlatform.GetComponentsInChildren<IDropeable>().Length;
    }

    private void OnTriggerExit(Collider other)
    {
        IDropeable dropeable= other.GetComponent<IDropeable>();
        if (dropeable == null) return;

        TotalStructurePartCount--;
        dropeable.Destroy();
        Debug.Log(TotalStructurePartCount);
       
    }

}
