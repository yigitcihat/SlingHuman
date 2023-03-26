using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour, IDropeable
{
    private Rigidbody _rb;
    private Animator _animator;
    private bool _isOneTime;
    [SerializeField] private bool isFirstHuman;
    public float explosionForce = 1000f;  
    public float explosionRadius = 5f;  
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _rb.isKinematic = true;
        if (isFirstHuman)
        {
            _animator.SetTrigger("Stay");
        }
    }

    public void Push(Vector3 force)
    {
        _rb.isKinematic = false;
        _rb.AddForce(_rb.mass * force, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        StructurePart part = collision.gameObject.GetComponent<StructurePart>();
        ExplosiveCube explosiveCube = collision.gameObject.GetComponent<ExplosiveCube>();
        
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
                hit.transform.SetParent(null);
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius);
                }
            }
            if (!_isOneTime && transform.parent == null)
            {
                _animator.SetTrigger("Die");
                _isOneTime= true;
            }
           
        }
        else if (explosiveCube != null)
        {
            explosiveCube.Explosion(0.2f);
            explosiveCube.transform.SetParent(null);
            if (!_isOneTime && transform.parent == null)
            {
                _animator.SetTrigger("Die");
                _isOneTime = true;
            }
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
