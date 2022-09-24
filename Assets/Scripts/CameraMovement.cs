using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMovement : MonoBehaviour
{
    public GameObject left;
    public GameObject mid;
    public GameObject right;

    public GameObject leftScreen;
    public GameObject midScreen;
    public GameObject rightScreen;


    int pos = 0;

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

                Debug.Log(pos);
                pos++;
                Debug.Log(pos);
            }
        }
    }

}
