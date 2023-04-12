using UnityEngine;

public class SceneHanlderComponent : MonoBehaviour
{
    
    public void LoadScene(string str)
    {
        SceneHandler.LoadSceneWithDefaultTransition(str);
    }

    public void ExitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}