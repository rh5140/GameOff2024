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
    public GameObject chooseText;

    public static bool fashionDesignerNotSelected;
    public static bool vampireNurseNotSelected;
    public static bool pitifulRobotNotSelected;
    public static string currentNeighbor;

    void Start() {
        neighborPortrait.SetActive(true);
        chooseButton.SetActive(false);
        cancelButton.SetActive(false);
        chooseText.SetActive(false);
    }

    [YarnFunction("getFashionDesignerNotSelected")]
    public static bool GetFashionDesignerNotSelected() {
        return fashionDesignerNotSelected;
    }

    [YarnFunction("getVampireNurseNotSelected")]
    public static bool GetVampireNurseNotSelected() {
        return vampireNurseNotSelected;
    }

    [YarnFunction("getPitifulRobotNotSelected")]
    public static bool GetPitifulRobotNotSelected() {
        return pitifulRobotNotSelected;
    }

    [YarnCommand("setFashionDesignerNotSelected")]
    public static void SetFashionDesignerNotSelected(bool status) {
        fashionDesignerNotSelected = status;
    }

    [YarnCommand("setVampireNurseNotSelected")]
    public static void SetVampireNurseNotSelected(bool status) {
        vampireNurseNotSelected = status;
    }

    [YarnCommand("setPitifulRobotNotSelected")]
    public static void SetPitifulRobotNotSelected(bool status) {
        pitifulRobotNotSelected = status;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        chooseButton.SetActive(true);
        cancelButton.SetActive(true);
        chooseText.SetActive(true);

        TextMeshProUGUI selectText = chooseText.GetComponent<TextMeshProUGUI>();
        selectText.text = gameObject.name;

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