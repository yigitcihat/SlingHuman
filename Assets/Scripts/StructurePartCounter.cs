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
        EventManager.OnTotalStructurePartNotify.Invoke(TotalStructurePartCount);
    }

    private void OnTriggerExit(Collider other)
    {
        IDropeable dropeable= other.GetComponent<IDropeable>();
        if (dropeable == null) return;
        EventManager.OnStructurePartDroped.Invoke();
        TotalStructurePartCount--;
        dropeable.Destroy();
       
       
    }

}
