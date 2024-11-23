using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ItemClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{ 
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject inspectImage;
    [SerializeField] private bool changesItemState;
    [SerializeField] private string node;
    [SerializeField] private Texture2D cursorTexture;
    private DialogueRunner dialogueRunner;

    public void Start() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (dialogueRunner.IsDialogueRunning) return;
        // text popup
        popup.SetActive(true);
        dialogueRunner.StartDialogue(node);

        // replace current image with new image
        if (changesItemState) inspectImage.SetActive(true);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}