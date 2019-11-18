using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomSceneController : MonoBehaviour {

    public void NextScene()
    {
        SceneControler.sceneControl.NextScene();
    }

    public void PreviousScene()
    {
        SceneControler.sceneControl.PreviousScene();
    }
}
