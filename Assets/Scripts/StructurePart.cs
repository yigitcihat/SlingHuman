using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructurePart : MonoBehaviour
{
    public bool isActivated;
    private Rigidbody rb;
    //private float forceMultiplier = 200f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ActivatePart()
    {
        rb.isKinematic = false;
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
                //Vector3 force = (collision.transform.position - transform.position).normalized * forceMultiplier;
                //collision.rigidbody.AddForce(force);
                
            }
            
        }
    }

}
