using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilAI : MonoBehaviour
{
    [SerializeField] private int health = 5;
    private Vector3 moveDir;
    private float speed;
    private ScoreManager score;
    private Rigidbody rb;
    private DropItems di;
    private Health player;
    private spawnmanager spawn;
    private bool hasDamagedPlayer = false;
    float waveFrequency = 2f;
    float waveHeight;
    float phase = 0f;
    float yDirection = 1f;
    void Start()
    {
        di = GetComponent<DropItems>();
        spawn = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<spawnmanager>();
        score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        speed = spawn.enemyspeed;
        phase = Random.Range(0f, Mathf.PI * 2f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x < -32 && !hasDamagedPlayer)
        {
            DealDamageToPlayer();
            Destroy(gameObject);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            di.TryDropItem();
            score.AddScore();
        }
    }
    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        float minY = -7f;
        float maxY = 13f;

        // Determine waveHeight based on score
        if (score.GetScore() <= 8000)
            waveHeight = 0.5f; // minimal wave
        else if (score.GetScore() <= 16000)
            waveHeight = 0.85f; // medium wave
        else
            waveHeight = 1.2f; // big wave

        // Advance the wave phase
        phase += Time.deltaTime * waveFrequency;

        // Calculate intended wave height, then adjust so it doesn't exceed bounds
        float currentY = transform.position.y;
        float distanceToTop = maxY - currentY;
        float distanceToBottom = currentY - minY;

        float sin = Mathf.Sin(phase);
        float clampedWaveHeight = waveHeight;

        if (sin > 0f) // moving up
            clampedWaveHeight = Mathf.Min(waveHeight, distanceToTop);
        else          // moving down
            clampedWaveHeight = Mathf.Min(waveHeight, distanceToBottom);

        // Calculate vertical velocity from clamped height
        float waveY = sin * clampedWaveHeight;
        moveDir = new Vector3(-1f, waveY, 0f);

        rb.velocity = moveDir * speed;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasDamagedPlayer)
        {
            DealDamageToPlayer();
            Destroy(gameObject);
        }
    }

    private void DealDamageToPlayer()
    {
        if (player != null)
        {
            player.TakeDamage();
        }
        hasDamagedPlayer = true;
    }

    public void TakeDamage()
    {
        health--;
    }
}
