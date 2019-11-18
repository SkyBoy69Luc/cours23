using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class WeaponController : MonoBehaviour {

    public static WeaponController WeaponControl;

    private List<WeaponData> inventoryWeapon;

    public int indiceList;


    private void Start()
    {
        if (WeaponControl == null)
        {
            SetDefaultValue();
            DontDestroyOnLoad(gameObject);
            WeaponControl = this;
        }
        else
        {
            Destroy(WeaponControl);
        }
    }

    public void AddAttackWeapon()
    {
        inventoryWeapon[indiceList].attackWeapon += 1;
    }

    public void AddWeapon()
    {

        WeaponData weapon = new WeaponData();
        weapon.id_Weapon = inventoryWeapon.Count;
        weapon.attackWeapon = 1;

        inventoryWeapon.Add(weapon);
    }

    public void ChangeLeft()
    {

        if (indiceList == 0)
        {
            indiceList = inventoryWeapon.Count -1;
        }
        else
        {
            indiceList -= 1;
        }
    }

    public void ChangeRigth()
    {


        if (indiceList == inventoryWeapon.Count -1)
        {
            indiceList = 0;
        }
        else
        {
            indiceList += 1;
        }
    }

    public void SetDefaultValue()
    {
        inventoryWeapon = new List<WeaponData>();
        indiceList = 0;
    }

    public void Load()
    {

        BinaryFormatter bf = new BinaryFormatter();

        if (!File.Exists(Application.persistentDataPath + "WeaponInfo.dat "))
        {
            throw new Exception("Weapon save not exist");
        }

        FileStream file = File.Open(Application.persistentDataPath + "WeaponInfo.dat ", FileMode.Open);
        List<WeaponData> inventoryWeaponLoad = (List<WeaponData>)bf.Deserialize(file);
        file.Close();

        inventoryWeapon = inventoryWeaponLoad;

    }

    public void Save()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "WeaponInfo.dat ", FileMode.Create);

        bf.Serialize(file, inventoryWeapon);
        file.Close();

    }

    private void OnGUI()
    {
        int id = 0;
        int attackWeapon = 0;

        if (inventoryWeapon.Count == 0)
        {

        }
        else
        {
            id = inventoryWeapon[indiceList].id_Weapon;
            attackWeapon = inventoryWeapon[indiceList].attackWeapon;
        }

        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 210, 180, 80), "Weapon Index " + id, style);
        GUI.Label(new Rect(10, 260, 180, 80), "Attaque Weapon " + attackWeapon, style);

    }

}

[Serializable]
class WeaponData
{
    public int id_Weapon;
    public int attackWeapon;

}


