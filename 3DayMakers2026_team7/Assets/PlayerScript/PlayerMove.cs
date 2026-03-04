using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 120;
    [SerializeField] private Transform Gun;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float verticalInput;
    private float currentAngle = 0f;
    private bool isMoving = false;

    private void OnEnable()
    {
        EventHub.GameStartEvent -= EnableMove;
    }

    private void OnDisable()
    {
        EventHub.GameStartEvent -= EnableMove;
    }

    private void EnableMove()
    {
        isMoving = true;
    }
    void Update()
    {
        if (!isMoving) 
            return;
        // verticalInput = (Keyboard.current.wKey.isPressed ? 1 : 0) + (Keyboard.current.sKey.isPressed ? -1 : 0);
        HandleInput();

        Move();

        RotateGun();
    }
    private void HandleInput()
    {
        verticalInput = (Keyboard.current.wKey.isPressed ? 1 : 0) + (Keyboard.current.sKey.isPressed ? -1 : 0);
    }
   
    private void Move()
    {
        Vector3 pos = transform.position;

        pos.y += verticalInput * moveSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, -4f, 4f);

        transform.position = pos;
        //Vector3 move = new Vector3(0,verticalInput,0);
        //transform.position += move * moveSpeed * Time.deltaTime;
    }
    private void RotateGun()
    {
        float rotateInput = (Keyboard.current.qKey.isPressed ? 1 : 0) + (Keyboard.current.eKey.isPressed ? -1 : 0);

        currentAngle += rotateInput * rotateSpeed * Time.deltaTime;

        currentAngle = Mathf.Clamp(currentAngle, -85f, 85f);

        Gun.localRotation = Quaternion.Euler(0f,0f,currentAngle);
    }
}
