using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public String countToOpen;
    public float speed;
    public float downPos;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countText.text.Contains("Count: " + countToOpen))
            OpenGate();

    }

    void OpenGate()
    {
        if (transform.position.y >= downPos)
            transform.Translate(Vector3.down * (Time.deltaTime * speed), Space.World);
    }
}
