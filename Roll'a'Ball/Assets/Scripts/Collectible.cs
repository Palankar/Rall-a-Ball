using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Boolean isUp;
    private float downPos;
    private float upPos;

    public float offsetRange;
    public float offsetSpeed;


    void Start()
    {
        isUp = true;
        downPos = transform.position.y - offsetRange;
        upPos = transform.position.y + offsetRange;
    }

    // Update is called once per frame
    void Update()
    {
        //Отличный способ сгладить движения - умножать на дельту, что представляет из себя время в сек. с последнего обновления кадров
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime); 
       
        if (transform.position.y >= upPos)
            isUp = false;
        if (transform.position.y <= downPos)
            isUp = true;

        Levitate(isUp);
    }

    //Левитация по оси Y. При isUp = true - подъем, иначе падение
    private void Levitate(Boolean isUp)
    {
        if (isUp)
            transform.Translate(Vector3.up * (Time.deltaTime * offsetSpeed), Space.World);
        else
            transform.Translate(Vector3.down * (Time.deltaTime * offsetSpeed), Space.World);
    }
}
