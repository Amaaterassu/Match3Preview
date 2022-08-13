using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    public GameObject cellPrefab;
    public Transform cellParent;
    [Space]
    public float rowCount;
    public float columnCount;
    [Space]
    public float spawnWidthSpace;
    public float spawnHeightSpace;
    [Space]
    public bool generateOnStart;

    private void Start()
    {
        if (generateOnStart)
            Generate();
    }

    public void Generate()
    {
        for (int col = 0; col < columnCount; col++)
        {
            for (int row = 0; row < rowCount; row++)
            {
                GameObject instance = Instantiate(cellPrefab, cellParent);
                instance.transform.localPosition = new Vector3(
                        col * spawnHeightSpace,
                        row * spawnWidthSpace,
                        0);
            }
        }
    }
}
