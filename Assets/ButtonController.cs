using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject player;

    int index;
    Vector3[] directions = new[] { Vector3.down, Vector3.right, Vector3.forward, };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        index = (index + 1) % directions.Length;
        player.SendMessage("ChangeGravity", directions[index]);
    }
}
