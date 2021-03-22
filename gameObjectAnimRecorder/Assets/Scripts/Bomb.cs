using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 700f;

    private void Explode()
    {
        var rigidbodies = FindObjectsOfType<Rigidbody>();
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.AddExplosionForce(_explosionForce, transform.position, 10f);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Explode();
        }
    }
}
