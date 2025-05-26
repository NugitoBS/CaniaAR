using UnityEngine;
using UnityEngine.UI;

public class MeasureButton : MonoBehaviour
{
    // Drag button dan image ke variabel ini melalui Inspector
    public Button measureButtonOff;
    public GameObject rulerXYZ;

    // Variabel untuk menyimpan gambar sprite sebelum dan setelah klik
    public Sprite spriteBeforeClick;  // Gambar sebelum tombol diklik
    public Sprite spriteAfterClick;   // Gambar setelah tombol diklik

    // Untuk mendapatkan komponen Image dari button
    private Image buttonImage;

    void Start()
    {
        // Ambil komponen Image dari button
        buttonImage = measureButtonOff.GetComponent<Image>();

        // Pastikan UI_Info tidak aktif di awal
        rulerXYZ.SetActive(false);

        // Menambahkan listener untuk tombol
        measureButtonOff.onClick.AddListener(ToggleUIInfo);
    }

    // Fungsi untuk toggle (tampilkan atau sembunyikan) UI_Info
    void ToggleUIInfo()
    {
        // Toggle status aktif UI_Info
        bool isActive = rulerXYZ.activeSelf;
        rulerXYZ.SetActive(!isActive);

        // Ganti sprite pada button berdasarkan status rulerXYZ
        if (rulerXYZ.activeSelf)
        {
            buttonImage.sprite = spriteAfterClick;  // Ganti gambar setelah klik
        }
        else
        {
            buttonImage.sprite = spriteBeforeClick;  // Kembalikan gambar sebelum klik
        }
    }
}
