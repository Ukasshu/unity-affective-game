using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    bool active = true;
    public MoveScript playerController;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && active) {
            playerController.IncreaseCoins();
            
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            active = false; 
        }

    }
}
