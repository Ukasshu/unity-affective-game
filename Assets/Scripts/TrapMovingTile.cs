using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMovingTile : MonoBehaviour
{
    bool moving = false;
    void Update()
    {
        if (moving)
        {
            Vector3 pos = transform.position;

            pos.y = pos.y + 10 * Time.deltaTime;

            transform.position = pos;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            moving = true;

            GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
