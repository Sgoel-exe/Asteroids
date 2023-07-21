using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SmallAsteroid : abstractAsteroid
{
    private Rigidbody2D rb;
    public float speed = 15f;

    public float deathTime = 30f;

    public GameObject asteroidDestroy;

    public UnityEvent asteroidDie;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.eulerAngles = new Vector3(0f,0f, Random.Range(0f,360f));
        float scaleX = Random.Range(-0.25f, 0.75f);
        float scaleY = Random.Range(-0.25f, 0.75f);
        transform.localScale = new Vector2(transform.localScale.x + scaleX, transform.localScale.y + scaleY);

        asteroidDie.AddListener(GameObject.FindGameObjectWithTag("GameScorel").GetComponent<Scoreing>().AddScore);
        asteroidDie.AddListener(GameObject.FindGameObjectWithTag("UIController").GetComponent<UIcontoller>().UpdateScore);
    }

    public override void die()
    {
        Vector3 particlePosition = transform.position;
        particlePosition.z = -1f;
        Instantiate(asteroidDestroy, particlePosition, this.transform.rotation);
        asteroidDie.Invoke();
        Destroy(gameObject);
    }

    public override void setTrajectory(Vector2 direction, bool moreSpeed = false)
    {
        float spe = 1f;
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
