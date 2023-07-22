using System;
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
    public InputAction Flip;

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

    //Particle Things
    public ParticleSystem propulsion;
    public float whenBackingRotation = 68f;
    public float whenForwardRotation = 248f;

    //Flip things
    private bool isForward = true;


    private void OnEnable()
    {
        Movement.Enable();
        Rotation.Enable();

        Flip.Enable();
        Flip.performed += flip;
    }

    private void OnDisable()
    {
        Movement.Disable();
        Rotation.Disable();
        Flip.Disable();
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

        if(Movement.IsInProgress())
        {
            propulsion.Play();
        }
        else
        {
            propulsion.Pause();
            propulsion.Clear();
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
        if (Movement.IsInProgress())
        {
            rb.AddRelativeForce(new Vector2(0, moveSpeed), ForceMode2D.Force);
        }
        
    }

    void Rotating()
    {
        //rb.AddTorque(Rotation.ReadValue<float>() * rotationSpeed * Time.deltaTime);
        rb.angularVelocity = Rotation.ReadValue<float>() * maxAngularVelocity;
    }

    private void flip(InputAction.CallbackContext context)
    {
        if (isForward)
        {
            transform.Rotate(0f, 0f, transform.rotation.z + 180f);
            isForward = false;
        }
        else
        {
            transform.Rotate(0f, 0f, transform.rotation.z - 180f);
            isForward = true;
        }
        
    }

    public void DisableControls()
    {
        rb.velocity = new Vector2(0f, 0f);
        rb.angularVelocity = 0f;
        Movement.Disable();
        Rotation.Disable();
        Flip.Disable();
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
