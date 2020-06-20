using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalOffset : MonoBehaviour
{
    [SerializeField]
    GameObject toSet;

    [SerializeField]
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(toSet.transform);
        transform.localPosition = offset;
    }
}
