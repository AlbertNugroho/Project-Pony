using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletwork : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public GameObject blood;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 67)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            EvilAI enemy = other.GetComponent<EvilAI>();
            enemy.TakeDamage();
            GameObject bloodEffect = Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(bloodEffect, 0.2f);
        }
    }
}
