using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance = null;
    private Vector2 dir;
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        dir = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            dir += new Vector2(0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += new Vector2(0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += new Vector2(-1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += new Vector2(1, 0);
        }

        Player.Instance.RotatePlayer(dir.normalized,1);
        Player.Instance.MovePlayer(dir.normalized);
    }
    public bool OnKey(KeyCode key) => Input.GetKey(key);
}
