using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTrigger : MonoBehaviour
{
    public GameObject anotherObject;
    public float posx = 0;
    public float posy = 0;

    bool used = false;
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !used) {
            used = true;
            Vector3 pos = gameObject.transform.position;
            anotherObject.transform.position = new Vector3(posx, posy, pos.z);
            
        }

    }
}
