using UnityEngine;

public class Bg : MonoBehaviour
{
    private float length;
    public float speed = 5f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -67)
        {
            transform.position = new Vector3(67, transform.position.y, transform.position.z);
        }
    }
}
