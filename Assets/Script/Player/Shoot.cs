using UnityEngine.InputSystem;
using UnityEngine;
using Cinemachine;

public class Shoot : MonoBehaviour
{
    public InputActionReference shoot;
    public GameObject bulletPrefab;
    public Transform bulletspawn;
    public float fireRate = 0.2f;
    public float bulletSpeed = 50f;
    public float spreadAngle = 45f;
    private int baseBulletCount = 1;
    private int extraBullets = 0;
    private float fireCooldown = 0f;
    public float originalFireRate;
    public int fireRateUpStacks = 0;
    private AudioManager am;
    public CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        am = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void Start()
    {
        originalFireRate = fireRate;
    }
    void Update()
    {
        if (shoot != null && shoot.action.IsPressed() && fireCooldown <= 0f)
        {
            Fire();
            fireCooldown = fireRate;
            am.playclip(am.shootfx);
        }

        if (fireCooldown > 0f)
            fireCooldown -= Time.deltaTime;
    }

    public void Fire()
    {
        int totalBullets = baseBulletCount + extraBullets;

        float angleStep = spreadAngle / (totalBullets - 1);
        float startAngle = -spreadAngle / 2;

        for (int i = 0; i < totalBullets; i++)
        {
            float angle = (totalBullets == 1) ? 0 : startAngle + angleStep * i;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Vector3 direction = rotation * Vector3.right;

            GameObject bullet = Instantiate(bulletPrefab, bulletspawn.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = direction * bulletSpeed;
        }

        if (impulseSource != null)
            impulseSource.GenerateImpulse();
    }
    public void UpdateFireRateFromStacks()
    {
        fireRate = originalFireRate / Mathf.Pow(2, fireRateUpStacks);
    }

    public void AddExtraBullets(int amount)
    {
        baseBulletCount += amount;
        baseBulletCount = Mathf.Max(1, baseBulletCount); // Prevents going below 1
    }
}
