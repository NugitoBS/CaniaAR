using UnityEngine;
using UnityEngine.UI;

public class HideUI : MonoBehaviour
{
    public Canvas canvas;
    public Button toggleUIButton;
    public Sprite spriteShowUI;
    public Sprite spriteHideUI;
    private Image buttonImage;
    private GameObject[] uiElements;
    private bool isUIHidden = false;

    void Start()
    {
        buttonImage = toggleUIButton.GetComponent<Image>();
        int count = 0;
        uiElements = new GameObject[canvas.transform.childCount - 1];
        for (int i = 0; i < canvas.transform.childCount; i++)
        {
            GameObject child = canvas.transform.GetChild(i).gameObject;
            if (child != toggleUIButton.gameObject)
            {
                uiElements[count++] = child;
            }
        }
        toggleUIButton.onClick.AddListener(ToggleUI);
        buttonImage.sprite = spriteHideUI;
    }

    void ToggleUI()
    {
        if (isUIHidden)
        {
            ShowUI();
        }
        else
        {
            HideUIElements();
        }
    }

    void HideUIElements()
    {
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false);
        }

        buttonImage.sprite = spriteShowUI;
        isUIHidden = true;
    }

    void ShowUI()
    {
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(true);
        }
        buttonImage.sprite = spriteHideUI;
        isUIHidden = false;
    }
}