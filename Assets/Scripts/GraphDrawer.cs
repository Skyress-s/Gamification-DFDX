using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GraphDrawer : MonoBehaviour {
    public RectTransform rectTransform;
    [Tooltip("First element is the constant, second is the linear coefficient, third is the quadratic coefficient, etc.")]
    [SerializeField] private List<float> coefficiens = new List<float>();
    [SerializeField] private int segments = 24;
    private void Start() {
        // Func<float,float> a = f => 22f * f 
			
        rectTransform.ForceUpdateRectTransforms();
        Func<float, float> func = f => {
            float sum = 0;
            for (int i = 0; i < coefficiens.Count; i++) {
                sum +=  Mathf.Pow(f, i+1)*coefficiens[i];
            }

            return sum;
        };
        var grapt =GraphHelpers.Create(rectTransform, func, 0.01f, new Vector2(0,0.6f));
    }
}

