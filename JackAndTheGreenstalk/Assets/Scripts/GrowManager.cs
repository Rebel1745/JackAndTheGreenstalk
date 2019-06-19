using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GrowPlants();
        }
    }

    void GrowPlants()
    {
        GrowableObject[] gos = FindObjectsOfType<GrowableObject>();

        foreach (GrowableObject g in gos)
        {
            StartCoroutine(g.Grow());
        }
    }
}
