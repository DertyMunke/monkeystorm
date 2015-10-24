using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UIEvents : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject setting;
    public GameObject Record;
    public GameObject Rankings;
    public Texture[] BGTextures;
    public UITexture BG;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPlayClick()
    {
        //Application.LoadLevel("name");
    }

    public void OnSettingClick()
    {
        BG.mainTexture = BGTextures[1];
        mainMenu.SetActive(false);
        setting.transform.DOMoveX(0, 0.3f);
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
        setting.transform.DOMoveX(795/360, 0.3f);
        setting.SetActive(false);
        mainMenu.transform.DOMoveX(0, 0.3f);
        mainMenu.SetActive(true);
    }

    public void OnRecordBacklClick()
    {
        BG.mainTexture = BGTextures[0];
        Record.SetActive(false);
        Record.transform.DOMoveX(795/360, 0.3f);
        mainMenu.transform.DOMoveX(0, 0.3f);
        mainMenu.SetActive(true);
    }

    public void OnRecordClick()
    {
        BG.mainTexture = BGTextures[1];
        setting.SetActive(false);
        Rankings.transform.DOMoveX(0, 0.3f);
    }
}
