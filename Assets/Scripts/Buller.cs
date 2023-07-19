using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buller : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(new Vector2(0, 60f), ForceMode2D.Impulse);

        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Asteroid"))
            {
                collision.SendMessage("die");
                Destroy(gameObject);
            }
        }
    }
}
