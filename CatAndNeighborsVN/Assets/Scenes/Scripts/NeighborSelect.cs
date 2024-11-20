using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class NeighborSelect : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject neighborPortrait;
    public GameObject neighborInfo;
    public GameObject chooseButton;
    public GameObject closeButton;

    // implement if neighbor has been interacted with or not
    // neighbor hint info?

    public void OnPointerClick(PointerEventData eventData)
    {
        neighborInfo.SetActive(true);
        chooseButton.SetActive(true);
        closeButton.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {

    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {

    }
}