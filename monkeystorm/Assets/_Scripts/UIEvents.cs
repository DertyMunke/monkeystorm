using UnityEngine;
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

    public UITexture[] hearts;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevelName != "Main Menu")
        {
            GameInstance.timer += Time.deltaTime;
            timerLabel.text = ((int)GameInstance.timer).ToString();

            scoreLabel.text = GameInstance.currentScore.ToString();

            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < GameInstance.currentHP; i++)
            {
                hearts[i].gameObject.SetActive(true);
            }
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
    #endregion
}
