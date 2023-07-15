using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool _isRunning = false;

    private void FixedUpdate()
    {
        SendInputToServer();
    }

   /*private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _isRunning = false;
        }
        else
        {
            _isRunning = true;
        }
        SendRunningToServer();
    }*/

    private void SendInputToServer()
    {
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.Z),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.Q),
            Input.GetKey(KeyCode.D),
        };

        ClientSend.PlayerMovement(_inputs);
    }

    /*private void SendRunningToServer()
    {
        ClientSend.PlayerRun(_isRunning);
    }*/
}
