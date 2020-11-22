using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject secondPlace;
    public Boolean isActive;
    private Teleporter otherTeleporter;

    private void Start()
    {
        otherTeleporter = secondPlace.GetComponent<Teleporter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isActive == true)
        {
            otherTeleporter.isActive = false;
            other.gameObject.transform.position = secondPlace.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isActive = true;
    }
}
