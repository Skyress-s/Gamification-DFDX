using System;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;
using UnityEngine.UI;



public class ModulWindow : MonoBehaviour {
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [FormerlySerializedAs("text")] [SerializeField] private TMP_Text tmpText;
    
    // private constant variables
    static readonly string _modulAddressableName = "GenericModulWindow";

    // public static ModulWindow Instance { get; private set; }


    public static void ShowQuestion(string questionString, string yesString = "Yes", string noString = "No", Action yesAction = null, Action noAction = null) {
        ModulWindow instance = Addressables.InstantiateAsync(_modulAddressableName).WaitForCompletion().GetComponent<ModulWindow>();
        // set text
        instance.tmpText.text = questionString;
        instance.yesButton.GetComponentInChildren<TMP_Text>().text = yesString;
        instance.noButton.GetComponentInChildren<TMP_Text>().text = noString;


        // set actions
        instance.yesButton.onClick.AddListener(() => {
            yesAction?.Invoke();
            Destroy(instance.gameObject);
        });
        
        instance.noButton.onClick.AddListener(() => {
            noAction?.Invoke();
            Destroy(instance.gameObject);
        });
    }
    
}
