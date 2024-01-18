using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingScript : MonoBehaviour
{
    public int numOfCubes = 8;
    public int maxCubeHeight = 8;
    public GameObject[] Cubes;

    void Start()
    {
        InitializeRandom();
        SelectionSort(Cubes);
    }
    
    void InitializeRandom() //метод для создания кубов рандомного размера (от 1) и выставить их по оси Х
    {
        Cubes = new GameObject[numOfCubes];

        for (int i = 0; i < numOfCubes; i++)
        {
            int randomNum = Random.Range(1, maxCubeHeight + 1); //генератор рандомного числа

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(0.8f, randomNum, 1); //рандомный масштаб куба
            cube.transform.position = new Vector3(i, randomNum /2.0f, 0); //залайнить по оси Х

            cube.transform.parent = this.transform; //для порядка, геймобджект Cubes будет парентом кубов 
            Cubes[i] = cube;
        }
    }

    void SelectionSort(GameObject[] List)
    {
        int min;
        GameObject temp;
        Vector3 tempPosition;

        for (int i = 0;i < List.Length;i++)
        {
            min = i;

            for (int j = i + 1;  j < List.Length;j++)
            {
                if (List[j].transform.localScale.y < List[min].transform.localScale.y)
                {
                    min = j;
                }
            }

            if(min != i)
            {
                temp = List[i];
                List[i] = List[min];
                List[min] = temp;

                tempPosition = List[i].transform.localPosition;

                List[i].transform.localPosition = new Vector3(List[min].transform.localPosition.x, tempPosition.y, tempPosition.z);
                List[min].transform.localPosition = new Vector3(tempPosition.x, List[min].transform.localPosition.y, List[min].transform.localPosition.z);
            }
        }
    }
}
