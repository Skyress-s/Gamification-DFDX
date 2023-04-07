using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Multiple Choice Question", menuName = "Multiple Choice Question", order = 1)]
public class MultipleChoiceQuestion : ScriptableObject {
    public CorrectAnswer correctAnswer = CorrectAnswer.NONE;
    
    [TextArea(2, 5)]
    public string question = "What is 1 + 1?";
    
    [TextArea(2, 5)]
    public string answer1 = "A";
    [TextArea(2, 5)]
    public string answer2 = "B";
    [TextArea(2, 5)]
    public string answer3 = "C";
    [TextArea(2, 5)]
    public string answer4 = "D";
    
    public List<MathDialog> mathGuidance = new List<MathDialog>();
    
    [TextArea(2, 5)]
    public string correctAnswerString = "A";
    [TextArea(2, 5)]
    public string incorrectAnswerString = "B";
    
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