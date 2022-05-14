using UnityEngine;

public class Tank : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    protected int health = 2;

    void OnCollisionEnter(Collision collision)
    {
        GetDamage(collision);
    }

    protected virtual void GetDamage(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            health -= 1;
            if (health <= 0)
            {
                DestroyTank();
            }
        }
    }

    protected virtual void DestroyTank()
    {
        Instantiate(explosionParticle, this.transform.position, explosionParticle.transform.rotation);
        Destroy(this.gameObject);
    }
}
