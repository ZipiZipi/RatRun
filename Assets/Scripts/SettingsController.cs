using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public void ToggleMusic()
    {
        SoundController.Instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        SoundController.Instance.ToggleSFX();
    }
    public void MusicVolume()
    {
        SoundController.Instance.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        SoundController.Instance.SFXVolume(_sfxSlider.value);
    }
    private void Start()
    {
        _sfxSlider.value = SoundController.Instance.sfxSource.volume;
        _musicSlider.value = SoundController.Instance.musicSource.volume;
    }
}
