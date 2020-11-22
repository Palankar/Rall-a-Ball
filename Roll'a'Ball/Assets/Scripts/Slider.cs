using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public float dragPower;

    private float slidePower;

    private void OnTriggerEnter(Collider other)
    {
            slidePower = other.gameObject.GetComponent<Rigidbody>().drag;
            other.gameObject.GetComponent<Rigidbody>().drag = dragPower;
    }

    private void OnTriggerExit(Collider other)
    {
            other.gameObject.GetComponent<Rigidbody>().drag = slidePower;
    }

}
