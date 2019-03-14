using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1, 10)]
    public int speedSlider;

    private readonly float speedModifier = 40;
    private bool upRequest;
    private bool downRequest;
    private bool rightRequest;
    private bool leftRequest;
    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        leftRequest = Input.GetKey(KeyCode.LeftArrow);
        rightRequest = Input.GetKey(KeyCode.RightArrow);
        downRequest = Input.GetKey(KeyCode.DownArrow);
        upRequest = Input.GetKey(KeyCode.UpArrow);
    }

    void FixedUpdate()
    {
        float speed = speedSlider * Time.deltaTime * speedModifier;

        if (leftRequest && !rightRequest)
        {
            body.velocity = new Vector2(-speed, body.velocity.y);
        }
        else if (rightRequest && !leftRequest)
        {
            body.velocity = new Vector2(speed, body.velocity.y);
        }
        else if (!leftRequest && !rightRequest)
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
        
        if (downRequest && !upRequest)
        {
            body.velocity = new Vector2(body.velocity.x, -speed);
        }
        else if (upRequest)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
        else if (!downRequest && !upRequest)
        {
            body.velocity = new Vector2(body.velocity.x, 0);
        }
        
    }
}
