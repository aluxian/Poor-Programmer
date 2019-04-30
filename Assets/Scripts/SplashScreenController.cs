using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenController : MonoBehaviour
{
    public float timeoutSeconds;
    public LevelChanger levelChanger;
    public string nextSceneName;

    void Start()
    {
        StartCoroutine(SwitchLevelAfterDelay(timeoutSeconds));
    }

    private IEnumerator SwitchLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        levelChanger.LoadSceneAsyncWithFade(nextSceneName);
    }
}
