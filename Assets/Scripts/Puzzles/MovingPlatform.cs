using UnityEngine;
using UnityEngine.Events;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;       // Platformun hareket edeceği ilk pozisyon
    public Transform pointB;       // Platformun hareket edeceği ikinci pozisyon
    public float speed = 2f;       // Platformun hareket hızı
    public bool startMoving = false; // Platformun başlangıçta hareket edip etmeyeceği

    public UnityEvent onPlatformStartMoving; // Platform hareket etmeye başladığında tetiklenecek event
    public UnityEvent onPlatformStopMoving;  // Platform durduğunda tetiklenecek event

    private Vector3 targetPosition; // Platformun şu anki hedef pozisyonu
    private bool isMoving = false;  // Platformun hareket edip etmediğini kontrol eder

    void Start()
    {
        // Platform başlangıçta hareket edecekse
        if (startMoving)
        {
            StartMoving();
        }
        else
        {
            isMoving = false;
            onPlatformStopMoving.Invoke();
        }

        targetPosition = pointB.position; // Başlangıç hedefi
    }

    void Update()
    {
        if (isMoving)
        {
            // Platformu hedef pozisyona doğru hareket ettir
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Hedefe ulaştığında, hedef pozisyonu değiştir (diğer tarafa git)
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                targetPosition = (targetPosition == pointA.position) ? pointB.position : pointA.position;
            }
        }
    }

    // Platformu hareket ettirmek için çağrılacak fonksiyon
    public void StartMoving()
    {
        if (!isMoving) // Platform zaten hareket ediyorsa tekrar tetikleme
        {
            isMoving = true;
            onPlatformStartMoving.Invoke(); // Platform hareket etmeye başladığında UnityEvent'i tetikle
        }
    }

    // Platformu durdurmak için çağrılacak fonksiyon
    public void StopMoving()
    {
        if (isMoving) // Platform zaten durduysa tekrar tetikleme
        {
            isMoving = false;
            onPlatformStopMoving.Invoke(); // Platform durduğunda UnityEvent'i tetikle
        }
    }
}
