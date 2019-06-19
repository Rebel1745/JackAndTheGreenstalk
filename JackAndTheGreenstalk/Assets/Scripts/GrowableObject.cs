using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(ScalableObject == null)
        {
            ScalableObject = GetComponent<Transform>();
        }

        UpdatePosition();
    }

    public Transform ScalableObject;
    public Transform ObjectParent;

    public float MinX = 0.01f;
    public float MaxX = 10f;
    float curX;
    float prevX;
    public float GrowSpeedX = 0.1f;
    public float MinY = 1f;
    public float MaxY = 10f;
    float curY;
    float prevY;
    public float GrowSpeedY = 0.1f;
    public float MinZ = 1f;
    public float MaxZ = 10f;
    float curZ;
    float prevZ;
    public float GrowSpeedZ = 0.1f;
    
    public IEnumerator Grow()
    {
        curX += GrowSpeedX;
        curY += GrowSpeedY;
        curZ += GrowSpeedZ;

        curX = Mathf.Clamp(curX, MinX, MaxX);
        curY = Mathf.Clamp(curY, MinY, MaxY);
        curZ = Mathf.Clamp(curZ, MinZ, MaxZ);

        if (curX != prevX || curY != prevY || curZ != prevZ)
            UpdateScaling();

        prevX = curX;
        prevY = curY;
        prevZ = curZ;

        yield return null;
    }

    void UpdateScaling()
    {
        ScalableObject.localScale = new Vector3(curX, curY, curZ);
        UpdatePosition();
    }

    Collider m_Collider;
    Vector3 m_Center;
    Vector3 m_Size, m_Min, m_Max;

    void UpdatePosition()
    {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<Collider>();
        //Fetch the center of the Collider volume
        m_Center = m_Collider.bounds.center;
        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;
        //Fetch the minimum and maximum bounds of the Collider volume
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
        //Output this data into the console
        OutputData();

        // this works for GameObjects with their origin point in the centre of the model
        float newX = ObjectParent.position.x + (ScalableObject.localScale.x - 1) / 2f;
        float newY = ObjectParent.position.y + (ScalableObject.localScale.y - 1) / 2f;
        float newZ = ObjectParent.position.z + (ScalableObject.localScale.z - 1) / 2f;

        ScalableObject.position = new Vector3(newX, newY, newZ);
    }

    void OutputData()
    {
        //Output to the console the center and size of the Collider volume
        Debug.Log("Collider Center : " + m_Center);
        Debug.Log("Collider Size : " + m_Size);
        Debug.Log("Collider bound Minimum : " + m_Min);
        Debug.Log("Collider bound Maximum : " + m_Max);
    }
}
