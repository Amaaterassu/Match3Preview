using UnityEngine;
using System.Collections.Generic;

public class CandySpawner : MonoBehaviour
{
    FieldGenerator fieldGenerator;
    public GameObject theGameObjectWithCode;
    [Space]
    public Transform parentGameObject;
    [Space]
    public bool SpawnOnStart;
   
    private void Start()
    {
        if (SpawnOnStart)
        {
            SpawnRandomCandy();
        }
    }

    private List<GameObject> candiesList;
    public void SpawnRandomCandy()
    {
        if (parentGameObject == null)
        {
            Debug.LogError("You will have no candies until you asign the Parent Game Object in the CandySpawner script!!!");
                return;
        }
        fieldGenerator = theGameObjectWithCode.GetComponent<FieldGenerator>();
        float zVectorOfFieldPositionMinus1 = theGameObjectWithCode.GetComponent<Transform>().position.z -1;
        candiesList = new List<GameObject>(Resources.LoadAll<GameObject>("CandiesPrefabs"));
        for (int col = 0; col < fieldGenerator.columnCount; col++)
        {
            for (int row = 0; row < fieldGenerator.rowCount; row++)
            {
                int randomCandy = Random.Range(0, (candiesList.Count - 1));
                GameObject instanceSpawn = Instantiate(candiesList[randomCandy], parentGameObject);
                instanceSpawn.transform.localPosition = new Vector3(col * fieldGenerator.spawnHeightSpace, row * fieldGenerator.spawnWidthSpace, zVectorOfFieldPositionMinus1);
                
            }
        }
    }
}
