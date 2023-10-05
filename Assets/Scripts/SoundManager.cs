using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Slider bgmVolumeSlider;

    private void Start()
    {
        ChangeVolume(bgmVolumeSlider.value);
        // Slider�� ���� ����� �� �̺�Ʈ �ڵ鷯�� ����մϴ�.
        bgmVolumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        // ��������� ������ Slider�� ���� ���� �����մϴ�.
        backgroundMusic.volume = volume;
    }
}

