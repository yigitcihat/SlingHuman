using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrow : MonoBehaviour
{
    public Rigidbody ballPrefab;
    public float launchForce = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody ballInstance = Instantiate(ballPrefab, transform.position, transform.rotation);
            ballInstance.AddForce(transform.forward * launchForce, ForceMode.Impulse);
        }
    }
}
