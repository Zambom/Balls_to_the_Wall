using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
