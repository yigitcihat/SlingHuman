using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        StructurePart part = collision.gameObject.GetComponent<StructurePart>();
        if (part != null)
        {
            if (!part.isActivated)
            {
                part.ActivatePart();
            }
          
        }
    }
}
