using UnityEngine.EventSystems;
using UnityEngine;

public class ItemClick : MonoBehaviour, IPointerClickHandler
{ 
    public GameObject popup;
    public GameObject closeButton;

    public void OnPointerClick(PointerEventData eventData)
    {
        popup.SetActive(true);
        closeButton.SetActive(true);
    }
}