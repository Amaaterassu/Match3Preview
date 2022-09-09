using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CandySpawnerUsingFeildGeneratorAsParent : MonoBehaviour
{
    public bool spawnOnStart;

    private void Start()
    {
        if (spawnOnStart)
        {
            SpawnRandomCandies();
        }
    }

    [HideInInspector] public  List<Transform> ParentsOfCandiesList;

    public FieldGenerator fieldGenerator;

    private List<GameObject> CandiesList;

    /// <summary>
    /// Spawning a random candy from the resources/ list called "CandiesPrefabs" as a child to evry single cell of the field which the "FieldGenerator" script had already spawned
    /// </summary>
    public void SpawnRandomCandies()
    {
        CandiesList = Resources.LoadAll<GameObject>("CandiesPrefabs").ToList(); //here more appropriate variant

        for (int i = 0; i < fieldGenerator.ParentsOfCandiesArray.Length; i++)
        {
            if (fieldGenerator.ParentsOfCandiesArray[i])
            {
                int randomCandy = Random.Range(0, (CandiesList.Count - 1));
                GameObject instance = Instantiate(CandiesList[randomCandy], fieldGenerator.ParentsOfCandiesArray[i]);
                instance.transform.localPosition = new Vector3(0, 0, -1);
                instance.transform.localScale = new Vector3(0.7f, 0.7f, 0);
            }
        }
    }

    public void ClearFieldImmediate()
    {
        foreach (var candyParent in fieldGenerator.ParentsOfCandiesArray)
        {
            if (candyParent)
                foreach (var child in candyParent)
                    DestroyImmediate((child as Transform).gameObject);
        }
    }
}
