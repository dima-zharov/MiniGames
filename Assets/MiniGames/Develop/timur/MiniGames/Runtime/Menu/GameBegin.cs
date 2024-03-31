using System.Collections;
using UnityEngine;

public class GameBegin : MonoBehaviour
{
    [SerializeField] private GameObject _comment;
    private void Start()
    {

        if (PlayerPrefs.GetInt("CloseCommit") == 0)
        {
            _comment.SetActive(true);
            StartCoroutine(CloseCommitAfterTime());
        }
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private IEnumerator CloseCommitAfterTime()
    {
        yield return new WaitForSeconds(5);
        PlayerPrefs.SetInt("CloseCommit", 1);
        GameObject.Destroy(_comment);
    }

    public void CloseCommit()
    {
        PlayerPrefs.SetInt("CloseCommit", 1);
        GameObject.Destroy(_comment);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("CloseCommit", 0);
    }
}