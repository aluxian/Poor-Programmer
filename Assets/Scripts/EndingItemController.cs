using UnityEngine;
using UnityEngine.UI;

public class EndingItemController : MonoBehaviour
{
    public Image panel;
    public Text description;
    public Text discovered;

    void Start()
    {
        ShowNotDiscovered();
    }

    public void ShowNotDiscovered()
    {
        // change panel bg color
        panel.color = new Color(0.166651f, 0.5520316f, 0.664f, 0.6156863f);

        // show status
        discovered.enabled = true;

        // lower opacity
        description.GetComponent<CanvasGroup>().enabled = true;

        // enable typewriter
        description.GetComponent<TW_RandomText>().enabled = true;
    }

    public void ShowDiscovered(string desc)
    {
        // restore text
        description.text = desc;

        // change panel bg color
        panel.color = new Color(0.2509804f, 0.8313726f, 1f, 0.6156863f);

        // hide status
        discovered.enabled = false;

        // restore opacity
        description.GetComponent<CanvasGroup>().enabled = false;

        // disable typewriter
        description.GetComponent<TW_RandomText>().enabled = false;
    }
}
