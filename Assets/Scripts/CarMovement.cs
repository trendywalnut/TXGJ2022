using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarMovement : MonoBehaviour
{

    private int gear_level;

    private float horizontalinput;
    private float car_rotation;

    public float rotation_multiplier;
    public float car_speed;

    private Transform car_transform;
    private Rigidbody car_rb;

    public GameObject moveToPoint;

    //Sequence mySequence = DOTween.Sequence();


    void Start()
    {
        DOTween.Init();
        car_transform = GetComponent<Transform>();
        car_rb = GetComponent<Rigidbody>();
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

        //Debug.Log(horizontalinput);
        
    }

    private void MoveCar()
    {
        //move car forward
        car_rb.velocity = transform.forward * car_speed;

        car_transform.Rotate(0f, car_rotation, 0f);

        if(horizontalinput == 0)
        {
            //Vector3 carRotation = car_transform.eulerAngles;
            Vector3 resetRotation = new Vector3(0, 0, 0);
            car_transform.DORotate(resetRotation, 0.5f).SetAutoKill(true);
        }
        else
        {
            DOTween.KillAll();
        }
    }
}
