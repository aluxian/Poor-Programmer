using System.Collections;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    private Story story;

    void Start()
    {
        story = GetComponent<Story>();
        StartCoroutine(BeginStory());
    }

    private IEnumerator BeginStory()
    {
        yield return new WaitForSeconds(0.2f);
        story.Vars["thoughts_taught"] = PlayerPrefs.GetInt("thoughts_taught", 0);
        story.Vars["stats_taught"] = PlayerPrefs.GetInt("stats_taught", 0);
        story.Vars["ending_1_completed"] = PlayerPrefs.GetInt("ending_1_completed", 0);
        story.Vars["ending_2_completed"] = PlayerPrefs.GetInt("ending_2_completed", 0);
        story.Vars["ending_3_completed"] = PlayerPrefs.GetInt("ending_3_completed", 0);
        story.Begin();
    }
}
