using UnityEngine;
using System.Collections.Generic;

public class CandySpawner : MonoBehaviour
{
    public FieldGenerator fieldGenerator;
    [Space]
    public Transform parentGameObject;
    [Space]
    public bool SpawnOnStart;

    private List<GameObject> _candiesVariants;

    private void Start()
    {
        _candiesVariants = new List<GameObject>(Resources.LoadAll<GameObject>("CandiesPrefabs"));

        if (SpawnOnStart)
        {
            SpawnRandomCandy();
        }
    }

    public void SpawnRandomCandy()
    {
        if (!fieldGenerator) // analog of fieldGenerator == null
        {
            Debug.LogError($"Field generator is missing at gameobject with name: {name}"); // more appropriate error log format
            return;
        }
        if (parentGameObject == null)
        {
            Debug.LogError("You will have no candies until you asign the Parent Game Object in the CandySpawner script!!!");
            return;
        }

        float zVectorOfFieldPositionMinus1 = fieldGenerator.transform.position.z - 1;

        for (int col = 0; col < fieldGenerator.columnCount; col++)
        {
            for (int row = 0; row < fieldGenerator.rowCount; row++)
            {
                int randomCandy = Random.Range(0, _candiesVariants.Count);
                GameObject instanceSpawn = Instantiate(_candiesVariants[randomCandy], parentGameObject);
                instanceSpawn.transform.localPosition = new Vector3(col * fieldGenerator.spawnHeightSpace, row * fieldGenerator.spawnWidthSpace, zVectorOfFieldPositionMinus1);

            }
        }
    }
}
