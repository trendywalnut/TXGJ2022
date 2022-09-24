using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMovement : MonoBehaviour
{
    public GameObject main;
    public GameObject left;
    public GameObject mid;
    public GameObject right;

    public GameObject leftScreen;
    public GameObject midScreen;
    public GameObject rightScreen;
    public GameObject leftWaypoint;
    public GameObject midWaypoint;
    public GameObject rightWaypoint;


    int pos = 0;

    void Start()
    {
        leftScreen.SetActive(false);
        midScreen.SetActive(true);
        rightScreen.SetActive(false);

    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(pos == 0)
            {
                left.SetActive(true);
                mid.SetActive(false);
                right.SetActive(false);

                leftScreen.SetActive(true);
                midScreen.SetActive(false);
                rightScreen.SetActive(false);

                main.transform.position = leftWaypoint.transform.position;

                Debug.Log(pos);
                pos--;
                Debug.Log(pos);
            }

            if (pos == -1)
            {
                Debug.Log(pos);
                pos = -1;
                Debug.Log(pos);
            }

            if (pos == 1)
            {
                left.SetActive(false);
                mid.SetActive(true);
                right.SetActive(false);

                leftScreen.SetActive(false);
                midScreen.SetActive(true);
                rightScreen.SetActive(false);

                main.transform.position = midWaypoint.transform.position;

                Debug.Log(pos);
                pos--;
                Debug.Log(pos);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (pos == 0)
            {
                left.SetActive(false);
                mid.SetActive(false);
                right.SetActive(true);

                leftScreen.SetActive(false);
                midScreen.SetActive(false);
                rightScreen.SetActive(true);

                main.transform.position = rightWaypoint.transform.position;


                Debug.Log(pos);
                pos++;
                Debug.Log(pos);
            }

            if (pos == 1)
            {
                Debug.Log(pos);
                pos = 1;
                Debug.Log(pos);
            }

            if (pos == -1)
            {
                left.SetActive(false);
                mid.SetActive(true);
                right.SetActive(false);

                leftScreen.SetActive(false);
                midScreen.SetActive(true);
                rightScreen.SetActive(false);

                main.transform.position = midWaypoint.transform.position;

                Debug.Log(pos);
                pos++;
                Debug.Log(pos);
            }
        }
    }

}
