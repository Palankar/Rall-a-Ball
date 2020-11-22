using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public float speed;

    private Boolean toRight;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.GetChild(0).position.x <= transform.GetChild(1).position.x)
            toRight = true;
        if (transform.GetChild(0).position.x >= transform.GetChild(2).position.x)
            toRight = false;

        Moving();
    }

    private void Moving()
    {
        if (toRight)
            transform.GetChild(0).Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
        else
            transform.GetChild(0).Translate(-Vector3.right * Time.deltaTime * speed, Space.Self);

    }
}
