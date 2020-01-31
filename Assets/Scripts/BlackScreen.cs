using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlackScreen : MonoBehaviour
{
    public MoveScript playerController;
    float time = 0;
    System.Random rnd = new System.Random();

    float opacity = 0.0f;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime * playerController.gameSpeed;

        if (time <= 0)
        {
            opacity = 1f;
            time = rnd.Next(1, 15);
        }

        if (opacity > 0)
        {
            opacity = opacity - 0.1f * Time.deltaTime * playerController.gameSpeed;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
        }
    }
}
