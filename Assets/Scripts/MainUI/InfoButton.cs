using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    // Drag button dan image ke variabel ini melalui Inspector
    public Button infoButtonOff;
    public GameObject uiInfo;

    // Variabel untuk menyimpan gambar sprite sebelum dan setelah klik
    public Sprite spriteBeforeClick;  // Gambar sebelum tombol diklik
    public Sprite spriteAfterClick;   // Gambar setelah tombol diklik

    // Untuk mendapatkan komponen Image dari button
    private Image buttonImage;

    void Start()
    {
        // Ambil komponen Image dari button
        buttonImage = infoButtonOff.GetComponent<Image>();

        // Pastikan UI_Info tidak aktif di awal
        uiInfo.SetActive(false);

        // Menambahkan listener untuk tombol
        infoButtonOff.onClick.AddListener(ToggleUIInfo);
    }

    // Fungsi untuk toggle (tampilkan atau sembunyikan) UI_Info
    void ToggleUIInfo()
    {
        // Toggle status aktif UI_Info
        bool isActive = uiInfo.activeSelf;
        uiInfo.SetActive(!isActive);

        // Ganti sprite pada button berdasarkan status uiInfo
        if (uiInfo.activeSelf)
        {
            buttonImage.sprite = spriteAfterClick;  // Ganti gambar setelah klik
        }
        else
        {
            buttonImage.sprite = spriteBeforeClick;  // Kembalikan gambar sebelum klik
        }
    }
}