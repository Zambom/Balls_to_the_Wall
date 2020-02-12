using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject Gun;
    public GameObject Bullet;
    public float force = 700f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject tmpBullet;

            tmpBullet = Instantiate(Bullet, Gun.transform.position, Gun.transform.rotation) as GameObject;

            tmpBullet.transform.parent = null;

            Rigidbody tmpRb = tmpBullet.GetComponent<Rigidbody>();

            tmpRb.isKinematic = false;
            tmpRb.AddForce(new Vector3(0, force, 0));

            Destroy(tmpBullet, 3f);
        }
    }
}
