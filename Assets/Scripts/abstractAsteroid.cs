using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

abstract public class abstractAsteroid : MonoBehaviour
{
    public float minVelocity = 10f;
    public float maxVelocity = 30f;
    public float AngularVelocity = 10f;
    public abstract void die();
    public abstract void setTrajectory(Vector2 direction);
    public float calculateVelocity()
    {
        return Random.Range(minVelocity, maxVelocity);
    }

    public float calculateTorque()
    {
        return Random.Range(-AngularVelocity, AngularVelocity);
    }
}
