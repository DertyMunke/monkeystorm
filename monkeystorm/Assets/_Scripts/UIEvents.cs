﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UIEvents : MonoBehaviour
{
    //Main menu
    public GameObject mainMenu;
    public GameObject setting;
    public GameObject Record;
    public GameObject Rankings;
    public Texture[] BGTextures;
    public UITexture BG;
    //Game menu
    public GameObject gameMenu;
   
    public UILabel timerLabel;
    public UILabel scoreLabel;
    public UILabel levelLabel;

    public static UIEvents uiEventsScript;
    public UITexture[] hearts;
    public UILabel gameOva;
    public UILabel playBtnLbl;

    private bool loseHeart = true;
    private bool restartLvl = false;
    private int heartIndex;

    public bool LoseHeart { get { return loseHeart; } }

    /// <summary>
    /// Returns the timer value as an integer
    /// </summary>
    public int Timer {
        get
        {
            int timer;
            int.TryParse(timerLabel.text, out timer);
            return timer;
        }
    }

    /// <summary>
    /// Returns a score integer and takes a integer that is added to the score and displayed
    /// </summary>
    public int Score {
        get
        {
            int score = 0;
            int.TryParse(scoreLabel.text, out score);
            return score;
        }
        set
        {
            int score = 0;
            int.TryParse(scoreLabel.text, out score);
            scoreLabel.text = (score + value).ToString() ;
        }
    }

    private void Awake()
    {
        uiEventsScript = this;
        heartIndex = hearts.Length - 1;
    }

    private void Start()
    {
        if (Application.loadedLevelName != "Main Menu")
        {
            GameInstance.timer = 0;
            scoreLabel.text = GameManager.gameManagerScript.Score.ToString();
            levelLabel.text = GameManager.gameManagerScript.Level.ToString();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevelName != "Main Menu")
        {
            GameInstance.timer += Time.deltaTime;
            timerLabel.text = ((int)GameInstance.timer).ToString();

            //scoreLabel.text = GameInstance.currentScore.ToString();

            //for (int i = 0; i < hearts.Length; i++)
            //{
            //    hearts[i].gameObject.SetActive(false);
            //}
            //for (int i = 0; i < GameInstance.currentHP; i++)
            //{
            //    hearts[i].gameObject.SetActive(true);
            //}
        }
    }

    #region MainMenu
    public void OnPlayClick()
    {
        Application.LoadLevel("Level1");
    }

    public void OnSettingClick()
    {
        BG.mainTexture = BGTextures[1];
        mainMenu.SetActive(false);
        setting.transform.DOLocalMoveX(0, 0.3f);
        setting.SetActive(true);

    }

    public void OnBGMClick()
    {
        UIButton.current.transform.FindChild("BGMSliders").gameObject.SetActive(true);
    }

    public void OnBGMSlidersCancel()
    {
        UIEventTrigger.current.gameObject.SetActive(false);
    }

    public void OnMusicSliderValueChange()
    {
        GameInstance.volum = UISlider.current.value;
        Debug.Log(GameInstance.volum);
    }

    public void OnHelpClick()
    {
        UIButton.current.transform.FindChild("HelpMenu").gameObject.SetActive(true);
    }

    public void OnHelpMenuCancel()
    {
        UIEventTrigger.current.gameObject.SetActive(false);
    }

    public void OnLoadClick()
    {
        BG.mainTexture = BGTextures[1];
        mainMenu.SetActive(false);
        Record.transform.DOMoveX(0, 0.3f);
        Record.SetActive(true);
    }

    public void OnMenuClick()
    {
        BG.mainTexture = BGTextures[0];
        setting.transform.DOMoveX(795 / 360, 0.3f);
        setting.SetActive(false);
        mainMenu.transform.DOMoveX(0, 0.3f);
        mainMenu.SetActive(true);
    }

    public void OnRecordBacklClick()
    {
        BG.mainTexture = BGTextures[0];
        Record.SetActive(false);
        Record.transform.DOMoveX(795 / 360, 0.3f);
        mainMenu.transform.DOMoveX(0, 0.3f);
        mainMenu.SetActive(true);
    }

    public void OnRecordClick()
    {
        BG.mainTexture = BGTextures[1];
        setting.SetActive(false);
        Rankings.transform.DOMoveX(0, 0.3f);
        Rankings.SetActive(true);
    }

    public void OnRankingBackClick()
    {
        BG.mainTexture = BGTextures[0];
        Rankings.SetActive(false);
        Rankings.transform.DOMoveX(795 / 360, 0.3f);
        mainMenu.transform.DOMoveX(0, 0.3f);
        mainMenu.SetActive(true);
    }
    #endregion

    #region GameMenu
    public void OnPauseClick()
    {
        Time.timeScale = 0; // game pause
        gameMenu.SetActive(true);
    }

    public void OnGameMenuPlayClick()
    {
        Time.timeScale = 1; //resume
        if (restartLvl)
            Application.LoadLevel(Application.loadedLevelName);
        else
            gameMenu.SetActive(false);
    }

    public void OnSaveClick()
    { }

    public void OnMainMenuSettingClick()
    {

    }

    public void OnQuitClick()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Main Menu");
    }

    /// <summary>
    /// Removes a heart from the UI when damage received. Returns true if there are hearts to lose
    /// </summary>
    public bool  RemoveHeart()
    {
        if(loseHeart)
        {
            hearts[heartIndex].enabled = false;
            heartIndex--;
            if (heartIndex < 0)
            {
                gameOva.enabled = true;
                playBtnLbl.text = "Restart Level";
                restartLvl = true;
                OnPauseClick();
                return false;
            }
            loseHeart = false;
            Invoke("StopRemoveHeart", .5f);
        }

        return true;
    }

    /// <summary>
    /// Allows to set a time between losing hearts, so you don't lose multiple in one hit
    /// </summary>
    private void StopRemoveHeart()
    {
        loseHeart = true;
    }
    #endregion
}
