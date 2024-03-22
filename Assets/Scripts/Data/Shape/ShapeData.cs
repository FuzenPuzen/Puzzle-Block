using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shape", menuName = "Shape")]
public class ShapeData : ScriptableObject
{
    public GameObject Prefab;
    [SerializeField] public List<Vector2> points = new();
}

