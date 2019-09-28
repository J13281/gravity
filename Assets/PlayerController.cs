using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera _camera;
    CharacterController character;

    const float speed = 3f;
    const float rayRange = 0.1f;
    const float jumpPower = -8;

    Vector3 gravity_v = Vector3.zero;

    public static Vector3 direction = Vector3.down;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        character = GetComponent<CharacterController>();
    }

    Dictionary<Vector3, Vector3> ToEular = new Dictionary<Vector3, Vector3> {
        { Vector3.down, Vector3.zero },
        { Vector3.right, Vector3.forward },
        { Vector3.forward, Vector3.left },
    };

    public void ChangeGravity(Vector3 direction)
    {
        PlayerController.direction = direction;
    }

    // Update is called once per frame
    void Update()
    {
        var e = ToEular[direction] * 90;

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            Quaternion.Euler(e),
            Time.deltaTime * 500);

        var v = GravityController.IgnoreGravityVector(direction,
            Input.GetAxisRaw("Horizontal") * _camera.transform.right
            + Input.GetAxisRaw("Vertical") * _camera.transform.forward);

        var move_v = v.normalized * speed * Time.deltaTime;

        if (IsGround())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gravity_v = jumpPower * direction;
            }
            else
            {
                gravity_v = Vector3.zero;
            }
        }
        else
        {
            gravity_v = GravityController.UpdateGravity(
                direction,
                gravity_v);
        }

        character.Move(move_v + gravity_v * Time.deltaTime);
    }

    bool IsGround()
    {
        Debug.DrawLine(transform.position, transform.position - transform.up * rayRange, Color.red);

        return Physics.Linecast(
            transform.position,
            transform.position - transform.up * rayRange);
    }
}
