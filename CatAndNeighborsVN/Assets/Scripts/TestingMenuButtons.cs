using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingMenuButtons : MonoBehaviour
{
    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
