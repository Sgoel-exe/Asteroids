using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumAsteroid : abstractAsteroid
{
    public GameObject asteroid;
    private Rigidbody2D rb;
    public override void die()
    {
        float spawn = Random.Range(0f, 2f);
        for(float i = 0f; i < spawn; i++)
        {
            GameObject temp = Instantiate(asteroid, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(5f,5f), ForceMode2D.Force);
        }

        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
