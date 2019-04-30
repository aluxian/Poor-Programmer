using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MacrosBehaviour : MonoBehaviour
{
    public GameOverController gameOverCtrl;
    public IllustrationPanelController illustrationPanel;
    public AudioSource backgroundMusic;
    public AudioSource soundPlayer;
    public Story story;
    public Text DM;
    public Text SH;

    public void showImage(string name)
    {
        StartCoroutine(illustrationPanel.ShowImage(name));
    }

    public void hideImage()
    {
        StartCoroutine(illustrationPanel.HideImage());
    }

    public void playMusic(string name)
    {
        StartCoroutine(playMusicAsync(name));
    }

    private IEnumerator playMusicAsync(string name)
    {
        ResourceRequest req = Resources.LoadAsync<AudioClip>("Music/" + name);
        while (!req.isDone)
        {
            yield return null;
        }
        backgroundMusic.clip = req.asset as AudioClip;
        backgroundMusic.Play();
    }

    public void stopMusic()
    {
        backgroundMusic.Stop();
    }

    public void elvesExeShowJobAdvert()
    {

    }

    public void protagonistWakeUp()
    {

    }

    public void theEndMeaningOfLife()
    {

    }

    public void showGameOver(string desc)
    {
        gameOverCtrl.ShowGameOver(desc);
    }

    public void setDM(string val)
    {
        StartCoroutine(SetBlinkTextAsync(DM, val, 1f));
    }

    public void setSH(string val)
    {
        StartCoroutine(SetBlinkTextAsync(SH, val, 1f));
    }

    private IEnumerator SetBlinkTextAsync(Text uiText, string newValue, float intensity)
    {
        uiText.CrossFadeAlpha(0f, 0.3f, false);
        yield return new WaitForSeconds(0.3f);
        uiText.text = newValue;
        uiText.CrossFadeAlpha(1f, 0.3f, false);
        yield return new WaitForSeconds(0.3f);
        uiText.CrossFadeAlpha(0f, 0.3f, false);
        yield return new WaitForSeconds(0.3f);
        uiText.CrossFadeAlpha(1f, 0.3f, false);
        yield return new WaitForSeconds(0.3f);
        uiText.CrossFadeAlpha(0f, 0.3f, false);
        yield return new WaitForSeconds(0.3f);
        uiText.CrossFadeAlpha(1f, 0.3f, false);
        yield return new WaitForSeconds(0.3f);
    }

    public void showText(string val)
    {
        StartCoroutine(illustrationPanel.ShowText(val));
    }

    public void playSound(string name)
    {
        StartCoroutine(PlaySoundAsync(name));
    }

    public void stopSound()
    {
        soundPlayer.Stop();
    }

    private IEnumerator PlaySoundAsync(string name)
    {
        ResourceRequest req = Resources.LoadAsync<AudioClip>("Sounds/" + name);
        while (!req.isDone)
        {
            yield return null;
        }
        soundPlayer.clip = req.asset as AudioClip;
        soundPlayer.Play();
    }

    public void delay(double seconds)
    {
        StartCoroutine(DelayAsync((float) seconds));
    }

    private IEnumerator DelayAsync(float seconds)
    {
        story.Pause();
        yield return new WaitForSeconds(seconds);
        story.Resume();
    }
}
