using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTask : MonoBehaviour
{

    public void LoadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
    
}
