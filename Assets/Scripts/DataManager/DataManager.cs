using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public Dictionary<string, string> stringsDictionary = new Dictionary<string, string>();

    public static DataManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
