using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectableObject : MonoBehaviour
{
    // Start is called before the first frame update
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

    private void Update()
    {
        ConnectToParent();
    }

    public void ConnectToParent()
    {
        StartCoroutine("ConnectToParentCo");
    }

    IEnumerator ConnectToParentCo()
    {
        if(Parent)
            transform.position = parentConnectPoint.position;

        if (Child)
        {
            childCO.ConnectToParent();
        }
        yield return null;
    } 
}
