using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class YarnCommands : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public GameObject gameObject;
    public GameObject itemInteractionCanva;
    public GameObject neighborSelectionCanva;

    void Awake() {
        dialogueRunner.AddCommandHandler<string>("change_scene", ChangeScene);
        dialogueRunner.AddCommandHandler("item_interaction", Interact);
        dialogueRunner.AddCommandHandler("neighbor_selection", Selection);

        itemInteractionCanva.SetActive(false);
        neighborSelectionCanva.SetActive(false);
    }

    private void ChangeScene(string sceneName) {
        Debug.Log("loading scene");
        SceneManager.LoadScene(sceneName);
        gameObject.SetActive(true);
    }

    private void Interact() {
        Debug.Log("Activate item interaction canva");
        itemInteractionCanva.SetActive(true);
    }

    private void Selection() {
        Debug.Log("Activate neighbor selection canva");
        neighborSelectionCanva.SetActive(true);
    }
}
