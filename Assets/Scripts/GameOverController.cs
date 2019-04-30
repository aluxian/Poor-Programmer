using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static Helpers;

public class GameOverController : MonoBehaviour
{
    public Text description;
    public CanvasGroup panel;

    void Start()
    {
        panel.alpha = 0f;
    }

    public void ShowGameOver(string desc)
    {
        StartCoroutine(ShowGameOverAsync(desc));
    }

    private IEnumerator ShowGameOverAsync(string desc)
    {
        panel.interactable = true;
        panel.blocksRaycasts = true;
        description.text = desc;
        yield return FadeAlphaIn(panel, 1f);
    }
}
