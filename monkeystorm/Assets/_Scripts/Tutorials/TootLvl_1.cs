using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TootLvl_1 : MonoBehaviour {

    private int tootStep = 0;

    public GameObject tootMenu;
    public UILabel topTootTxt;
    public UILabel botTootTxt;

	// Use this for initialization
	void Start ()
    {
        if (GameManager.gameManagerScript.TootLvl_1)
        {
            tootMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }

    private void Update()
    {
        if (tootStep < 6 && Input.GetMouseButtonDown(0))
        {
            TootStep();
        }
    }
	
    public void TootStep()
    {
        if(tootStep == 0)
        {
            tootStep++;
            topTootTxt.text = "To move Chacco from branch to branch";
            botTootTxt.text = "Simply swipe in the direction that you want him to move";
        }
        else if(tootStep == 1)
        {
            tootStep++;
            topTootTxt.text = "When Chacco spots a wall or ceiling branch for his new home";
            botTootTxt.text = "That branch will turn blue.";
        }
        else if (tootStep == 2)
        {
            tootStep++;
            topTootTxt.text = "While hanging onto a blue branch, tap the screen to break it,";
            botTootTxt.text = "Then bring it back to the start and add it to Chacco's home.";
        }
        else if (tootStep == 3)
        {
            tootStep++;
            topTootTxt.text = "Chacco can jump further if you swipe backward,";
            botTootTxt.text = "And then swipe forwards, without lifting your finger.";
        }
        else if (tootStep == 4)
        {
            tootStep++;
            topTootTxt.text = "Touch anywhere to begin";
            botTootTxt.text = "";
        }
        else if(tootStep == 5)
        {
            tootStep++;
            GameManager.gameManagerScript.TootLvl_1 = false;
            tootMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
