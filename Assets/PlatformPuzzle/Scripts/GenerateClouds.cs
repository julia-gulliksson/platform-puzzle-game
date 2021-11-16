using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateClouds : MonoBehaviour
{
    [SerializeField] GameObject cloud;
    private List<GameObject> cloudList = new List<GameObject>();

    void Start()
    {
        StartCoroutine(GenerateCloudObjects());
    }

    IEnumerator GenerateCloudObjects()
    {
        while (cloudList.Count < 10)
        {
            float x = Random.Range(0, 30);
            float y = Random.Range(1, 7);
            float z = Random.Range(2, 15);
            Vector3 positioning = new Vector3(x, y, z);

            bool isTooClose = false;

            for (int i = 0; i < cloudList.Count; i++)
            {
                if (Vector3.Distance(cloudList[i].transform.position, positioning) < 1.0f)
                {
                    isTooClose = true;
                }
            }

            if (!isTooClose)
            {
                GameObject cloudObj = Instantiate(cloud, positioning, Quaternion.identity);
                cloudList.Add(cloudObj);
            }

            yield return null;
        }

    }
}
