using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorModal : MonoBehaviour
{

    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    // transition effect to load in?
}
