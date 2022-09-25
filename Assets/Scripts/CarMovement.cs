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
    public float base_car_speed;
    public float car_speed;

    private Transform car_transform;
    private Rigidbody car_rb;

    private Vector3 slowCarVelocity;

    public bool handBrakePulled = false;

    //audio shit
    public AudioClip breakClip;
    public AudioClip hornClip;
    private AudioManager theAM;

    public int gear1Pitch = 1;
    public int gear2Pitch = 2;
    public int gear3Pitch = 3;


    //public GameObject moveToPoint;

    //Sequence mySequence = DOTween.Sequence();


    void Start()
    {
        DOTween.Init();
        car_transform = GetComponent<Transform>();
        car_rb = GetComponent<Rigidbody>();

        car_speed = base_car_speed;
        gear_level = 1;


        //audio
        theAM = FindObjectOfType<AudioManager>();

        theAM.carEngine.GetComponent<AudioSource>();



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
        horizontalinput = -Input.GetAxisRaw("Horizontal");
        car_rotation = horizontalinput * rotation_multiplier;

        if (Input.GetKeyDown(KeyCode.W))
        {
            ShiftGear();            

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //play honk noise
            theAM.CarSFXPlayer(hornClip);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            //audio
            HandBrake();
            StartCoroutine (carStopSFX());

            IEnumerator carStopSFX()
            {
                theAM.CarSFXPlayer(breakClip);
                yield return new WaitForSeconds(1f);
                HandBrake();
                yield return new WaitForSeconds(1.2f);
                theAM.carEngine.Stop();
            }


        }
        
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
            car_transform.DORotate(resetRotation, 0.5f).SetId("rotate");
        }
        else
        {
            DOTween.Kill("rotate");
        }
    }

    private void ShiftGear()
    {
        switch (gear_level)
        {
            case 1:
                gear_level++;
                car_speed *= gear_level;
                DOTween.To(() => theAM.carEngine.pitch, x => theAM.carEngine.pitch = x, gear2Pitch, 1f);

                break;
            case 2:
                gear_level++;
                car_speed *= 1.5f;
                DOTween.To(() => theAM.carEngine.pitch, x => theAM.carEngine.pitch = x, gear3Pitch, 1f);

                break;
            case 3:
                gear_level = 1;
                ResetSpeedCheck();
                DOTween.To(() => theAM.carEngine.pitch, x => theAM.carEngine.pitch = x, gear1Pitch, 1.7f);

                break;
        }
        Debug.Log(gear_level);     
    }

    private void ResetSpeedCheck()
    {
        if(gear_level == 1 && car_speed != base_car_speed)
        {
            DOTween.To(() => car_speed, x => car_speed = x, base_car_speed, 0.2f);
        }
    }

    private void HandBrake()
    {
        handBrakePulled = true;
        DOTween.To(() => car_speed, x => car_speed = x, 0f, 0.5f);
    }


}
