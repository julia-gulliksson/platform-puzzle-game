using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateClouds : MonoBehaviour
{
    [SerializeField] GameObject cloud;

    void Start()
    {
        StartCoroutine(GenerateCloudObjects());
    }

    IEnumerator GenerateCloudObjects()
    {
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(0, 30);
            float y = Random.Range(1, 7);
            float z = Random.Range(2, 15);
            Instantiate(cloud, new Vector3(x, y, z), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
