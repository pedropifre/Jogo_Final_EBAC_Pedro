using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using GeneralUtils.Core.Singleton;

public class EffectsManager : Singleton<EffectsManager>
{
    public PostProcessVolume processVolume;
    [SerializeField] private Vignette _vignette;
    public float duration;


    [NaughtyAttributes.Button]
    public void ChangeVignette()
    {
        StartCoroutine(FlashColorVignette());   
    }

    IEnumerator FlashColorVignette()
    {
        Vignette tmp;

        if (processVolume.profile.TryGetSettings<Vignette>(out tmp))
        {
            _vignette = tmp;
        }
        ColorParameter c = new ColorParameter();

        float time = 0;
        while (time < duration)
        {
            c.value = Color.Lerp(Color.black , Color.red , time / duration);
            time += Time.deltaTime;
            _vignette.color.Override(c);
            yield return new WaitForEndOfFrame();
        }

        time = 0;
        while (time < duration)
        {
            c.value = Color.Lerp(Color.red , Color.black , time / duration);
            time += Time.deltaTime;
            _vignette.color.Override(c);
            yield return new WaitForEndOfFrame();
        }


    }
}
