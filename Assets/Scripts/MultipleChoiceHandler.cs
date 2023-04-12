using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class MultipleChoiceHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MultipleChoiceQuestion question;
    [SerializeField] private MultipleChoiceButtonsWrapper buttonsWrapper;
    [SerializeField] private TMP_Text title;
    
    public Action onRequestGuidance;
    
    
    private Transform _mathematician;
    private void Start() {
        if (question == null) {
            Debug.LogError("NO QUESTION SET");
            return;
        }
        // try to get mathematician
        _mathematician = GameObject.FindGameObjectWithTag("Mathematician").transform;
        
        buttonsWrapper.SetupButtons(question);
        title.text = question.question;

        
        onRequestGuidance += PlayGuidance;
        
        buttonsWrapper.onButtonClicked.AddListener(OnButtonClicked);
        
        
        
        // testing todo remove
        
        // var task = PlayGuidanceSequence();
    }

    private void OnButtonClicked(int arg0) {
        if (arg0 == (int)question.correctAnswer) {
            buttonsWrapper.SetHighlight(0, Color.green);
            buttonsWrapper.SetHighlight(1, Color.red);
            buttonsWrapper.SetHighlight(2, Color.red);
            buttonsWrapper.SetHighlight(3, Color.red);
        }
        else {
            onRequestGuidance?.Invoke();
        }
    }


    void PlayGuidance() {
        var animator = _mathematician.GetComponentInChildren<Animator>();
        animator.Play(question.mathGuidance[0].AnimationClip.name, 0, 0.1f);
        Vector3[] corners = new Vector3[4];
        _mathematician.GetComponent<RectTransform>().GetWorldCorners(corners);
        MathematicianUtils.PlayMessage(question.mathGuidance[0], corners[1], transform);
    }
    
    /*
    async Task PlayGuidanceSequence() {
        await Task.Delay(2000);
        onRequestGuidance?.Invoke();
    }
*/
}