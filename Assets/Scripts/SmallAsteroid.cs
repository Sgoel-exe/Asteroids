using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroid : abstractAsteroid
{
    private Rigidbody2D rb;
    public float speed = 15f;

    public float deathTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.eulerAngles = new Vector3(0f,0f, Random.Range(0f,360f));
        float scaleX = Random.Range(-0.25f, 0.75f);
        float scaleY = Random.Range(-0.25f, 0.75f);
        transform.localScale = new Vector2(transform.localScale.x + scaleX, transform.localScale.y + scaleY);
    }

    public override void die()
    {
        Destroy(gameObject);
    }

    public override void setTrajectory(Vector2 direction)
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        rb.AddForce(direction * speed, ForceMode2D.Force);
        Destroy(gameObject, deathTime);
    }
}
