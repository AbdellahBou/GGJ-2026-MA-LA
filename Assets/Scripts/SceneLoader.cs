using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioSource audioSource;
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single); // LoadSceneMode.Single unloads current scenes
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        audioSource.volume = 0.5f;
        audioSource.Play();
        
    }
}
