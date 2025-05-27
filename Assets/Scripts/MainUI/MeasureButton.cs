using UnityEngine;
using UnityEngine.UI;

public class MeasureButton : MonoBehaviour
{
    public Button measureButtonOff;
    public GameObject rulerXYZ;
    public Sprite spriteBeforeClick;
    public Sprite spriteAfterClick;
    private Image buttonImage;

    void Start()
    {
        buttonImage = measureButtonOff.GetComponent<Image>();
        rulerXYZ.SetActive(false);
        measureButtonOff.onClick.AddListener(ToggleUIInfo);
    }

    void ToggleUIInfo()
    {
        bool isActive = rulerXYZ.activeSelf;
        rulerXYZ.SetActive(!isActive);
        if (rulerXYZ.activeSelf)
        {
            buttonImage.sprite = spriteAfterClick;
        }
        else
        {
            buttonImage.sprite = spriteBeforeClick;
        }
    }
}