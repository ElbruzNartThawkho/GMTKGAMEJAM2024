using UnityEngine;

public class Grab : MonoBehaviour, IInteractable
{
    [HideInInspector] public bool isGrabbed = false; // Küpün tutulup tutulmadığını kontrol eder
    private Transform originalParent; // Küpün orijinal parent objesi
    private Rigidbody rb; // Küpün Rigidbody bileşeni

    public float maxGrabScale = 2.5f; // Maksimum taşınabilir boyut
    public float rotationSpeed = 50f; // Y ekseninde döndürme hızı

    public void Interact(PlayerInteract player)
    {
        // Küpün boyutunu kontrol et
        if (transform.localScale.x > maxGrabScale || transform.localScale.y > maxGrabScale || transform.localScale.z > maxGrabScale)
        {
            Debug.Log("Küp çok büyük, taşınamaz!");
            return; // Küp çok büyükse taşınmaz
        }

        if (isGrabbed)
        {
            Release();
        }
        else
        {
            GrabObject(player);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isGrabbed)
        {
            // Y ekseninde döndürme işlemleri
            if (Input.GetKey(KeyCode.Q))
            {
                RotateObject(-rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.E))
            {
                RotateObject(rotationSpeed * Time.deltaTime);
            }
            if(Input.GetMouseButtonDown(0))
            {
                Release();
            }
        }
    }

    private void GrabObject(PlayerInteract player)
    {
        isGrabbed = true;
        originalParent = transform.parent;

        // Rigidbody'yi kinematik yaparak fiziksel etkileşimleri kapatıyoruz
        rb.isKinematic = true;

        // Küpü oyuncunun kamerasına child yapıyoruz
        transform.SetParent(player.playerCamera);

        // Küpü kameranın önüne, belirli bir mesafede yerleştiriyoruz
        transform.localPosition = new Vector3(0, 0, 3f);

        // Eşyanın ve tüm child'larının layer'ını "Box" olarak değiştiriyoruz
        SetLayerRecursively(gameObject, LayerMask.NameToLayer("Box"));
    }

    private void Release()
    {
        isGrabbed = false;

        // Rigidbody'yi tekrar dinamik yaparak fiziksel etkileşimleri açıyoruz
        rb.isKinematic = false;

        // Küpü eski parent objesine geri koyuyoruz
        transform.SetParent(originalParent);

        // Eşyanın ve tüm child'larının layer'ını "Default" olarak değiştiriyoruz
        SetLayerRecursively(gameObject, LayerMask.NameToLayer("Default"));
    }

    private void RotateObject(float angle)
    {
        // Y ekseninde döndürme işlemi
        transform.Rotate(Vector3.up, angle);
    }

    // Bu fonksiyon, objenin ve tüm child objelerinin layer'ını değiştirir
    private void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}
