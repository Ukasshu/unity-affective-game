using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingTile : MonoBehaviour
{
    public MoveScript playerController;
    Vector3 initPos;
    float position = 0;
    float velocity = 1;

    System.Random rnd = new System.Random();

    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position = position + velocity * (3.5f * Convert.ToSingle(Math.Cos(position)) + 3f) * Time.deltaTime * playerController.gameSpeed;
        if (position >= 3.14/2)
        {
            velocity = -1;
        } 
        else if(position <= -3.14/2)
        {
            velocity = 1;
        }

        Vector3 pos = transform.position;
        transform.position = new Vector3(initPos.x - position, initPos.y, initPos.z);
    }
}
