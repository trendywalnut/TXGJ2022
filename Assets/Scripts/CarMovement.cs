using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private int gear_level;

    private float horizontalinput;
    private float car_rotation;

    public float rotation_multiplier;

    private Transform car_transform;

    void Start()
    {
        car_transform = GetComponent<Transform>();
    }

    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        MoveCar();
    }

    private void HandleInput()
    {
        horizontalinput = Input.GetAxisRaw("Horizontal");
        car_rotation = horizontalinput * rotation_multiplier;
        
    }

    private void MoveCar()
    {
        car_transform.Rotate(0f, car_rotation, 0f);
    }
}
