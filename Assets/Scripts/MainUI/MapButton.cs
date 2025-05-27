using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public Button mapButton;
    public GameObject Location;
    public Sprite spriteBeforeClick;
    public Sprite spriteAfterClick;
    private Image buttonImage;

    void Start()
    {
        buttonImage = mapButton.GetComponent<Image>();
        Location.SetActive(false);
        mapButton.onClick.AddListener(ToggleUIInfo);
    }

    void ToggleUIInfo()
    {
        bool isActive = Location.activeSelf;
        Location.SetActive(!isActive);
        if (Location.activeSelf)
        {
            buttonImage.sprite = spriteAfterClick;
        }
        else
        {
            buttonImage.sprite = spriteBeforeClick;
        }
    }
}