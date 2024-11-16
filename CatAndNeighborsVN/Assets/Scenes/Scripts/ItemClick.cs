using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ItemClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{ 
    public GameObject popup;
    public GameObject closeButton;

    public void OnPointerClick(PointerEventData eventData)
    {
        popup.SetActive(true);
        closeButton.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        // Changes image color to red on hover
        GetComponent<Image>().color = new Color(255, 0, 0 );
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        // Changes image color to white
        GetComponent<Image>().color = new Color(255, 255, 255);
    }
}