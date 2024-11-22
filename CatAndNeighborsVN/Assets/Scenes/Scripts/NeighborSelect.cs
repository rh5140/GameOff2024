using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;

public class NeighborSelect : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject neighborPortrait;
    public GameObject neighborName;
    public GameObject mysteryNeighborPortrait;
    public GameObject mysteryNeighborName;

    public GameObject chooseButton;
    public GameObject cancelButton;
    public GameObject chooseText;

    private InMemoryVariableStorage variableStorage;

    void Start() {
        variableStorage = FindObjectOfType<Yarn.Unity.InMemoryVariableStorage>();
        bool metNeighbor;
        bool incorrectFinished;
        variableStorage.TryGetValue("$metNeighbor", out metNeighbor);
        variableStorage.TryGetValue("$incorrectFinished", out incorrectFinished);
        Debug.Log("FINISHED? " + incorrectFinished);

        if (metNeighbor) {
            neighborPortrait.SetActive(true);
            neighborName.SetActive(true);
            mysteryNeighborPortrait.SetActive(false);
            mysteryNeighborName.SetActive(false);
            if (incorrectFinished) {
                Image portrait = neighborPortrait.GetComponent<Image>();
                portrait.color = new Color(166, 166, 166);
                Debug.Log("GREYSCALE");
            }
        } else {
            mysteryNeighborPortrait.SetActive(true);
            mysteryNeighborName.SetActive(true);
            neighborPortrait.SetActive(false);
            neighborName.SetActive(false);
        }
        chooseButton.SetActive(false);
        cancelButton.SetActive(false);
        chooseText.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        chooseButton.SetActive(true);
        cancelButton.SetActive(true);
        chooseText.SetActive(true);

        TextMeshProUGUI selectText = chooseText.GetComponent<TextMeshProUGUI>();
        selectText.text = "Selected " + gameObject.name;

        NeighborCanvasParent parentCanva = GetComponentInParent<NeighborCanvasParent>();
        parentCanva.SetChosenNeighbor(gameObject);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        GetComponentInChildren<Image>().color = new Color(255, 0, 0 );
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        GetComponentInChildren<Image>().color = new Color(255, 255, 255);
    }
}