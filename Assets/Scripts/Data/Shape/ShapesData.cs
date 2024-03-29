using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ShapesData", menuName = "ShapesData")]
public class ShapesData : SerializedScriptableObject
{
    [DictionaryDrawerSettings(KeyLabel = "ID", ValueLabel = "ShapeData")]
    public Dictionary<int, ShapeData> ShapeDictionary = new Dictionary<int, ShapeData>();

   /* [Button]
    public void ScanResources()
    {
        ShapeDictionary.Clear();
        int shapeID = 0;
        List<GameObject> prefabs = new();
        prefabs.AddRange(Resources.LoadAll<GameObject>("Prefabs/Session/Shapes/"));        
        foreach (GameObject prefab in prefabs)
        {
            ShapeData data = ScriptableObject.CreateInstance<ShapeData>();
            data.Prefab = prefab;

            string prefabName = prefab.name;
            string assetPath = "Assets/Resources/SO/ShapesSo/" + prefabName + ".asset";
            data.FeelPoints();
            ShapeDictionary.Add(shapeID++, data);
            AssetDatabase.CreateAsset(data, assetPath);
        }
    }*/
}
