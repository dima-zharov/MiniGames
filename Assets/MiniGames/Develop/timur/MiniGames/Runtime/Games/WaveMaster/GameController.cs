using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI startText;

    public int currentScore;

    public void Start()
    {
        currentScore = 0;
        bestScoreText.text = PlayerPrefs.GetInt("WaveMasterRecord", 0).ToString();
        SetScore();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            startText.gameObject.SetActive(false);
        }
    }

    public void CallGameOver()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore()
    {
        currentScore++;

        SaveScore();
        SetScore();
    }

    public void SaveScore()
    {
        if (currentScore > PlayerPrefs.GetInt("WaveMasterRecord", 0))
        {
            PlayerPrefs.SetInt("WaveMasterRecord", currentScore);
            bestScoreText.text = currentScore.ToString();
        }
    }

    void SetScore()
    {
        currentScoreText.text = currentScore.ToString();
    }
}
