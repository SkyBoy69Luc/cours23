using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {

    public static GameController gameControl;

    public int attack;
    public int defense;
    public int health;


    private void Start()
    {
        if (gameControl == null)
        {
            SetDefaultValue();
            DontDestroyOnLoad(gameObject);
            gameControl = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddAttack()
    {
        attack++;
    }

    public void AddDefense()
    {
        defense++;
    }

    public void AddHealth()
    {
        health++;
    }

    public void SetDefaultValue()
    {
        attack  = 1;
        defense = 1;
        health  = 1;
    }

    public void Load()
    {

        BinaryFormatter bf = new BinaryFormatter();

        if (!File.Exists(Application.persistentDataPath + "gameInfo.dat "))
        {
            throw new Exception("Game save not exist");
        }
        
        FileStream file  = File.Open(Application.persistentDataPath + "gameInfo.dat ", FileMode.Open);
        PlayerData playerDataToSave = (PlayerData)bf.Deserialize(file);
        file.Close();

        attack = playerDataToSave.attack ;
        defense = playerDataToSave.defense;
        health = playerDataToSave.health;

    }

    public void Save()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat ",FileMode.Create);

        PlayerData playerDataToSave = new PlayerData();
        playerDataToSave.attack = attack;
        playerDataToSave.defense = defense;
        playerDataToSave.health = health;

        bf.Serialize(file, playerDataToSave);
        file.Close();

    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 60, 180, 80), "Attack " + attack, style);
        GUI.Label(new Rect(10, 110, 180, 80), "Defense " + defense, style);
        GUI.Label(new Rect(10, 160, 180, 80), "Health" + health, style);
    }


}

[Serializable]
class PlayerData
{
    public int attack;
    public int defense;
    public int health;
}
