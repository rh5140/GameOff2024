using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;

public class NeighborSelect : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject neighborPortrait;
    public GameObject chooseButton;
    public GameObject cancelButton;
    public GameObject chooseNeighborNameText;

    public GameObject otherNeighbor1;
    public GameObject otherNeighbor2;
    
    public bool clickable = true;

    void Start() {
        neighborPortrait.SetActive(true);
        chooseButton.SetActive(false);
        cancelButton.SetActive(false);
        chooseNeighborNameText.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {   
        if (!clickable) return;
        // Set up selection interface buttons & text
        chooseButton.SetActive(true);
        cancelButton.SetActive(true);
        chooseNeighborNameText.SetActive(true);
        
        NeighborCanvasParent parentCanva = GetComponentInParent<NeighborCanvasParent>();
        parentCanva.SetChosenNeighbor(gameObject);

        neighborPortrait.GetComponent<Image>().color = Color.white;
        otherNeighbor1.GetComponent<Image>().color = Color.grey;
        otherNeighbor2.GetComponent<Image>().color = Color.grey;
        otherNeighbor1.GetComponent<NeighborSelect>().clickable = false;
        otherNeighbor2.GetComponent<NeighborSelect>().clickable = false;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (!clickable) return;
        neighborPortrait.GetComponent<Image>().color = Color.white;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (chooseButton.activeSelf) return;
        neighborPortrait.GetComponent<Image>().color = Color.grey;
    }
}