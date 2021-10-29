using UnityEngine;

public class WeaponHolderSlot : MonoBehaviour
{
    public Transform parent;
    public bool isLeftHandSlot;

    public GameObject currentWeaponModel = null;

    public void LoadWeaponModel(WeaponItem weapon)
    {
        //UnloadWeaponDestroy();

        currentWeaponModel = Instantiate(weapon.modePrefab);

        if (currentWeaponModel && parent)
        {
            currentWeaponModel.transform.parent = parent;
            currentWeaponModel.transform.localPosition = Vector3.zero;
            currentWeaponModel.transform.localRotation = Quaternion.identity;
            currentWeaponModel.transform.localScale = Vector3.one;  
        }

    }

    public void UnloadWeaponModel()
    {
        if(currentWeaponModel != null)
            currentWeaponModel.SetActive(false);
    }

    public void UnloadWeaponDestroy()
    {
        if (currentWeaponModel != null)
            Destroy(currentWeaponModel);

        currentWeaponModel = null;
    }
}
