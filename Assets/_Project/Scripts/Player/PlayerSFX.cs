using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] private AudioClip _hurtSound;
    [SerializeField] private AudioSource _audio;

    public void PlayHurtSound()
    {
        _audio.clip = _hurtSound;
        _audio.Play();
    }

}
