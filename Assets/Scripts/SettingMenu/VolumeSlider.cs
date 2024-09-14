using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider _volumeSlider;
    public Image muteIcon;
    public AudioSource audioSource;
    void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
        muteIcon.enabled = false;
    }
    void Update()
    {
        if (_volumeSlider.value == 0)
        {
            muteIcon.enabled = true;
        }
        else 
        {
            muteIcon.enabled = false;
        }
    }
    public void OnSliderChanged()
    {
        audioSource.volume = _volumeSlider.value * 100;
    }
}