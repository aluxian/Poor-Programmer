using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IllustrationPanelController : MonoBehaviour
{
    public Image image;
    public Image mask;
    public Text uiText;

    void Start()
    {
        image.CrossFadeAlpha(0f, 0f, true);
        uiText.CrossFadeAlpha(0f, 0f, true);
    }

    internal IEnumerator ShowImage(string name)
    {
        // load the image
        ResourceRequest request = Resources.LoadAsync<Sprite>("Images/" + name);
        while (!request.isDone)
        {
            yield return null;
        }
        image.sprite = request.asset as Sprite;

        // fade in
        image.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(1f);
    }

    internal IEnumerator HideImage()
    {
        // fade out
        image.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);

        // unload image
        image.sprite = null;
    }

    internal IEnumerator ShowText(string val)
    {
        // set text
        uiText.text = val;

        // fade in
        uiText.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(1f);

        // pause
        yield return new WaitForSeconds(3f);

        // fade out
        uiText.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
    }
}
