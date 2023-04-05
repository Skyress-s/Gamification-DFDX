using UnityEngine;

public class SceneHanlderComponent : MonoBehaviour
{
    
    public void LoadScene(string str)
    {
        SceneHandler.LoadSceneWithDefaultTransition(str);
    }
}
