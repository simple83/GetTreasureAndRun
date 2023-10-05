using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Slider bgmVolumeSlider;

    private void Start()
    {
        ChangeVolume(bgmVolumeSlider.value);
        // Slider의 값이 변경될 때 이벤트 핸들러를 등록합니다.
        bgmVolumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        // 배경음악의 볼륨을 Slider의 값에 따라 조절합니다.
        backgroundMusic.volume = volume;
    }
}

