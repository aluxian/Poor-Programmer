using System.Collections;
using UnityEngine;

public class CameraGlitchAnimator : MonoBehaviour
{
    public ShaderEffect_BleedingColors bleedingColors;
    public ShaderEffect_CorruptedVram corruptedVram;
    public ShaderEffect_CRT CRT;

    private System.Random rnd = new System.Random();

    void Start()
    {
        StartCoroutine(AnimateEveryRandomPeriod());
    }

    IEnumerator AnimateEveryRandomPeriod()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            switch (rnd.Next(3))
            {
                case 0:
                    yield return AnimateGlitch(bleedingColors, 0.5f);
                    break;
                case 1:
                    yield return AnimateGlitch(corruptedVram, 0.05f);
                    break;
                case 2:
                    yield return AnimateGlitch(CRT, 0.02f);
                    break;
            }
        }
    }

    IEnumerator AnimateGlitch(ShaderEffect_BleedingColors effect, float duration)
    {
        effect.enabled = true;
        float target = Random.Range(0.1f, 1f);
        effect.intensity = 0;
        effect.shift = 0;
        while (effect.intensity < target)
        {
            effect.intensity += Time.deltaTime / duration;
            effect.shift = effect.intensity;
            yield return null;
        }
        effect.enabled = false;
    }

    IEnumerator AnimateGlitch(ShaderEffect_CorruptedVram effect, float duration)
    {
        effect.enabled = true;
        float target = Random.Range(0.1f, 2f);
        effect.shift = 0;
        while (effect.shift < target)
        {
            effect.shift += Time.deltaTime / duration;
            yield return null;
        }
        effect.enabled = false;
    }

    IEnumerator AnimateGlitch(ShaderEffect_CRT effect, float duration)
    {
        effect.enabled = true;
        float target = Random.Range(15f, 30f);
        effect.scanlineIntensity = 0;
        effect.scanlineWidth = 0;
        while (effect.scanlineIntensity < target)
        {
            effect.scanlineIntensity += Time.deltaTime / duration;
            effect.scanlineWidth = Mathf.RoundToInt(effect.scanlineIntensity / 3) - 4;
            yield return null;
        }
        effect.enabled = false;
    }
}
