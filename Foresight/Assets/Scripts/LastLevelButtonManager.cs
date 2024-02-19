using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
public class LastLevelButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject button01, button02, header;
    [SerializeField] private Animator animSceneChange;
    private AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();    
        if (button01 != null && button02 != null)
        {
            StartCoroutine(SetActiveObjects());
        }
    }


    public void GoMainMenu()
    {
        StartCoroutine(GoMainMenuNum());
        audioManager.PlayAudioClip(audioManager.movementSound);
    }

    public void ClickQuit()
    {
        audioManager.PlayAudioClip(audioManager.movementSound);
        Application.Quit();
    }

    public void ClickPlay()
    {
        audioManager.PlayAudioClip(audioManager.movementSound);
        StartCoroutine(ClickedPlay());
    }

    IEnumerator GoMainMenuNum()
    {
        animSceneChange.SetTrigger("Dead");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }

    IEnumerator SetActiveObjects()
    {
        yield return new WaitForSeconds(2f);
        header.SetActive(true);
        button01.SetActive(true);
        button02.SetActive(true);
    }

    IEnumerator ClickedPlay()
    {
        animSceneChange.SetTrigger("Dead");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

}
