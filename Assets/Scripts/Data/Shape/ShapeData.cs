using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shape", menuName = "Shape")]
public class ShapeData : ScriptableObject
{
    public GameObject Prefab;
    [SerializeField] public List<Vector2> points = new();

    [Button]
    public void FeelPoints()
    {
        if(Prefab == null) return;
        points.Clear();
        foreach (Transform child in Prefab.transform)
        {
            if (child.localPosition.x == 0 && child.localPosition.y == 0) continue;
            int x = (int)child.localPosition.x / 100;
            int y = (int)child.localPosition.y / 100;
            points.Add(new(x, y));
        }
    }
}

