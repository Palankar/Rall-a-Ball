using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public float shootingSpeed;

    private Boolean isShooting;
    private Boolean isShoot = true;

    private void FixedUpdate()
    {
        if (isShooting)
        {
            StartCoroutine(Shooting());
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.LookAt(player.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isShooting = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isShooting = false;
    }

    private IEnumerator Shooting()
    {
        if (isShoot)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            isShoot = false;
            yield return new WaitForSeconds(shootingSpeed);
            isShoot = true;
        }
    }
}
