using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class ExplosiveCube : MonoBehaviour
{
    public bool Exploded = false;
    public float ExplosionForce = 35;
    public float ExplosionRadius = 1f;
    public float ColliderGrowthRate = 2f;
    public float ColliderGrowthDuration = 0.1f;
    private float _expTime = 0.1f;
    private Rigidbody _rb;
    private BoxCollider _boxCollider;
    private Tween _tween;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }
    private Vector3 originalSize;
    public void Explosion(float expTime)
    {
        _expTime= expTime;
        StartCoroutine(ExplosionCoroutine(expTime));
    }
    private IEnumerator ExplosionCoroutine(float expTime)
    {
        yield return new WaitForSeconds(expTime);
        Exploded = true;
        _rb.isKinematic = false;
        originalSize = _boxCollider.size;
        Vector3 targetSize = originalSize * ColliderGrowthRate;
        _tween = DOTween.To(() => _boxCollider.size, x => { if (!_boxCollider) { _boxCollider.size = x; }}, targetSize, 1f);
    }

    private void OnCollisionEnter(Collision other)
    {
        ExplosiveCube explosiveCube = other.gameObject.GetComponent<ExplosiveCube>();

        if (Exploded)
        {
            if (explosiveCube != null)
            {

                explosiveCube.Explosion(UnityEngine.Random.Range(0, 0.3f));
            }
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, ExplosionRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(ExplosionForce, explosionPos, ExplosionRadius);
                }
            }

            Destroy(gameObject, _expTime);
        }
    }


    private void OnDestroy()
    {
        _tween.Kill();
    }
}
