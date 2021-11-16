using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateClouds : MonoBehaviour
{
    [SerializeField] GameObject cloud;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateCloudObjects());
    }

    IEnumerator GenerateCloudObjects()
    {
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(0, 30);
            float y = Random.Range(0, 10);
            float z = Random.Range(2, 10);
            Instantiate(cloud, new Vector3(x, y, z), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
