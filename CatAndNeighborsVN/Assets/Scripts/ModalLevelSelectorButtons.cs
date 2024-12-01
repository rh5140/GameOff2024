using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectorModal : MonoBehaviour
{

    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}