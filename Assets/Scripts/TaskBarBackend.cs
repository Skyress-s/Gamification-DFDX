using UnityEngine;

public class TaskBarBackend : MonoBehaviour
{
    public static TaskBarBackend Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

    public void OnRightButtonClick()
    {
        
    }

    public void OnLeftButtonClick()
    {
        
    }
}
