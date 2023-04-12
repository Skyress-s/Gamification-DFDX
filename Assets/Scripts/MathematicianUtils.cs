using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class MathematicianUtils
{
    public static void PlayMessage(MathDialog mathDialog, Vector3 position, Transform parent) {
        // instantiate helper bubble and set transforms
        Transform helperBubble = Addressables.InstantiateAsync("HelperBubble", parent).WaitForCompletion().transform;
        helperBubble.localScale = Vector3.one * 0.1f;
        helperBubble.position = position;
        // helperBubble.Translate(Vector3.forward * 100f);
        
        // set text
        helperBubble.GetComponentInChildren<TMP_Text>().text = mathDialog.guidance;
        
        // lean tween sequence
        var seq = LeanTween.sequence();
        seq.append(LeanTween.scale(helperBubble.gameObject, Vector3.one, 0.5f).setEaseOutBack());
        seq.append(4f);
        seq.append(LeanTween.scale(helperBubble.gameObject, Vector3.one * 0.1f, 0.5f).setEaseInCirc());
        seq.append(() => Object.Destroy(helperBubble.gameObject));
    }
}