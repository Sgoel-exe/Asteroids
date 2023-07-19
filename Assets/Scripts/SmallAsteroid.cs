using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroid : abstractAsteroid
{
    private Rigidbody2D rb;

    public override void die()
    {
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
