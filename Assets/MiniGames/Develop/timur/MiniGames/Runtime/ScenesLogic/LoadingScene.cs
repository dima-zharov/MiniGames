using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private int _sceneId;
    public void LoadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene( _sceneId );
    }
}
