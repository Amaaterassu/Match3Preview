using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class fieldGenerate : MonoBehaviour
{
    public GameObject myyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        Debug.Log("Editor causes this Awake");  // ����, �� �� �����, ������ ��� ��������
        int width = 4;
        int hight = 6;
        //int[,] cellsArray = new int [width, hight]; �������� � �������, �� ������������ ����������� ����������� �����, ��� � ����� �������� ��� �����, �� ����, �� �� ����� �� �

        for (int b = 0; b < hight; b++)
        {
            for (int i = 0; i < width; i++)
            {
                float cloneOneSell = 1.8f;
                Instantiate((GameObject.Find("singleWoodCell")), new Vector3((-2.70f + i * cloneOneSell), (-3.6f + b * cloneOneSell)), Quaternion.identity);
            }
        } 
    }
}
