using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ItemClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{ 
    public GameObject popup;
    public GameObject inspectImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        // text popup
        popup.SetActive(true);

        // replace current image with new image
        inspectImage.SetActive(true);
        gameObject.SetActive(false);
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