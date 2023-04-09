using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButt : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
        