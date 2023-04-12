using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Multiple Choice Question", menuName = "Multiple Choice Question", order = 1)]
public class MultipleChoiceQuestion : ScriptableObject {
    public CorrectAnswer correctAnswer = CorrectAnswer.NONE;
    
    [TextArea(2, 5)]
    public string question = "What is 1 + 1?";
    
    [Header("A")]
    [TextArea(2, 5)]
    public string answer1 = "A";
    public MathDialog ans1MathDialog;
    
    [Header("B")]
    [TextArea(2, 5)]
    public string answer2 = "B";
    public MathDialog ans2MathDialog;
    
    [Header("C")]
    [TextArea(2, 5)]
    public string answer3 = "C";
    public MathDialog ans3MathDialog;
    
    [Header("D")]
    [TextArea(2, 5)]
    public string answer4 = "D";
    public MathDialog ans4MathDialog;
    
    [Space]
    public List<MathDialog> mathGuidance = new List<MathDialog>();
    
    [TextArea(2, 5)]
    public string correctAnswerString = "A";
    [TextArea(2, 5)]
    public string incorrectAnswerString = "B";
    
    public MathDialog MathDialogFromAnswer(CorrectAnswer answer) {
        switch (answer) {
            case CorrectAnswer.A:
                return ans1MathDialog;
            case CorrectAnswer.B:
                return ans2MathDialog;
            case CorrectAnswer.C:
                return ans3MathDialog;
            case CorrectAnswer.D:
                return ans4MathDialog;
        }
        return null;
    }
    
    [Serializable]
    public enum 
    CorrectAnswer {
        A=0,B=1,C=2,D=3,NONE=-1
    }
}


[Serializable]
public class MathDialog {
    public string guidance = "It's dangerous to go alone! Take this.";
    public AnimationClip AnimationClip;
}