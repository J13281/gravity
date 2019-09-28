using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    bool isCapture;
    Vector3 prev;

    const float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCapture)
        {
            if (Input.GetMouseButtonUp(1))
            {
                isCapture = false;
            }
            else
            {
                var f = (Input.mousePosition - prev) * speed;
                transform.RotateAround(player.position, -PlayerController.direction, f.x);
                prev = Input.mousePosition;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                prev = Input.mousePosition;
                isCapture = true;
            }
        }
    }
}
