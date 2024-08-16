using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    public float energyCost;
    [HideInInspector] public GameObject weaponMesh;
    private void OnEnable()
    {
        weaponMesh = gameObject;
    }
    public abstract void Shoot(Transform transform);
    public abstract void Effect(Transform transform);
}
