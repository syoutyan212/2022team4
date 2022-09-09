using UnityEngine;

public class TitleAudio : MonoBehaviour
{
    [SerializeField] private AudioClip gameStart;
    [SerializeField] private AudioClip buttonSound;
    private AudioSource _audioSource;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void ShotGameStartSound()
    {
        _audioSource.PlayOneShot(gameStart);
    }
    
    public void ShotButtonSound()
    {
        _audioSource.PlayOneShot(buttonSound);
    }
}
