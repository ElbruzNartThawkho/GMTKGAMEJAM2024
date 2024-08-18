using UnityEngine;

public class SpawnButton : MonoBehaviour, IInteractable
{
    public GameObject prefabToSpawn; // Küp prefab'ı burada atanacak
    public Transform spawnPoint; // Objenin spawn olacağı nokta
    private GameObject spawnedObject;

    public void Interact(PlayerInteract player)
    {
        if (spawnedObject != null)
        {
            // Eğer daha önce spawn edilen bir obje varsa, onu sil
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
}
