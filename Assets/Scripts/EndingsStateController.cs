using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingsStateController : MonoBehaviour
{
    public EndingItemController ending1;
    public EndingItemController ending2;
    public EndingItemController ending3;

    void Start()
    {
        StartCoroutine(DelayedInit());
    }

    private IEnumerator DelayedInit()
    {
        yield return new WaitForSeconds(0.01f);
        
        // restore state based on which have been discovered
        if (PlayerPrefs.GetInt("ending_1_completed", 0) == 1)
        {
            ending1.ShowDiscovered("Vincent starts liking programming and now lives a happy life. Who could have known?");
        }
        if (PlayerPrefs.GetInt("ending_2_completed", 0) == 1)
        {
            ending2.ShowDiscovered("Vincent discovers what he really enjoys doing and starts a new career. Way to go!");
        }
        if (PlayerPrefs.GetInt("ending_3_completed", 0) == 1)
        {
            ending3.ShowDiscovered("Vincent gets sick. He is too tired to fight and depression ends his life. The grim end.");
        }
    }
}
