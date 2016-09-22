using UnityEngine;
using System.Collections;

public class LinkerTriggerZone : MonoBehaviour {

    public Transform _rootToLink;
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("col:" + col.name);
        LinkableObject linkable = col.gameObject.GetComponent<LinkableObject>();
        if (linkable)
        {
            linkable.LinkTo(_rootToLink);

        }

    }
    void OnTriggerExit(Collider col)
    {
        LinkableObject linkable = col.gameObject.GetComponent<LinkableObject>();
        if (linkable)
        {
            linkable.Unlink();
        }

    }
}
