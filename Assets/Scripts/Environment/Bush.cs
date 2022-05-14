using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour // INHERITANCE + ABSTRACTION
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
