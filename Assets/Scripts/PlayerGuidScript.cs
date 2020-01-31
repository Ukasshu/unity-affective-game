using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuidScript : MonoBehaviour
{
    public string playerGuid;

    void Awake()
    {
        this.playerGuid = System.Guid.NewGuid().ToString();
        DontDestroyOnLoad(this.gameObject);
    }
}
