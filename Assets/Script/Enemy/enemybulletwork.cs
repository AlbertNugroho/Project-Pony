using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class enemybulletwork : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject blood;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 67)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Health player = other.GetComponent<Health>();
            player.TakeDamage();
            GameObject bloodEffect = Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(bloodEffect, 0.2f);
        }
    }
}
