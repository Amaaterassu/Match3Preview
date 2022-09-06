using UnityEngine;
using System.Collections.Generic;
using System;
public class FieldGenerator : MonoBehaviour
{
    public GameObject cellPrefab;
    public Transform cellParent;
    [Space]
    public int rowCount;
    public int columnCount;
    [Space]
    public float spawnWidthSpace;
    public float spawnHeightSpace;
    [Space]
    public bool generateOnAwake;

    [HideInInspector] public Transform[] ParentsOfCandiesArray;
    CandySpawnerUsingFeildGeneratorAsParent candySpawnerParent;

    private void Awake()
    {
        if (generateOnAwake)
            Generate();
    }
    public void Generate()
    {
        int arraySize = 0;
        ParentsOfCandiesArray = new Transform[rowCount*columnCount];

        for (int col = 0; col < columnCount; col++)
        {
            for (int row = 0; row < rowCount; row++)
            {
                GameObject instance = Instantiate(cellPrefab, cellParent);
                instance.transform.localPosition = new Vector3(col * spawnHeightSpace, row * spawnWidthSpace, 0);
                ParentsOfCandiesArray[arraySize] =  instance.GetComponent<Transform>();
                arraySize++;
            }
        }
        arraySize = 0;
    }
}