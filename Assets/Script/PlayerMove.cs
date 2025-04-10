using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public InputActionReference move;
    public float speed = 5f;
    private Rigidbody rb;
    private Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();

    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveDirection.x , moveDirection.y);
        rb.velocity = movement * speed;
    }
}
