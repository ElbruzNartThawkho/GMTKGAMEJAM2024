using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class WeaponManager : MonoBehaviour
{
    Energy energy;
    [SerializeField] Transform weaponHolder;
    List<Weapons> weapons = new List<Weapons>();
    public List<GameObject> startingWeapons;
    public int selectedWeapon = 0;
    public static WeaponManager instance;
    private void Awake()
    {
        energy = GetComponent<Energy>();
        instance = this;
    }
    private void Start()
    {
        foreach (GameObject startingWeapon in startingWeapons)
        {
            TakeWeapon(startingWeapon);
        }
        ChangeWeapon(selectedWeapon);
    }
    public void Shoot()
    {
        if (weapons[selectedWeapon].energyCost <= energy.energy)
        {
            weapons[selectedWeapon].Shoot(Camera.main.transform);
            energy.ChangeEnergy(-weapons[selectedWeapon].energyCost);
        }
    }
    public void ChangeWeapon(int value)
    {
        selectedWeapon += value;
        if (selectedWeapon > weapons.Count - 1) selectedWeapon = 0;
        else if (selectedWeapon < 0) selectedWeapon = weapons.Count - 1;
        foreach (Weapons item in weapons)
        {
            item.weaponMesh.SetActive(false);
        }
        weapons[selectedWeapon].weaponMesh.SetActive(true);
    }
    public void TakeWeapon(GameObject weapon)
    {
        weapons.Add(Instantiate(weapon, weaponHolder).GetComponent<Weapons>());
    }
}
