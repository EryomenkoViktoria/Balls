using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{
    public static VolumeValue inst;

    [SerializeField]
    private GameObject BGMusic;
    [SerializeField]
    private Slider VolValue;
    [SerializeField]
    private GameObject[] sourse;
    
    private AudioSource audioSource;
    private static float musicVolume;

    private void Awake()
    {
        inst = this;
        sourse = GameObject.FindGameObjectsWithTag("Sound");    
    }

    private void Start()
    {
        if (sourse.Length == 0)
        {
            BGMusic = Instantiate(BGMusic);
            BGMusic.name = "BGMusic";
            DontDestroyOnLoad(BGMusic.gameObject);
        }

        else
            BGMusic = GameObject.Find("BGMusic");

        if (!PlayerPrefs.HasKey("MusicVol"))
            musicVolume = 0.1f;

        else
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVol");
            VolValue.value = PlayerPrefs.GetFloat("MusicVol");
        }

        audioSource = BGMusic.GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSource.volume = musicVolume;
    }

    internal void SetVolume(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("MusicVol", vol);
    }

}