using System.Collections;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Helpers
{
    public static IEnumerator FadeAlphaIn(CanvasGroup canvasGroup, float duration)
    {
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime / duration;
            yield return null;
        }
    }

    public static IEnumerator FadeAlphaOut(CanvasGroup canvasGroup, float duration)
    {
        while (canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= Time.deltaTime / duration;
            yield return null;
        }
    }

    public static string DialogueLineToHash(string line)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(line)))
        {
            sb.Append(b.ToString("X2"));
        }
        return sb.ToString();
    }

    public static void PersistVars(Cradle.Story story)
    {
        PlayerPrefs.SetInt("thoughts_taught", story.Vars["thoughts_taught"]); 
        PlayerPrefs.SetInt("stats_taught", story.Vars["stats_taught"]);
        PlayerPrefs.SetInt("ending_1_completed", story.Vars["ending_1_completed"]);
        PlayerPrefs.SetInt("ending_2_completed", story.Vars["ending_2_completed"]);
        PlayerPrefs.SetInt("ending_3_completed", story.Vars["ending_3_completed"]);
    }
}
