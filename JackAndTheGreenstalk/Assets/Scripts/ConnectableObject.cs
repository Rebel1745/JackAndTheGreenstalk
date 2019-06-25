using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectableObject : MonoBehaviour
{
    void Start()
    {
        if (Parent)
        {
            parentCO = Parent.gameObject.GetComponent<ConnectableObject>();
            if (parentCO)
                parentConnectPoint = parentCO.ConnectPointChild;
        }

        if (!parentCO || !parentConnectPoint)
            parentConnectPoint = Parent;

        if(!ObjectTransform)
        {
            ObjectTransform = GetComponent<Transform>();
        }

        if (Child)
        {
            childCO = Child.gameObject.GetComponent<ConnectableObject>();
        }

        if (!ConnectPointParent)
            ConnectPointParent = transform;
        if (!ConnectPointChild)
            ConnectPointChild = transform;
    }

    public Transform ObjectTransform;

    public Transform Parent;
    ConnectableObject parentCO;
    Transform parentConnectPoint;

    public Transform Child;
    ConnectableObject childCO;

    public Transform ConnectPointParent;
    public Transform ConnectPointChild;

    public void ConnectToParent()
    {
        StartCoroutine("ConnectToParentCo");
    }

    public IEnumerator ConnectToParentCo()
    {

        if(Parent){
            Vector3 newPos = parentConnectPoint.position + (transform.position - ConnectPointParent.position);
            Quaternion newRot = Parent.rotation;
            transform.position = newPos;
            transform.rotation = newRot;
        }

        if (childCO)
        {
            childCO.ConnectToParent();
        }
        yield return null;
    } 
}
