using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserNameHandlerComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var usernameTMP = GetComponent<TextMeshProUGUI>();
        if (usernameTMP != null)
        {
            usernameTMP.text = PlayerPrefs.GetString("username", "USERNAME");
        }
    }
}
