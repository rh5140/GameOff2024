using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ItemClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{ 
    [SerializeField] private GameObject inspectImage;
    [SerializeField] private bool changesItemState;
    [SerializeField] private string node;
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    private DialogueRunner dialogueRunner;


    public void Start() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        if (dialogueRunner.IsDialogueRunning) dialogueRunner.Stop();
        dialogueRunner.StartDialogue(node);

        // replace current image with new image
        if (changesItemState) {
            inspectImage.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        gameObject.SetActive(false);
        // deactivateImage.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}