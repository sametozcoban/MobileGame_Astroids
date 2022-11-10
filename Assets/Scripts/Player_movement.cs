using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Player_movement : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float rotationSpeed;

    private Camera mainCamera;
    private Rigidbody _rigidbody;

    private Vector3 moveDirection;
   
    void Start()
    {
        mainCamera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate() // Every time the pyhsics system updates. 50 fps.
    {
        if (moveDirection == Vector3.zero){ return;}
        
        _rigidbody.AddForce(moveDirection * forceMagnitude * Time.deltaTime, ForceMode.Force); // If !Vector3.zero, we are adding pyhsics force.
        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, maxVelocity);
    }
    
    void Update()
    {
        TouchPosition();
        PlayerOnScreen();
        RotatePlayer();
    }

    public void TouchPosition()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed) // ıf we wan to check, Currently Touching !!
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            
            Vector3 gameCoordinate = mainCamera.ScreenToWorldPoint(touchPosition);

            moveDirection = transform.position - gameCoordinate;
            moveDirection.z = 0f; // We don't want to into or out of the screen. That's why z= 0f;
            moveDirection.Normalize(); 
        }
        else
        {
            moveDirection = Vector3.zero; 
        }
    }
    public void PlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if (viewPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }
        
        if (viewPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        } 
        else if (viewPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }
        
        transform.position = newPosition;
    }

    public void RotatePlayer()
    {
        if (_rigidbody.velocity == Vector3.zero){ return;}
        Quaternion targetRotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.back); //transform.rotation == currentRotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // Linear interpolation
    }
    
}
