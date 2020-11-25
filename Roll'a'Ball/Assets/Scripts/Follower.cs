using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Follower : MonoBehaviour
{
    public GameObject player;
    public float MouseSens = 0.14f;

    private Vector3 offset;
    private PlayerController controller;

    void Start()
    {
        offset = transform.position - player.transform.position;
        controller = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!player.GetComponent<PlayerController>().isDead)
        {
            transform.position = player.transform.position + offset;
            transform.Rotate(0, controller.getCameraMovementX() * MouseSens, 0);
        }
    }
}
