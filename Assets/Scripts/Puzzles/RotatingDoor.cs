using UnityEngine;

public class RotatingDoor : MonoBehaviour
{
    public Transform door;              // Kapı objesi
    public float openAngle = -90f;      // Kapının açılacağı açı
    public float rotateSpeed = 2f;      // Kapının döndürme hızı

    private Quaternion doorClosedRot;   // Kapının kapalı rotasyonu
    private Quaternion doorOpenRot;     // Kapının açık rotasyonu

    private bool isOpening = false;     // Kapının açılma durumu
    private bool isClosing = false;     // Kapının kapanma durumu

    void Start()
    {
        // Kapının başlangıç rotasını kaydet
        doorClosedRot = door.rotation;

        // Kapının açık rotasını hesapla
        doorOpenRot = Quaternion.Euler(doorClosedRot.eulerAngles + new Vector3(0, openAngle, 0));
    }

    void Update()
    {
        if (isOpening)
        {
            // Kapıyı aç (döndür)
            door.rotation = Quaternion.Lerp(door.rotation, doorOpenRot, Time.deltaTime * rotateSpeed);

            // Eğer kapı açılmışsa, hareketi durdur
            if (Quaternion.Angle(door.rotation, doorOpenRot) < 0.01f)
            {
                door.rotation = doorOpenRot;
                isOpening = false;
            }
        }
        else if (isClosing)
        {
            // Kapıyı kapat (orijinal pozisyona döndür)
            door.rotation = Quaternion.Lerp(door.rotation, doorClosedRot, Time.deltaTime * rotateSpeed);

            // Eğer kapı kapanmışsa, hareketi durdur
            if (Quaternion.Angle(door.rotation, doorClosedRot) < 0.01f)
            {
                door.rotation = doorClosedRot;
                isClosing = false;
            }
        }
    }

    // Kapıyı açmak için çağrılacak fonksiyon
    public void OpenDoor()
    {
        isOpening = true;
        isClosing = false;
    }

    // Kapıyı kapatmak için çağrılacak fonksiyon
    public void CloseDoor()
    {
        isOpening = false;
        isClosing = true;
    }
}
