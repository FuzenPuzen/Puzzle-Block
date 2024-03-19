using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShapesData", menuName = "ShapesData")]
public class ShapesData : SerializedScriptableObject
{
    [DictionaryDrawerSettings(KeyLabel = "ID", ValueLabel = "ShapeData")]
    public Dictionary<int, ShapeData> ShapeDictionary = new Dictionary<int, ShapeData>();
}
