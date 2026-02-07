using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class UI_Options : MonoBehaviour
{

    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private UnityEvent<float> _onSensitivityChange;

    public void OnClickSaveOptions()
    {
        PlayerPrefs.Save();
        Debug.Log("Le opzioni sono state salvate!");
    }

    public void OnClickReturn()
    {
        _optionsPanel.SetActive(!_optionsPanel.activeSelf);
    }

    public void OnSlideMouseSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
        _onSensitivityChange.Invoke(sensitivity);
    }

    public void OnSlideSFXVolume(float value)
    {
        if(value > 0.01f)
        {
            float volume = Mathf.Log10(value) * 20;
            _audioMixer.SetFloat("SFX", volume);
        }
        else
        {
            _audioMixer.SetFloat("SFX", -80f);
        }
    }

    public void OnSlideMusicVolume(float value)
    {
        if (value > 0.01f)
        {
            float volume = Mathf.Log10(value) * 20;
            _audioMixer.SetFloat("Music", volume);
        }
        else
        {
            _audioMixer.SetFloat("Music", -80f);
        }
    }

    public void OnSlideMasterVolume(float value)
    {
        if(value > 0.01f)
        {
            float volume = Mathf.Log10(value) * 20;
            _audioMixer.SetFloat("Master", volume);
        }
        else
        {
            _audioMixer.SetFloat("Master", -80f);
        }
    }

}
