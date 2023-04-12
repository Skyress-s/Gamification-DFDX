using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

// using bb = System.Tuple<UnityEngine.GameObject, UnityEngine.LineRenderer>;
public struct GraphStyle {
    public Color color;
    public float width;
    
    public int endCap;
    
}

public sealed class graphTest : Tuple<GameObject, LineRenderer> {
    public graphTest(GameObject item1, LineRenderer item2) : base(item1, item2) {
        
    }
};



public static class GraphHelpers 
{
    // static bb awd() {
    //     
    // }

    public static graphTest Create(RectTransform parent, Func<float, float> func, float resolution, Vector2 xMinMax, Vector2? yMinMax = null, GraphStyle? style = null) {
        List<Vector2> points = new List<Vector2>();
        for (float x = xMinMax.x; x < xMinMax.y + resolution/2f; x += resolution) {
            points.Add(new Vector2(x, func(x)));
            // Debug.Log($"point {x} : {points[points.Count-1]}");   
        }

        if (yMinMax == null) {
            float min = points.Min(v => v.y);
            float max = points.Max(v => v.y);
            yMinMax = new Vector2(min, max);
        }
        
        
        GameObject go = new GameObject("Graph");
        Vector3[] corners = new Vector3[4];
        parent.GetWorldCorners(corners);
        
        Vector3 bottomLeft = corners[0];
        Vector3 topRight = corners[2];
        
        // Debug.Log($"BOTTOM {bottomLeft}  | TOP {topRight}");
        (new GameObject("BOTTOMRIGHT")).transform.position = bottomLeft;
        (new GameObject("TOPLEFT")).transform.position = topRight;
        
        LineRenderer lr = go.AddComponent<LineRenderer>();
        lr.useWorldSpace = false;
        go.transform.position += -Vector3.forward;
        lr.positionCount = points.Count;

        if (style == null) {
            style =  new GraphStyle() {color = Color.white, width = 0.1f, endCap = 4};
        }

        lr.startColor = style.Value.color;
        lr.endColor = style.Value.color;
        lr.widthMultiplier = style.Value.width;
        lr.numCapVertices = style.Value.endCap;
        var mat = Addressables.LoadAssetAsync<Material>("M_GraphMat").WaitForCompletion();
        lr.material = mat;
        
        
        for (int i = 0; i < points.Count; i++) {
            float x = Mathf.Lerp(bottomLeft.x, topRight.x, Mathf.InverseLerp(xMinMax.x, xMinMax.y, points[i].x));
            float y = Mathf.Lerp(bottomLeft.y, topRight.y, Mathf.InverseLerp(yMinMax.Value.x, yMinMax.Value.y, points[i].y));
            // Debug.Log($"{i} | x: {x} y: {y} ");
            lr.SetPosition(i, new Vector3(x, y, 0));
        }

        return new graphTest(go, lr);
    }

    // static LineRenderer CreateLineRenderer(Rect rect, ref List<Vector2> points) {
    //     
    // }
}