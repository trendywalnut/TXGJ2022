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

    public bool inGear1 = false;
    public bool inGear2 = false;
    public bool inGear3 = false;

    //audio shit
    public AudioClip breakClip;
    public AudioClip hornClip;
    private AudioManager theAM;

    public int gear1Pitch = 1;
    public int gear2Pitch = 2;
    public int gear3Pitch = 3;

    public int gearShiftTime = 2;



    //public GameObject moveToPoint;

    //Sequence mySequence = DOTween.Sequence();


    void Start()
    {
        DOTween.Init();
        car_transform = GetComponent<Transform>();
        car_rb = GetComponent<Rigidbody>();

        car_speed = base_car_speed;
        gear_level = 1;
        inGear1 = true;


        //audio
        theAM = FindObjectOfType<AudioManager>();

        theAM.carEngine.GetComponent<AudioSource>();



    }

    void Update()
    {
        HandleInput();
        GearShiftAudio();
        
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
            HandBrake();

            //audio
            StartCoroutine (carStopSFX());

            IEnumerator carStopSFX()
            {
                theAM.CarSFXPlayer(breakClip);
                yield return new WaitForSeconds(2.2f);
                theAM.carEngine.Stop();
            }




            /*IEnumerator showTextFuntion()
            {
                TextUI.text = "Welcome to Number Wizard!";
                yield return new WaitForSeconds(3f);
                TextUI.text = ("The highest number you can pick is " + max);
                yield return new WaitForSeconds(3f);
                TextUI.text = ("The lowest number you can pick is " + min);
            }*/

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
                inGear1 = true;
                inGear2 = false;
                inGear3 = false;
                break;
            case 2:
                gear_level++;
                car_speed *= 1.5f;
                inGear2 = true;
                inGear1 = false;
                inGear3 = false;
                break;
            case 3:
                gear_level = 1;
                ResetSpeedCheck();
                inGear3 = true;
                inGear1 = false;
                inGear2 = false;
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
        DOTween.To(() => car_speed, x => car_speed = x, 0f, 0.5f);
    }


    public void GearShiftAudio()
    {
        if (inGear1)
        { 
            theAM.carEngine.pitch = gear1Pitch;

        }

        if (inGear2)
        {
            theAM.carEngine.pitch = gear2Pitch;
        }

        if (inGear3)
        {
            theAM.carEngine.pitch = gear3Pitch;
        }
    }
}
