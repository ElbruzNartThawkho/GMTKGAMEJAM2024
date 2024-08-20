using UnityEngine;

public class ToggleObjectsOnTrigger : MonoBehaviour
{
    // Bu alanlar Unity Inspector'da ayarlanabilir.
    public GameObject objectToDisable;  // Kapatılacak obje
    public GameObject objectToEnable;   // Açılacak obje
    public GameObject player;

    // Bu fonksiyon, trigger olayını yakalar.
    private void OnTriggerEnter(Collider other)
    {
        // Kapatılacak obje varsa, kapat
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }

        // Açılacak obje varsa, aç
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
        }

        // Script'i aktif hale getir
        if (player != null)
        {
            ObjectScaler objectScalerScript = player.GetComponent<ObjectScaler>();
            if (objectScalerScript != null)
            {
                objectScalerScript.enabled = true;
            }
        }
    }
}
