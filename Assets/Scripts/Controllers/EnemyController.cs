using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour // INHERITANCE + ABSTRACTION
{
    public Transform muzzleTransform;
    public Bullet bulletPrefab;

private int[] rotations = new int[4] {0, 180, 90, -90}; 
    private Vector3[] velocities = new Vector3[4] {new Vector3(0, 0, 1), new Vector3(0, 0, -1),
                                                new Vector3(1, 0, 0),new Vector3(-1, 0, 0)};

    private int randomDirection;
    private float speed = 3f;
    private float timeBetweenMoves;

    private Vector3 moveVelocity;
    private Quaternion rotation = new Quaternion(0, 0, 0, 1);
    private Transform bulletsParent;

    void Start()
    {
        GameObject bulletsGO = GameObject.Find("Bullets");
        bulletsParent = bulletsGO.gameObject.transform;

        StartCoroutine(RandomMoves());
        StartCoroutine(IntervalShots());
    }

    void FixedUpdate()
    {
        transform.Translate(moveVelocity * speed * Time.fixedDeltaTime, Space.World);
        transform.rotation = rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "Wall")
        {
            ChooseRandomDirection();
        }
    }

    void ChooseRandomDirection()
    {
        randomDirection = Random.Range(0, 4);
        moveVelocity = velocities[randomDirection];
        rotation = Quaternion.Euler(0, rotations[randomDirection], 0);
    }

    private IEnumerator RandomMoves()
    {
        while (true)
        {
            ChooseRandomDirection();

            timeBetweenMoves = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(timeBetweenMoves);
        }
    }

    private IEnumerator IntervalShots()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            Bullet bullet = Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
            bullet.transform.SetParent(bulletsParent);
        }
    }
}
