using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumAsteroid : abstractAsteroid
{
    public abstractAsteroid asteroid;
    private Rigidbody2D rb;
    public float speed = 12.5f;
    private Vector2 dir;

    public float deathTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.eulerAngles = new Vector3(0f, 0f, Random.Range(0f, 360f));
        float scaleX = Random.Range(-0.25f, 0.75f);
        float scaleY = Random.Range(-0.25f, 0.75f);
        transform.localScale = new Vector2(transform.localScale.x + scaleX, transform.localScale.y + scaleY);
    }

    public override void die()
    {
        float spawn = Random.Range(0f, 2f);
        for (float i = 0f; i < spawn; i++)
        {
            abstractAsteroid temp = Instantiate(asteroid, transform.position, transform.rotation);
            temp.setTrajectory(dir);
        }

        Destroy(gameObject);
    }

    public override void setTrajectory(Vector2 direction)
    {
        dir = direction;
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        rb.AddForce(direction * speed, ForceMode2D.Force);
        Destroy(gameObject, deathTime);
    }
}
