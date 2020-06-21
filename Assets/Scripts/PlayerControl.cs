using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    float speed = 0;

    public bool CanMove = true;

    public bool moveInverted = false;

    Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (CanMove)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector2 pos = new Vector2(transform.position.x, transform.position.y);

        if (moveInverted){
            pos.x -= xAxis * speed * Time.fixedDeltaTime;
            pos.y -= yAxis * speed * Time.fixedDeltaTime;
        }
        else
        {
            pos.x += xAxis * speed * Time.fixedDeltaTime;
            pos.y += yAxis * speed * Time.fixedDeltaTime;
        }

        body.MovePosition(pos);
    }
}
