using Cradle;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static Helpers;

public class DialogueTextController : MonoBehaviour
{
    public Story story;
    public AudioSource audioSource;

    private Text dialogueText;

    void Start()
    {
        dialogueText = GetComponent<Text>();
        dialogueText.text = "";
        dialogueText.CrossFadeAlpha(0f, 0f, true);

        story.OnOutput += Story_OnOutput;
    }

    private void Story_OnOutput(StoryOutput output)
    {
        if (!Debug.isDebugBuild || !Input.GetMouseButton(0))
        {
            StartCoroutine(DisplayOutput(output));
        }
    }

    private IEnumerator DisplayOutput(StoryOutput output)
    {
        if (output is LineBreak)
        {
            // tell story enumerator to wait before emitting next outputs
            story.Pause();

            // just add a pause on line break
            yield return new WaitForSeconds(0.3f);

            // tell story to continue
            story.Resume();
        }

        if (output is StoryText)
        {
            // tell story enumerator to wait before emitting next outputs
            story.Pause();

            // delay hack
            if (output.Text.StartsWith("delay"))
            {
                float duration = float.Parse(output.Text.Split(' ')[1]);
                yield return new WaitForSeconds(duration);
            } else
            {
                // set text
                dialogueText.text = output.Text;

                // fade in
                dialogueText.CrossFadeAlpha(1f, 0.3f, false);
                yield return new WaitForSeconds(0.3f);

                // delay for display
                audioSource.clip = Resources.Load<AudioClip>("Speech/" + DialogueLineToHash(output.Text));
                if (audioSource.clip == null)
                {
                    Debug.Log("not found: Speech/" + DialogueLineToHash(output.Text));
                }
                audioSource.Play();
                yield return new WaitForSeconds(audioSource.clip.length);

                // fade out
                dialogueText.CrossFadeAlpha(0f, 0.3f, false);
                yield return new WaitForSeconds(0.3f);

                // clear text
                dialogueText.text = "";
            }

            // tell story to continue
            story.Resume();
        }
    }
}
