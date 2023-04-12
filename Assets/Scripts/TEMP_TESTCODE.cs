using System;
using UnityEngine;

public class TEMP_TESTCODE : MonoBehaviour {
	public RectTransform rectTransform;
	public RectTransform rectTransform2;
	private void Start() {
		// Func<float,float> a = f => 22f * f 
		
		rectTransform.ForceUpdateRectTransforms();
		rectTransform2.ForceUpdateRectTransforms();
		var grapt =GraphHelpers.Create(rectTransform, f => 22f*f, 0.1f, new Vector2(0,0.6f));
		var graph2 = GraphHelpers.Create(rectTransform2, f => (-22f / 3f * f * f + 77f / 3f * f), 0.1f,
			new Vector2(0f, 3.6f));
	}
}