using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody2D player;
    private Vector3 orignalPos;

    private bool touchingRightWall;
    private bool touchingLeftWall;
    private bool touchingBottomWall;
    private bool touchingTopWall;
    private float playerXPos;
    private float playerYPos;

    // Start is called before the first frame update
    void Start()
    {
        orignalPos = new Vector3(0, -3.61f, -6.78f);
        transform.position = orignalPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BottomWall"))
        {
            touchingBottomWall = true;
            playerYPos = player.transform.position.y;
        }
        if(collision.CompareTag("TopWall"))
        {
            touchingTopWall = true;
            playerYPos = player.transform.position.y;
        }
        if (collision.CompareTag("RightWall"))
        {
            touchingRightWall = true;
            playerXPos = player.transform.position.x;
        }
        if (collision.CompareTag("LeftWall"))
        {
            touchingLeftWall = true;
            playerXPos = player.transform.position.x;
        }
    }

    void FixedUpdate()
    {
        float x = player.transform.position.x + orignalPos.x;
        float y = player.transform.position.y + orignalPos.y;
        float z = orignalPos.z;

        if (touchingBottomWall)
        {
            y = transform.position.y;
            if(player.transform.position.y > playerYPos)
            {
                touchingBottomWall = false;
            }
        }
        else if(touchingTopWall)
        {
            y = transform.position.y;
            if (player.transform.position.y < playerYPos)
            {
                touchingTopWall = false;
            }
        }
        if (touchingRightWall)
        {
            x = transform.position.x;
            if (player.transform.position.x < playerXPos)
            {
                touchingRightWall = false;
            }
        }
        else if (touchingLeftWall)
        {
            x = transform.position.x;
            if (player.transform.position.x > playerXPos)
            {
                touchingLeftWall = false;
            }
        }

        transform.position = new Vector3(x, y, z);
        
    }
}
