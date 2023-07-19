using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMoment : MonoBehaviour
{
    [Header("Inputs")]
    //PlayerComponents
    private Rigidbody2D rb;

    public InputAction Movement;
    public InputAction Rotation;

    private Renderer[] renderers;

    [Header("PlayerMoment")]
    //Movement related stuff;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float maxVelocity = 35f;
    [SerializeField] private float maxAngularVelocity = 50f;

    //Screen Wrap Stuff
    [Header("Screen Wrap")]
    public float screenHeight;
    public float screenWidth;


    private void OnEnable()
    {
        Movement.Enable();
        Rotation.Enable();
    }

    private void OnDisable()
    {
        Movement.Disable();
        Rotation.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude >= maxVelocity)
        {
           rb.velocity = rb.velocity.normalized * maxVelocity;
        }
        if(Mathf.Abs(rb.angularVelocity) >= maxAngularVelocity)
        {
            rb.angularVelocity = Mathf.Sign(rb.angularVelocity)*maxAngularVelocity;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Rotating();
        ScreenWrap();
    }

    void Move()
    {
        rb.AddRelativeForce(new Vector2(0, Movement.ReadValue<float>() * moveSpeed), ForceMode2D.Force);
    }

    void Rotating()
    {
        rb.AddTorque(Rotation.ReadValue<float>() * rotationSpeed * Time.deltaTime);
    }

    private void ScreenWrap()
    {
        Vector3 pos = transform.position;

        if(Mathf.Abs(pos.y) > screenHeight)
        {
            pos.y = -pos.y;
        }

        if(Mathf.Abs(pos.x) > screenWidth)
        {
            pos.x = -pos.x;
        }

        transform.position = pos;
    }
}
