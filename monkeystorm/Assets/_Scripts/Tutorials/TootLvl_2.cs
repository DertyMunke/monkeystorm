using UnityEngine;
using System.Collections;

public class TootLvl_2 : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        if (GameManager.gameManagerScript.TootLvl_1)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }
}
