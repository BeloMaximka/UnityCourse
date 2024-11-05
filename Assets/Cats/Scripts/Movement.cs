using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rb2d.AddForce(Vector2.up * 3);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2d.AddForce(Vector2.down * 3);
            rb2d.AddTorque(2);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddForce(Vector2.left * 3);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddForce(Vector2.right * 3);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            rb2d.angularVelocity = 0f;
            rb2d.linearVelocity = Vector2.zero;
        }
    }
}
