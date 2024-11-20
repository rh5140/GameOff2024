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

    // public GameObject chooseButton;
    // public GameObject closeButton;

    private InMemoryVariableStorage variableStorage;

    // implement if neighbor has been interacted with or not
    // neighbor hint info?
    // neighbor name is ??? if haven't given the first item?

    void Awake() {
        variableStorage = FindObjectOfType<Yarn.Unity.InMemoryVariableStorage>();
        bool metNeighbor;
        variableStorage.TryGetValue("$metNeighbor", out metNeighbor);
        Debug.Log("Prologue");

        if (metNeighbor) {
            neighborPortrait.SetActive(true);
            neighborName.SetActive(true);
            mysteryNeighborPortrait.SetActive(false);
            mysteryNeighborName.SetActive(false);
            Debug.Log("TRUE");
        } else {
            mysteryNeighborPortrait.SetActive(true);
            mysteryNeighborName.SetActive(true);
            neighborPortrait.SetActive(false);
            neighborName.SetActive(false);
            Debug.Log("FALSE");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // chooseButton.SetActive(true);
        // closeButton.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        GetComponent<Image>().color = new Color(255, 0, 0 );
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        GetComponent<Image>().color = new Color(255, 255, 255);
    }
}