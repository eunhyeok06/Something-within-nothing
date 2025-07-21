using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerState state;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state.isFreeze) return;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }
}
