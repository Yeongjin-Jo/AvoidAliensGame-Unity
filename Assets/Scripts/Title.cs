using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{   
    [SerializeField] Image selectbarLeft_start;
    [SerializeField] Image selectbarRight_start;

    [SerializeField] Image selectbarLeft_quit;
    [SerializeField] Image selectbarRight_quit;

    [SerializeField] private AudioClip CursorEffectSound;

    [SerializeField] private string nextStageName;

    private AudioSource CursorEffectSounds;


    void Start()
    {
        selectbarLeft_start.enabled = false;
        selectbarRight_start.enabled = false;
        selectbarLeft_quit.enabled = false;
        selectbarRight_quit.enabled = false;

        CursorEffectSounds = GetComponent<AudioSource>();

        
    }
    public void QuitbuttonClick()
    {
        Application.Quit();
    }
    public void SelectingStart()
    {
        selectbarLeft_start.enabled = true;
        selectbarRight_start.enabled = true;
        
        CursorEffectSounds.PlayOneShot(CursorEffectSound, 1.0f);
    }
    public void NotSelectingStart()
    {
        selectbarLeft_start.enabled = false;
        selectbarRight_start.enabled = false;
    }
    public void SelectingQuit()
    {
        selectbarLeft_quit.enabled = true;
        selectbarRight_quit.enabled = true;

        CursorEffectSounds.PlayOneShot(CursorEffectSound, 1.0f);
    }
    public void NotSelectingQuit()
    {
        selectbarLeft_quit.enabled = false;
        selectbarRight_quit.enabled = false;
    }
    public void BackToTheTitle()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1.0f;
    }
    public void NextStageButton()
    {
        SceneManager.LoadScene(nextStageName);
        Time.timeScale = 1.0f;
    }
}
