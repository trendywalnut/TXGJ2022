using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMovement : MonoBehaviour
{
    public GameObject main;
    public GameObject left;
    public GameObject mid;
    public GameObject right;

    //public GameObject leftScreen;
    //public GameObject midScreen;
    //public GameObject rightScreen;
    public GameObject leftWaypoint;
    public GameObject midWaypoint;
    public GameObject rightWaypoint;

    void Start()
    {
        //leftScreen.SetActive(false);
        //midScreen.SetActive(true);
        //rightScreen.SetActive(false);
    }

    void Update()
    {
        left.SetActive(false);
        mid.SetActive(true);
        right.SetActive(false);

        //leftScreen.SetActive(false);
        //midScreen.SetActive(true);
        //rightScreen.SetActive(false);

        main.transform.position = midWaypoint.transform.position;

        if (Input.GetKey(KeyCode.Q))
        {
            //Debug.Log("we are holding q!");

            left.SetActive(true);
            mid.SetActive(false);
            right.SetActive(false);

            //leftScreen.SetActive(true);
            //midScreen.SetActive(false);
            //rightScreen.SetActive(false);

            main.transform.position = leftWaypoint.transform.position;

        }

        else if (Input.GetKey(KeyCode.E))
        {
            //Debug.Log("we are holding e!");

            left.SetActive(false);
            mid.SetActive(false);
            right.SetActive(true);

            //leftScreen.SetActive(false);
            //midScreen.SetActive(false);
            //rightScreen.SetActive(true);

            main.transform.position = rightWaypoint.transform.position;

        }

    }
}

