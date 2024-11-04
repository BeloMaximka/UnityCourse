using UnityEngine;

public class AbsorbOnCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.isStatic)
        {
            Destroy(collision.gameObject);
            transform.localScale *= 1.3f;
        }
    }
}
