using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntity : MonoBehaviour
{
    private int stage;
    private int points;
    public Vector3[] stageVectors;

    public int Points { get => points; set => points = value; }
    public int Stage { get => stage; set => stage = value; }
    public Vector3 this [int index]
    {
        get
        {
            return stageVectors[index];
        }
    }

    void Start()
    {
        Stage = 0;
        Points = 0;
    }


}
