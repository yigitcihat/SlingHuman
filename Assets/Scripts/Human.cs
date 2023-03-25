using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private Rigidbody _rb;
    public float explosionForce = 1000f;  // Patlama etkisi kuvveti
    public float explosionRadius = 5f;  // Patlama etkisi yarýçapý
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    public void Push(Vector3 force)
    {
        _rb.isKinematic = false;
        _rb.AddForce(_rb.mass * force, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        StructurePart part = collision.gameObject.GetComponent<StructurePart>();
        if (part != null)
        {
            if (!part.isActivated)
            {
                part.ActivatePart();
               

            }
            Vector3 explosionPos = collision.contacts[0].point;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius);
                }
            }
        }
    }
}
