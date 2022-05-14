using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidTile : MonoBehaviour
{
    void onCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
