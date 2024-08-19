using UnityEngine;

public class SpawnButton : MonoBehaviour, IInteractable
{
    public GameObject prefabToSpawn; // Spawn edilecek küp prefab'ı
    public Transform spawnPoint; // Objenin spawn olacağı nokta
    public string objectNameToRemove = "Cube"; // Silinecek objenin ismi
    private GameObject spawnedObject;
    private AudioSource audioSource; // Ses çalmak için AudioSource

    void Start()
    {
        // Bu nesneye bağlı AudioSource bileşenini al
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource bileşeni eksik!");
        }
    }

    public void Interact(PlayerInteract player)
    {
         // Ses çal
        PlaySound();
        // Sahnede belirtilen isimde bir obje olup olmadığını kontrol et ve varsa sil
        GameObject existingObject = GameObject.Find(objectNameToRemove);
        if (existingObject != null)
        {
            Destroy(existingObject);
        }

        // Daha önce spawn edilen bir obje varsa, onu sil
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        // Yeni bir küp prefab'ı spawn et
        if (prefabToSpawn != null && spawnPoint != null)
        {
            spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Prefab veya SpawnPoint eksik!");
        }
    }

    // Ses çalmak için fonksiyon
    private void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
