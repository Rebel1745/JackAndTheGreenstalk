using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthPoint : MonoBehaviour
{
    private void Start()
    {
        plant = gameObject.GetComponentInParent<Plant>();
    }

    Plant plant;

    public List<GameObject> GrowthPoints = new List<GameObject>();
    public Transform parent;

    List<GameObject> plantSegments = new List<GameObject>();

    GameObject lastSegment = null;


    public IEnumerator Grow()
    {
        Vector3 spawnPos = Vector3.zero;
        Quaternion spawnRot = Quaternion.identity;
        Transform conPoint = null;

        spawnPos = parent.Find("ConnectPoint").position;
        spawnRot = parent.Find("ConnectPoint").rotation;

        if(lastSegment != null)
        {
            conPoint = lastSegment.transform.Find("ConnectPoint");
            spawnPos = conPoint.position;
            spawnRot = conPoint.rotation;
        }

        int randPlant = Random.Range(0, plant.PlantSegmentPrefab.Length);

        lastSegment = Instantiate(plant.PlantSegmentPrefab[randPlant], spawnPos, spawnRot, this.transform);

        if (lastSegment.GetComponent<GrowthPoint>())
        {
            lastSegment.GetComponent<GrowthPoint>().parent = lastSegment.transform;
            plant.GrowthPoints.Add(lastSegment);
        }
        // somthing is happening after the new growth point is added
        yield return null;
    }
}
