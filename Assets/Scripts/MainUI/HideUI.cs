using UnityEngine;
using UnityEngine.UI;

public class HideUI : MonoBehaviour
{
    // Referensi ke Canvas
    public Canvas canvas;

    // Referensi ke tombol toggle
    public Button toggleUIButton;

    // Gambar tombol sebelum dan sesudah klik
    public Sprite spriteShowUI; // Ketika UI tersembunyi, ikon untuk menampilkan UI
    public Sprite spriteHideUI; // Ketika UI tampil, ikon untuk menyembunyikan UI

    // Komponen gambar dari tombol
    private Image buttonImage;

    // Semua elemen UI dalam Canvas (kecuali tombol toggle)
    private GameObject[] uiElements;

    // Status UI
    private bool isUIHidden = false;

    void Start()
    {
        // Ambil komponen Image dari tombol
        buttonImage = toggleUIButton.GetComponent<Image>();

        // Simpan semua elemen anak Canvas, kecuali tombol toggle itu sendiri
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

        // Tambahkan fungsi ke tombol
        toggleUIButton.onClick.AddListener(ToggleUI);

        // Set sprite awal
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
