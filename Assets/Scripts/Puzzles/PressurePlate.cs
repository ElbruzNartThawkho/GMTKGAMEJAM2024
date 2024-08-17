using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class PressurePlate : MonoBehaviour
{
    // Ağırlık limitleri
    public float requiredWeight = 3f;

    // Event'ler
    public UnityEvent onWeightThresholdMet;
    public UnityEvent onWeightThresholdNotMet;
    public UnityEvent onPlateNotPressed;

    // İçerdeki ağırlığı hesaplamak için
    private float totalWeightOnPlate = 0f;
    private bool isPressed = false;

    // Üzerindeki nesneleri takip etmek için
    private List<Rigidbody> objectsOnPlate = new List<Rigidbody>();

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && !objectsOnPlate.Contains(rb))
        {
            objectsOnPlate.Add(rb);
            UpdateWeight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && objectsOnPlate.Contains(rb))
        {
            objectsOnPlate.Remove(rb);
            UpdateWeight();
        }
    }

    private void UpdateWeight()
    {
        totalWeightOnPlate = 0f;

        // Üzerindeki tüm nesnelerin toplam ağırlığını hesapla
        foreach (Rigidbody rb in objectsOnPlate)
        {
            totalWeightOnPlate += rb.mass;
        }

        CheckWeight();
    }

    private void CheckWeight()
    {
        if (totalWeightOnPlate >= requiredWeight)
        {
            if (!isPressed)
            {
                onWeightThresholdMet.Invoke();
                isPressed = true;
            }
        }
        else if (totalWeightOnPlate > 0 && totalWeightOnPlate < requiredWeight)
        {
            onWeightThresholdNotMet.Invoke();
            isPressed = false;
        }
        else
        {
            onPlateNotPressed.Invoke();
            isPressed = false;
        }
    }

    private void Update()
    {
        UpdateWeight();
    }
}
