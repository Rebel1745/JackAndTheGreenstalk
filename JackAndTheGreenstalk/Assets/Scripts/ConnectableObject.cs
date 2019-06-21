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
    public ConnectableObject parentCO;
    public Transform parentConnectPoint;

    public Transform Child;
    public ConnectableObject childCO;

    public Transform ConnectPointParent;
    public Transform ConnectPointChild;

    public void ConnectToParent()
    {
        StartCoroutine("ConnectToParentCo");
    }

    public IEnumerator ConnectToParentCo()
    {
        // TODO - do some tests with rotation.  it should be as simple as just following the rotation of the parent
        Vector3 newPos = parentConnectPoint.position + (transform.position - ConnectPointParent.position);

        if(Parent)
            transform.position = newPos;

        if (childCO)
        {
            childCO.ConnectToParent();
        }
        yield return null;
    } 
}
