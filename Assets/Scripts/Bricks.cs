using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        GM.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
