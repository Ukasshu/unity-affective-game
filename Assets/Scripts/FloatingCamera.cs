using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCamera : MonoBehaviour
{
    public MoveScript playerController;
    float verticalSpeed;


    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerController.transform.position;
        Vector3 pos = transform.position;

        float verticalSpeed = playerPos.y - pos.y;
        float horizontalSpeed = playerPos.x - pos.x;
        
        Vector3 newPos = new Vector3(pos.x + horizontalSpeed * Time.deltaTime, pos.y + verticalSpeed * Time.deltaTime, pos.z);

        transform.position = newPos;
    }
}
