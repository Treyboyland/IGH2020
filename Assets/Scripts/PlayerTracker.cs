using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField]
    GameObject player = null;

    [SerializeField]
    float speed = 0;

    [SerializeField]
    float maxDistanceFromPlayerSquared = 0;

    float elapsed = 0;

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 thisPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 diff = playerPos - thisPos;
        float sqrMagnitude = diff.sqrMagnitude;
        if (sqrMagnitude > maxDistanceFromPlayerSquared)
        {
            //TODO Move camera
            elapsed += Time.deltaTime;
            var newPos = Vector3.Lerp(thisPos, playerPos, Time.deltaTime * speed);
            //var newPos = Vector3.Lerp(thisPos, playerPos, .5f);
            newPos.z = transform.position.z;
            transform.position = newPos;
            //transform.Translate(diff.normalized * Time.deltaTime * speed, Space.World);
        }
        else
        {
            elapsed = 0;
        }

    }
}
