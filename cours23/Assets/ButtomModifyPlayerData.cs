using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomModifyPlayerData : MonoBehaviour {




    public void IncreaseAttack()
    {
        GameController.gameControl.AddAttack();
    }
    public void IncreaseDefense()
    {
        GameController.gameControl.AddDefense();
    }
    public void IncreaseHealth()
    {
        GameController.gameControl.AddHealth();
    }

}
