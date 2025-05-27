using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    public Button infoButtonOff;
    public GameObject uiInfo;
    public Sprite spriteBeforeClick;
    public Sprite spriteAfterClick;
    private Image buttonImage;

    void Start()
    {
        buttonImage = infoButtonOff.GetComponent<Image>();
        uiInfo.SetActive(false);
        infoButtonOff.onClick.AddListener(ToggleUIInfo);
    }

    void ToggleUIInfo()
    {
        bool isActive = uiInfo.activeSelf;
        uiInfo.SetActive(!isActive);
        if (uiInfo.activeSelf)
        {
            buttonImage.sprite = spriteAfterClick;
        }
        else
        {
            buttonImage.sprite = spriteBeforeClick;
        }
    }
}