using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public ButtonController button;

    private GameObject segment1;
    private GameObject segment2;
    private Boolean isClosed = false;
    // Start is called before the first frame update
    void Start()
    {
        segment1 = transform.Find("Segment (1)").gameObject;
        segment2 = transform.Find("Segment (2)").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (button.isPushed && !isClosed)
        {
            CloseBridge();
        }
    }
    void CloseBridge()
    {
        
        if (segment1.transform.rotation.x >= -0.5)
            segment1.transform.Rotate(new Vector3(-20, 0, 0) * Time.deltaTime);
        
        if (segment2.transform.rotation.x <= 0.5)
            segment2.transform.Rotate(new Vector3(20, 0, 0) * Time.deltaTime);
        
        if (segment2.transform.rotation.x >= 0.5 && segment1.transform.rotation.x <= -0.5)
            isClosed = true;
        
    }
}
