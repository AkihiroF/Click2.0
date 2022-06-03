using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField]private List<AudioSource> music;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private CreateData data;
    [SerializeField] private Slider slider;
    private bool play = true;

    public void InputVolume(float vol)
    {
        mixer.SetFloat("Music", vol);
        data.data.volume = vol;
        JsonSave.SaveToJSON(data.data, data.filename);
    }

    public void StartPlayMusic(int sound)
    {
        play = !play;
        if (play)
        {
            music[sound].Stop();
        }
        else{music[sound].Play();}
    }

    public void UpdateStatus()
    {
        slider.value = data.data.volume;
    }
}
