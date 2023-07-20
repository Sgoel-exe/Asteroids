using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeAsteroids : abstractAsteroid
{
    public abstractAsteroid[] asteroids;
    private Rigidbody2D rb;
    public float speed = 10f;
    private Vector2 dir;

    public GameObject asteroidDestroy;

    public float deathTime = 30f;
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
            int temp = Random.Range(0f, 1f) < 0.6f ? 0 : 1;
            
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * 0.5f;
            Vector3 spawnPosition = transform.position + spawnDirection;
            spawnPosition.z = 0f;

            abstractAsteroid asteroid = Instantiate(asteroids[temp], spawnPosition, this.transform.rotation);
            asteroid.setTrajectory(Random.insideUnitCircle.normalized, true);
        }
        Vector3 particlePosition = transform.position;
        particlePosition.z = -1f;
        Instantiate(asteroidDestroy, particlePosition, this.transform.rotation);
        Destroy(gameObject);
    }

    public override void setTrajectory(Vector2 direction, bool moreSpeed = false)
    {
        float spe = 1f;
        dir = direction;
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        if (moreSpeed)
        {
            spe = 10f;
        }
        rb.AddForce(direction * speed * spe, ForceMode2D.Force);
        Destroy(gameObject, deathTime);
    }
}
