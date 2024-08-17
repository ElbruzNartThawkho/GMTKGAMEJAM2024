using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform leftDoor;        // Sol kapı objesi
    public Transform rightDoor;       // Sağ kapı objesi
    public float slideDistance = 3f;  // Kapıların ne kadar kayacağı
    public float slideSpeed = 2f;     // Kapıların kayma hızı

    private Vector3 leftDoorClosedPos;    // Sol kapının kapalı pozisyonu
    private Vector3 rightDoorClosedPos;   // Sağ kapının kapalı pozisyonu
    private Vector3 leftDoorOpenPos;      // Sol kapının açık pozisyonu
    private Vector3 rightDoorOpenPos;     // Sağ kapının açık pozisyonu

    private bool isOpening = false;       // Kapıların açılma durumu
    private bool isClosing = false;       // Kapıların kapanma durumu

    void Start()
    {
        // Kapıların başlangıç pozisyonlarını kaydet
        leftDoorClosedPos = leftDoor.position;
        rightDoorClosedPos = rightDoor.position;

        // Kapıların açık pozisyonlarını hesapla
        leftDoorOpenPos = leftDoorClosedPos + Vector3.forward * slideDistance; // Geriye kaydır
        rightDoorOpenPos = rightDoorClosedPos + Vector3.back * slideDistance; // İleriye kaydır
    }

    void Update()
    {
        if (isOpening)
        {
            // Kapıları aç (ileri-geri kaydır)
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftDoorOpenPos, Time.deltaTime * slideSpeed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightDoorOpenPos, Time.deltaTime * slideSpeed);

            // Eğer kapılar açılmışsa, hareketi durdur
            if (Vector3.Distance(leftDoor.position, leftDoorOpenPos) < 0.01f && Vector3.Distance(rightDoor.position, rightDoorOpenPos) < 0.01f)
            {
                isOpening = false;
            }
        }
        else if (isClosing)
        {
            // Kapıları kapat (orijinal pozisyona kaydır)
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftDoorClosedPos, Time.deltaTime * slideSpeed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightDoorClosedPos, Time.deltaTime * slideSpeed);

            // Eğer kapılar kapanmışsa, hareketi durdur
            if (Vector3.Distance(leftDoor.position, leftDoorClosedPos) < 0.01f && Vector3.Distance(rightDoor.position, rightDoorClosedPos) < 0.01f)
            {
                isClosing = false;
            }
        }
    }

    // Kapıları açmak için çağrılacak fonksiyon
    public void OpenDoor()
    {
        isOpening = true;
        isClosing = false;
    }

    // Kapıları kapatmak için çağrılacak fonksiyon
    public void CloseDoor()
    {
        isOpening = false;
        isClosing = true;
    }
}
