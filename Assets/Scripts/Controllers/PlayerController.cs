using UnityEngine;

public class PlayerController : MonoBehaviour // INHERITANCE + ABSTRACTION
{
    public Transform muzzleTransform;
    public Bullet bulletPrefab;

    public AudioClip[] shootSound;

    private AudioSource audioSource; // ENCAPSULATION 

    private Transform bulletsParent;
    private Vector3 moveVelocity;

    private float speed = 3f;
    private float timeBetweenShots = 1f;
    private float lastTimeShot;

    private bool upInput, downInput, rightInput, leftInput;
    private bool shootInput;

    private Quaternion rotation = new Quaternion(0, 0, 0, 1);

    void Start()
    {
        GameObject bulletsGO = GameObject.Find("Bullets");
        bulletsParent = bulletsGO.gameObject.transform;

        audioSource = GetComponent<AudioSource>();
        lastTimeShot = Time.time;
    }

    void Update()
    {
        upInput = Input.GetKey(KeyCode.W);
        downInput = Input.GetKey(KeyCode.S);
        rightInput = Input.GetKey(KeyCode.D);
        leftInput = Input.GetKey(KeyCode.A);

        shootInput = Input.GetKeyDown(KeyCode.Space);

        if (upInput)
        {
            moveVelocity = new Vector3(0, 0, 1);
            rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (downInput)
        {
            moveVelocity = new Vector3(0, 0, -1);
            rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (rightInput)
        {
            moveVelocity = new Vector3(1, 0, 0);
            rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (leftInput)
        {
            moveVelocity = new Vector3(-1, 0, 0);
            rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            moveVelocity = Vector3.zero;
        }

        if (shootInput && Time.time - timeBetweenShots >= lastTimeShot)
        {
            int randomIndex = Random.Range(0, shootSound.Length);
            audioSource.PlayOneShot(shootSound[randomIndex], 0.5f);

            Bullet bullet = Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
            bullet.transform.SetParent(bulletsParent);
            lastTimeShot = Time.time;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(moveVelocity * speed * Time.fixedDeltaTime, Space.World);
        transform.rotation = rotation;
    }
}
