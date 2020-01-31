using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTile : MonoBehaviour
{

public float verticalSpeed = 0;
float opacity = 1.0f;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            verticalSpeed = 6;
            // GetComponent<BoxCollider>().isTrigger = false;
            
        }

    }

    // Update is called once per frame
    void Update()
    {   
        if(verticalSpeed != 0)
        {
            Vector3 position = transform.position;
            position.y -= verticalSpeed*Time.deltaTime;
            transform.position = position;
            opacity -= 0.1f;
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, opacity);
        }
    }
}
