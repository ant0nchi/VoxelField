using UnityEngine;

public class PlayerTank : Tank
{
    AudioSource audioSource;
    public AudioClip hurtSound;

    public PlayerTank()
    {
        health = 3;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        EventManager.PlayerHarmed(health);
    }

    protected override void GetDamage(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            health -= 1;
            EventManager.PlayerHarmed(health);
            if (health <= 0)
            {
                EventManager.PlayerDestroyed();
                DestroyTank();
            }
            else
            {
                audioSource.PlayOneShot(hurtSound, 0.5f);
            }
        }
    }
}
