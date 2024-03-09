using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple, rigidbody-based first person controller that supports mouse and keyboard input.
/// </summary>

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private Camera _firstPersonCamera; // Connect your camera here in editor.
    public Camera _firstPersonCamera; // Connect your camera here in editor.
    [SerializeField] private Transform _groundChecker; // Connect your "groundchecker" object here.
    [SerializeField] private LayerMask _groundMask; // Use Unity's layer system to tag jumpable ground.
    [SerializeField] private float _runSpeed, _jumpHeight, _mouseSensitivity; // Adjustable settings for fine tuning movement.

    private Rigidbody _rigidbody; // Our rigidbody that we'll change the velocity of to move.
    private float _xRotation; // Used to store our camera's vertical rotation. (X refers to a component of an Euler angle.)
    private bool _isGrounded; // Store whether we are currently touching the upgrade. We set this one time in update to avoid Unity timing issues.

    private void Start()
    {
        // This method locks our cursor to the middle of the screen while in play mode.
       // Cursor.lockState = CursorLockMode.Locked;

        //Don't lock this (don't use above line), otherwise cannot click menu

        _rigidbody = GetComponent<Rigidbody>();
    }

    // Called once per frame. Dependent on hardware speed.
    //private void Update()
    public void Update()
    {
        // Here's our ground check, projecting a sphere from an empty object at the foot of our player.
        _isGrounded = Physics.CheckSphere(_groundChecker.position, .5f, _groundMask);

        // Rigidbody character controllers can have unexpected interactions with slopes. (Picture a marble going down a ramp.)
        // This is a somewhat hacky solution to a bug which causes the character to spin uncontrollaby if they move diagonally
        // on a slope.
        if (_isGrounded)
            _rigidbody.angularVelocity = Vector3.zero;

        // JUMP
        // Handling our jump is just like in our 2D project.
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpHeight, _rigidbody.velocity.z);
        }

        // GROUND MOVEMENT
        // Get our horizontal and horizontal inputs using Unity's input system. Note that vertical is the z axis, since we are in 3D space.
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // Here we construct a "wish move": the direction we would like to go in the future.
        // Our input floats are multiplied by Vector3s representing our camera's facing, so we move relative to the direction we are looking.
        Vector3 forwardDirection = zInput * transform.forward * Time.deltaTime;
        Vector3 strafeDirection = xInput * transform.right * Time.deltaTime;

        // Vector3's ".normalized" flattens any input to a curve between 0 and 1, so we don't move faster on our diagonals.
        Vector3 wishMove = (forwardDirection + strafeDirection).normalized * _runSpeed;

        // Finally we send our wishmove to the rigidbody to actually move through space.
        _rigidbody.velocity = new Vector3(wishMove.x, _rigidbody.velocity.y, wishMove.z);

        // Call a method to adjust the rotation of the player object to reflect mouse movement.
        MouseLook();
    }

    // Handles turning the camera in respones to player mouse movements.
    private void MouseLook()
    {
        // Get our inputs using Unity's input system and adjusts them to reflect mouse sensitivity settings.
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        // Our vertical rotation needs to be "clamped" so we can't look directly backwards, turning upside down.
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        // Then we apply that rotation only to our camera.
        _firstPersonCamera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        // Our horizontal rotation we apply to our entire character object.
        transform.Rotate(Vector3.up * mouseX);
    }
}