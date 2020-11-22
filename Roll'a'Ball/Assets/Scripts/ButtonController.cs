using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Boolean isPushing;
    public Boolean isPushed = false;
    private float startBtnPos;
    private GameObject btn;

    void Start()
    {
        btn = transform.Find("Activator").gameObject;
        startBtnPos = btn.transform.position.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPushing = true;
        }
    }

    void Push()
    {
        if (btn.transform.position.x <= (startBtnPos + 0.28))
            btn.transform.Translate(Vector3.down * (Time.deltaTime * 0.3f));
        else
            isPushing = false;

        isPushed = true;
    }

    private void Update()
    {
        if (isPushing)
            Push();
    }
}
