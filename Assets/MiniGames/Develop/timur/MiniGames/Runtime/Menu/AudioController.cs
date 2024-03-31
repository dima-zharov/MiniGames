using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private GameObject _audioDisabled;
    [SerializeField] private GameObject _audioEnabled;

    private int _clicks;

    void Start()
    {
        Mute();
        SwitchSprite(false, false);
    }

    public void SwitchAudio()
    {
        _clicks++;
        if (_clicks % 2 != 0)
            PlayerPrefs.SetInt("Mute", 1);
        else
            PlayerPrefs.SetInt("Mute", 0);

        Mute();
    }

    private void Mute()
    {
        if (PlayerPrefs.GetInt("Mute") == 1)
        {
            AudioListener.pause = true;
            SwitchSprite(true, false);
        }

        else
        {
            AudioListener.pause = false;
            SwitchSprite(false, true);
        }

    }

    private void SwitchSprite(bool dis, bool enb)
    {
        _audioDisabled.SetActive(dis);
        _audioEnabled.SetActive(enb);
    }
}