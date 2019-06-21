using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(ObjectTransform == null)
        {
            ObjectTransform = GetComponent<Transform>();
        }

        if(CO == null){
            CO = GetComponent<ConnectableObject>();
        }

        curX = ObjectTransform.localScale.x;
        curY = ObjectTransform.localScale.y;
        curZ = ObjectTransform.localScale.z;
    }

    public Transform ObjectTransform;
    public ConnectableObject CO;

    public float MinX = 0.01f;
    public float MaxX = 10f;
    float curX;
    public float GrowSpeedX = 0.1f;
    public float MinY = 1f;
    public float MaxY = 10f;
    float curY;
    public float GrowSpeedY = 0.1f;
    public float MinZ = 1f;
    public float MaxZ = 10f;
    float curZ;
    public float GrowSpeedZ = 0.1f;

    public IEnumerator Grow()
    {
        curX += GrowSpeedX;
        curY += GrowSpeedY;
        curZ += GrowSpeedZ;

        curX = Mathf.Clamp(curX, MinX, MaxX);
        curY = Mathf.Clamp(curY, MinY, MaxY);
        curZ = Mathf.Clamp(curZ, MinZ, MaxZ);

        ObjectTransform.localScale = new Vector3(curX, curY, curZ);

        if (CO)
        {
            StartCoroutine(CO.ConnectToParentCo());
        }

        yield return null;
    }
}
