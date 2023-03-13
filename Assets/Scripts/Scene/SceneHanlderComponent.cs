using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHanlderComponent : MonoBehaviour
{
    
    public void LoadScene(string str)
    {
        SceneHandler.LoadSceneWithDefaultTransition(str);
    }
}
