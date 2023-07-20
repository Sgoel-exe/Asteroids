using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    //PlayerInput
    public InputAction Shoot;

    //Game object refrences
    [Header("Game object refs")]
    public Transform shootPoint;
    public GameObject bullet;

    //Shoot Mechanic related stuff
    [Header("Shoot mechanics")]
    [SerializeField] private float fireRate = 0.25f;
    private bool canShoot = true;
    private float timer;

    private void OnEnable()
    {
        Shoot.Enable();
        Shoot.performed += shoot;
    }

    private void OnDisable()
    {
        Shoot.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            timer += Time.deltaTime;
        }
        if (timer > fireRate)
        {
            canShoot = true;
        }
    }

    private void shoot(InputAction.CallbackContext context)
    {
        if(canShoot)
        {
            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            canShoot = false;
            timer = 0f;
        }
    }

}
