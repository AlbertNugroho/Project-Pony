using System.Collections;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public float duration = 10f;
    private bool pickedUp = false;
    private Rigidbody rb;
    private AudioManager am;
    public abstract void ApplyEffect(GameObject player);
    public abstract void RemoveEffect(GameObject player);
    private void Awake()
    {
        am = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector3.left * 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (pickedUp) return;

        if (other.CompareTag("Player"))
        {
            pickedUp = true;

            GameObject player = other.gameObject;
            ApplyEffect(player);
            StartCoroutine(EffectDuration(player));

            GetComponent<Collider>().enabled = false;
            if (TryGetComponent<SpriteRenderer>(out var renderer))
                renderer.enabled = false;

            am.playclip(am.pickupfx);
        }
    }


    private IEnumerator EffectDuration(GameObject player)
    {
        yield return new WaitForSeconds(duration);
        RemoveEffect(player);
        Destroy(gameObject);
    }

}
