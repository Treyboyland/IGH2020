using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrackerRadius : MonoBehaviour
{
    [SerializeField]
    GameObject player = null;

    [SerializeField]
    float maxRadius = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 thisPos = transform.position;
        Vector2 diff = thisPos - playerPos;
        if (diff.sqrMagnitude > maxRadius)
        {
            //Debug.LogWarning(diff.normalized);
            Vector2 newPos = playerPos + diff.normalized * maxRadius;
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
        }
    }
}
