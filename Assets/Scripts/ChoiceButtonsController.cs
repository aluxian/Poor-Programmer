using Cradle;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Helpers;

public class ChoiceButtonsController : MonoBehaviour
{
    public Story story;
    public Button buttonPrefab;

    private CanvasGroup canvasGroup;
    private bool choiceButtonsPendingToShow;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        story.OnOutput += Story_OnOutput;
        story.OnPassageDone += Story_OnPassageDone;
    }

    private void Story_OnOutput(StoryOutput output)
    {
        // set a flag so the next time OnPassageDone runs we show the buttons
        if (output is StoryLink)
        {
            choiceButtonsPendingToShow = true;
        }
    }

    private void Story_OnPassageDone(StoryPassage storyPassage)
    {
        // only show if there is a preceding link output
        if (!choiceButtonsPendingToShow)
        {
            return;
        }

        // avoid problems if OnPassageDone is called twice
        choiceButtonsPendingToShow = false;

        // instantiate buttons
        int yOffset = 0;
        foreach (StoryLink storyLink in Enumerable.Reverse(story.GetCurrentLinks()))
        {
            Button button = Instantiate(buttonPrefab, transform);
            button.transform.localPosition = new Vector3(0, yOffset, 0);
            button.onClick.AddListener(() => StartCoroutine(ButtonClicked(button, storyLink)));
            button.GetComponentInChildren<Text>().text = storyLink.Name + "...";
            yOffset += 150;
        }

        // fade in
        canvasGroup.alpha = 0f;
        StartCoroutine(FadeAlphaIn(canvasGroup, 0.5f));
    }

    private IEnumerator ButtonClicked(Button button, StoryLink storyLink)
    {
        // ensure no other button can be clicked
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        // unhighlight
        EventSystem.current.SetSelectedGameObject(null);

        // fade out
        canvasGroup.alpha = 1f;
        yield return FadeAlphaOut(canvasGroup, 0.5f);

        // delete buttons
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        // continue story
        story.DoLink(storyLink);
    }
}
