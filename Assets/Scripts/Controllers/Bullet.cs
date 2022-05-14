using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    [SerializeField] private float speed = 5f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionParticle, this.transform.position, explosionParticle.transform.rotation);

        if (collision.collider.tag == "SolidTile")
        {
            Destroy(collision.gameObject);
        }

        Destroy(this.gameObject);
    }

}
