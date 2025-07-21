using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTrashCan : MonoBehaviour
{
    private PlayerState state;
    // Start is called before the first frame update
    private void Start()
    {
        state = GetComponent<PlayerState>();
    }
    // Update is called once per frame
    void Update()
    {
        if (state.canclicked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                state.isFreeze = false;
                state.canclicked = false;
                transform.position = state.RealPos;
            }
        }
    }
}
