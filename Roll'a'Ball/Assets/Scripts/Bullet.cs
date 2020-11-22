using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float secToDespawn;
    public float force;

    private DateTime endTime;
    private TimeSpan delta;

    void Start()
    {
        endTime = DateTime.Now.AddSeconds(secToDespawn);
    }

    void Update()
    {
        delta = endTime - DateTime.Now;
        if (delta.TotalSeconds <= 0)
            Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * force), Space.Self);
    }
}
