using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public string sceneName = "CITYMAP";

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

