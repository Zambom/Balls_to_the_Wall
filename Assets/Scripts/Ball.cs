using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballInitialVelocity = 500f;

    private Rigidbody rigidbody;
    private bool moving;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !moving)
        {
            transform.parent = null;
            moving = true;
            rigidbody.isKinematic = false;
            rigidbody.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
    }
}
