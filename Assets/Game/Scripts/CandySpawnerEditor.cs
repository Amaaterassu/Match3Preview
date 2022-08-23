using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CandySpawner))]
public class CandySpawnerEditor : Editor
{
    CandySpawner candySpawner;

    private void OnEnable()
    {
        candySpawner = serializedObject.targetObject as CandySpawner;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        base.OnInspectorGUI();

        if (GUILayout.Button("Spawn"))
        {
            candySpawner.SpawnRandomCandy();
        }
        serializedObject.ApplyModifiedProperties();
    }


}
