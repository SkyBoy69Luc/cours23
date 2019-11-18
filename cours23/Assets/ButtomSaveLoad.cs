using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomSaveLoad : MonoBehaviour {

	public void Save () {
        GameController.gameControl.Save();
        WeaponController.WeaponControl.Save();
    }

    // Update is called once per frame
    public void Load () {
        GameController.gameControl.Load();
        WeaponController.WeaponControl.Load();
    }
}
