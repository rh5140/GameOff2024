using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class NeighborSelect : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject neighborPortrait;
    public GameObject neighborName;
    public GameObject mysteryNeighborPortrait;
    public GameObject mysteryNeighborName;

    public GameObject chooseButton;
    public GameObject cancelButton;

    private InMemoryVariableStorage variableStorage;

    void Start() {
        variableStorage = FindObjectOfType<Yarn.Unity.InMemoryVariableStorage>();
        bool metNeighbor;
        variableStorage.TryGetValue("$metNeighbor", out metNeighbor);

        if (metNeighbor) {
            neighborPortrait.SetActive(true);
            neighborName.SetActive(true);
            mysteryNeighborPortrait.SetActive(false);
            mysteryNeighborName.SetActive(false);
        } else {
            mysteryNeighborPortrait.SetActive(true);
            mysteryNeighborName.SetActive(true);
            neighborPortrait.SetActive(false);
            neighborName.SetActive(false);
        }
        chooseButton.SetActive(false);
        cancelButton.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        chooseButton.SetActive(true);
        cancelButton.SetActive(true);

        NeighborCanvasParent parentCanva = GetComponentInParent<NeighborCanvasParent>();
        Debug.Log("Parent " + parentCanva);
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