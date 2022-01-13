using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume_Control : MonoBehaviour
{
    public Slider Sound_Slider;
    public Slider Effect_Sound_Slider;

    public AudioMixer Audio_Mixer;

    public void Sound_Control()
    {
        float sound = Sound_Slider.value;

        if (sound == -40f) Audio_Mixer.SetFloat("Sound", -80);
        else Audio_Mixer.SetFloat("Sound", sound);
    }

    public void Effect_Sound_Control()
    {
        float effect_sound = Effect_Sound_Slider.value;

        if (effect_sound == -40f) Audio_Mixer.SetFloat("Effect Sound", -80);
        else Audio_Mixer.SetFloat("Effect Sound", effect_sound);
    }
}
