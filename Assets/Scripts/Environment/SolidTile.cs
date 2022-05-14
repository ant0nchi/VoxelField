using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidTile : MonoBehaviour // INHERITANCE + ABSTRACTION
{
    void onCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
