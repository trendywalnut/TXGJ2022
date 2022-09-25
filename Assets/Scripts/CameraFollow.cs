using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    public Transform thingToFollow;
    void Start()
    {
        DOTween.Init();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position.DOMoveZ(thingToFollow, 1).SetLoops(-1);
    }
}
