using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GravityController
{
    const float gravity_power = 18;
    const float jump_power = 10;

    Vector3 current;

    void m1()
    {
        var v = new Vector3(1, 1, 1);
    }

    public static Vector3 JumpVector(Vector3 direction)
    {
        return -direction * jump_power;
    }

    public static Vector3 UpdateGravity(Vector3 direction, Vector3 gravity)
    {
        var g = gravity_power * Time.deltaTime;

        if (direction == Vector3.down)
        {
            gravity.x = 0;
            gravity.y -= g;
            gravity.z = 0;
        }
        else if (direction == Vector3.up)
        {
            gravity.x = 0;
            gravity.y += g;
            gravity.z = 0;
        }
        else if (direction == Vector3.left)
        {
            gravity.x -= g;
            gravity.y = 0;
            gravity.z = 0;
        }
        else if (direction == Vector3.right)
        {
            gravity.x += g;
            gravity.y = 0;
            gravity.z = 0;
        }
        else if (direction == Vector3.back)
        {
            gravity.x = 0;
            gravity.y = 0;
            gravity.z -= g;
        }
        else if (direction == Vector3.forward)
        {
            gravity.x = 0;
            gravity.y = 0;
            gravity.z += g;
        }

        return gravity;
    }

    public static Vector3 IgnoreGravityVector(Vector3 direction, Vector3 move)
    {
        if (direction == Vector3.down || direction == Vector3.up)
        {
            move.y = 0;
        }
        else if (direction == Vector3.left || direction == Vector3.right)
        {
            move.x = 0;
        }
        else if (direction == Vector3.forward || direction == Vector3.back)
        {
            move.z = 0;
        }

        return move;
    }
}
