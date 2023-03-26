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

    private void OnTriggerEnter(Collider other)
    {
        IDropeable dropeable= other.GetComponent<IDropeable>();
        if (dropeable == null) return;
        EventManager.OnStructurePartDroped.Invoke();
        TotalStructurePartCount--;
        PoolingSystem.Instance.InstantiateAPS("DropWater", other.transform.position + new Vector3(0,0,0));
        dropeable.Destroy();
       
       
    }

}
