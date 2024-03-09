using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerController playerControl;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        playerControl = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //playerControl.Update();
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }

    public PlayerInput.OnFootActions OnFoot
    {
        get
        {
            return onFoot;
        }
    }
}
