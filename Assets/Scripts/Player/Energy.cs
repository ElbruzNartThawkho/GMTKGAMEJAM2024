using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [SerializeField] Slider energySlider;
    public float energy = 0;
    public void CalculateEnergy(Vector3 velocity) => energy = Mathf.Clamp(energy + Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2) + Mathf.Pow(velocity.z, 2)) / 10, 0, 100);
    public void ChangeEnergy(float value) => energy = Mathf.Clamp(energy + value,0,100);
    private void FixedUpdate()
    {
        energySlider.value = Mathf.Lerp(energySlider.value, energy, Time.deltaTime);
    }
}
