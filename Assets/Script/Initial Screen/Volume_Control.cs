using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume_Control : MonoBehaviour
{
    public Slider Sound_Slider;
    public AudioMixer Audio_Mixer;

    private void Start()
    {
        Sound_Slider.value = 0.75f;
    }

    public void Sound_Control()
    {
        float sound = Sound_Slider.value;

        if (sound == -40f) Audio_Mixer.SetFloat("Sound", -80);
        else Audio_Mixer.SetFloat("Sound", sound);
    }
}
