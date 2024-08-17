using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    public float scaleAmount = 0.3f; // %30 oranında büyüme/küçülme
    public float smoothSpeed = 5f; // Lerp işlemi için hız
    public float maxDistance = 3f; // Maksimum mesafe

    public float minScale = 0.3f; // Küçülme için minimum limit
    public float maxScale = 6f;   // Büyüme için maksimum limit

    void Update()
    {
        // Sol tık
        if (Input.GetMouseButtonDown(0))
        {
            ScaleObject(scaleAmount);
        }
        // Sağ tık
        if (Input.GetMouseButtonDown(1))
        {
            ScaleObject(-scaleAmount);
        }
    }

    void ScaleObject(float amount)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // 3f mesafeye kadar olan objeleri tespit et
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider.CompareTag("Box"))
            {
                Grab grab = hit.transform.GetComponent<Grab>();
                if(!grab.isGrabbed)
                {
                    Vector3 targetScale = hit.transform.localScale * (1 + amount);

                    // Büyüme ve küçülme limitlerini kontrol et
                    targetScale.x = Mathf.Clamp(targetScale.x, minScale, maxScale);
                    targetScale.y = Mathf.Clamp(targetScale.y, minScale, maxScale);
                    targetScale.z = Mathf.Clamp(targetScale.z, minScale, maxScale);

                    StartCoroutine(SmoothScale(hit.transform, targetScale));

                    // Kütleyi boyutla orantılı olarak ayarla
                    SetMassBasedOnScale(hit.transform);
                }
            }
        }
    }

    System.Collections.IEnumerator SmoothScale(Transform obj, Vector3 targetScale)
    {
        Vector3 initialScale = obj.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            obj.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime);
            elapsedTime += Time.deltaTime * smoothSpeed;
            yield return null;
        }

        obj.localScale = targetScale;

        // Kütleyi boyutla orantılı olarak ayarla
        SetMassBasedOnScale(obj);
    }

    void SetMassBasedOnScale(Transform obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Kütle = objenin hacmi
            float mass = obj.localScale.x * obj.localScale.y * obj.localScale.z;
            rb.mass = mass;
        }
    }
}
