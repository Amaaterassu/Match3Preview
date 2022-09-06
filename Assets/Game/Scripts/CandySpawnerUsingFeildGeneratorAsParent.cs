using System.Collections.Generic;
using UnityEngine;

public class CandySpawnerUsingFeildGeneratorAsParent : MonoBehaviour
{
    public bool spawnOnStart;

    private void Start()
    {
        if (spawnOnStart)
        {
            SpawnRandomCandyAsChild();
        }
    }

    [HideInInspector] public  List<Transform> ParentsOfCandiesList;

    public FieldGenerator fieldGenerator;

    private List<GameObject> CandiesList;

    /// <summary>
    /// Spawning a random candy from the resources/ list called "CandiesPrefabs" as a child to evry single cell of the field which the "FieldGenerator" script had already spawned
    /// </summary>
    public void SpawnRandomCandyAsChild()
    {
        CandiesList = new List<GameObject>(Resources.LoadAll<GameObject>("CandiesPrefabs"));

        for (int i = 0; i < fieldGenerator.ParentsOfCandiesArray.Length; i++)
        {
            int randomCandy = Random.Range(0, (CandiesList.Count - 1));
            GameObject instance = Instantiate(CandiesList[randomCandy], fieldGenerator.ParentsOfCandiesArray[i]);
            instance.transform.localPosition = new Vector3(0, 0, -1);
            instance.transform.localScale = new Vector3(0.7f, 0.7f, 0);
        }

    }

}
