using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomWeapon : MonoBehaviour {

    public void IncreaseAttackWeapon()
    {
        WeaponController.WeaponControl.AddAttackWeapon();
    }
    public void AddWeapon()
    {
        WeaponController.WeaponControl.AddWeapon();
    }
    public void DecreaseIndexWeapon()
    {
        WeaponController.WeaponControl.ChangeLeft();
    }
    public void IncreaseIndexWeapon()
    {
        WeaponController.WeaponControl.ChangeRigth();
    }
}
