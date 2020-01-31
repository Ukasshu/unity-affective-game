using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public MoveScript playerController;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && playerController.coinsText.text == "Coins: 4/4") {
            playerController.gameOver = true;
            playerController.gameSpeed = 0;

            playerController.restartButton.gameObject.SetActive(true);
            playerController.opinionButton.gameObject.SetActive(true);

            //INNY GUZIK DO ANKIET TRUE  - to samo do game overa
            
        }

    }
    
}
