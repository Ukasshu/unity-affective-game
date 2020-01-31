using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    public MoveScript playerController;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            playerController.DeacreaseLives();
            
            if (playerController.lives == 0)
            {
                playerController.gameOver = true;
                playerController.gameSpeed = 0;
                playerController.restartButton.gameObject.SetActive(true);
                playerController.opinionButton.gameObject.SetActive(true);
            }

            playerController.verticalSpeed = 30;
            
        }

    }
}
