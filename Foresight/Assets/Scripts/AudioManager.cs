using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Sources------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-----Audio Clips------")]

    public AudioClip giveInputClick;
    public AudioClip resetButtonClick;
    public AudioClip goButtonClick;
    public AudioClip goButtonFlick;
    public AudioClip movementSound;
    public AudioClip passLevelSound;
    public AudioClip deadSoundClip;
    public AudioClip weaponShoot;
    public AudioClip teleportationSound;
    public AudioClip SceneChangeLeftToRight;
    public AudioClip SceneChangeRightToLeft;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayAudioClip(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
