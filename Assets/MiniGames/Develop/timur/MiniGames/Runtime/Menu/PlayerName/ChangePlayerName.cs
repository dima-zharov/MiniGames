using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TextMeshProUGUI _playerNameOptions;
    [SerializeField] private TextMeshProUGUI _inputField;

    private void Start()
    {
        SetName();
    }
    public void ChangeName()
    {
        if (_inputField.text != null)
        {
            PlayerPrefs.SetString("PlayerName", _inputField.text);
            SetName();
        }
    }

    private void SetName()
    {

        if (_inputField.text != null)
        {
            _inputField.SetText(PlayerPrefs.GetString("PlayerName", _inputField.text));
            _playerName.text = _inputField.text;
            _playerNameOptions.text = _inputField.text;
        }
        else
        {
            _playerName.text = "Player";
            _playerNameOptions.text = "Player";
        }
    }
}
