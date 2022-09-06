using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CandySpawnerUsingFeildGeneratorAsParent))]
public class CandySpawnerUsingFeildGeneratorAsParentEDitor : Editor
{
    CandySpawnerUsingFeildGeneratorAsParent candySpawnParent;

    private void OnEnable()
    {
        candySpawnParent = serializedObject.targetObject as CandySpawnerUsingFeildGeneratorAsParent;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        base.OnInspectorGUI();


        if (GUILayout.Button("Spawn"))
        {
            candySpawnParent.SpawnRandomCandyAsChild();
        }
        serializedObject.ApplyModifiedProperties();
    }


}
