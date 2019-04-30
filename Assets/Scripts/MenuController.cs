using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    public LevelChanger levelChanger;

    // flag to prevent multiple clicks
    private bool disableClicks;

    public void OnClick_Start()
    {
        // behaviour common to all buttons
        OnClick();

        // switch level
        levelChanger.LoadSceneAsyncWithFade("Game");
    }

    public void OnClick_Menu()
    {
        // behaviour common to all buttons
        OnClick();

        // switch level
        levelChanger.LoadSceneAsyncWithFade("Menu");
    }

    public void OnClick_Endings()
    {
        // behaviour common to all buttons
        OnClick();

        // switch scene
        levelChanger.LoadSceneAsyncWithFade("Endings");
    }

    public void OnClick_Reset()
    {
        // behaviour common to all buttons
        OnClick();

        // clear prefs
        PlayerPrefs.DeleteAll();

        // switch level
        levelChanger.LoadSceneAsyncWithFade("Audio Splash Screen");
    }

    private void OnClick()
    {
        // prevent multiple clicks
        if (disableClicks)
        {
            return;
        }
        disableClicks = true;


        // unhighlight
        EventSystem.current.SetSelectedGameObject(null);

        // play sound
        audioSource.clip = clickSound;
        audioSource.Play();
    }
}
