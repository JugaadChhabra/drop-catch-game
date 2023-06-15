using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curve2 : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;
    [SerializeField]
    private GameObject prefab1;
    private int routeToGo;
    private float tParam;
    private float speedModifier;
    private float deleteTime;


    private GameObject instantiatedPrefab;

    public void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.65f;
        StartCoroutine(SpawnPrefabs());
    }
    private IEnumerator SpawnPrefabs()
    {
        deleteTime = Random.Range(1f, 3f);
        // Debug.Log("object2 " + deleteTime);

        Vector2 p0 = routes[routeToGo].GetChild(0).position;
        Vector2 p1 = routes[routeToGo].GetChild(1).position;
        // Vector2 p2 = routes[routeToGo].GetChild(2).position;
        // Vector2 p3 = routes[routeToGo].GetChild(3).position;
        Vector2 p2 = new Vector2(Random.Range(-1f,2.0f),-1.5f);
        Vector2 p3 = new Vector2(Random.Range(-1f,2.0f),-8f);

        if (instantiatedPrefab == null)
        {
            yield return new WaitForSeconds(deleteTime);
            // Debug.Log(deleteTime);
            // Debug.Log(p3);
            // Debug.Log(p2);
            instantiatedPrefab = Instantiate(prefab1, p0, Quaternion.identity);
        }



        while (tParam < 1)
        {
            if (instantiatedPrefab == null)
            {
                Start();
                yield break;
            }

            tParam += Time.deltaTime * speedModifier;
            Vector2 objectPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

            instantiatedPrefab.transform.position = objectPosition;

            yield return null;
        }
        routeToGo = (routeToGo + 1) % routes.Length;
        
    }
}

