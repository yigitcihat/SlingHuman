using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructurePart : MonoBehaviour
{
    public bool isActivated;
    private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void ActivatePart()
    {
        _rb.isKinematic = false;
        isActivated = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        StructurePart neighborPart = collision.gameObject.GetComponent<StructurePart>();
        if (neighborPart != null)
        {
            if (!neighborPart.isActivated) 
            {
                neighborPart.ActivatePart();
            }
            
        }
    }

}
