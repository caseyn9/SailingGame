using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastController : MonoBehaviour
{
    [Range(-10, 10)]
    public float mastRotation = 0;
    private float lastRotation = 0;
    private int _animId;
    private int AnimId
    {
        get {
            return _animId;
        }
        // cancel old anim before settin new one
        set{
            LeanTween.cancel(_animId);
            _animId = value;
        }
    }

    private void FixedUpdate()
    {
        if(mastRotation != lastRotation)
        {
            if(mastRotation > 0)
            {
                MastRight(Mathf.Abs(mastRotation - 9.9f));
            }
            else if(mastRotation < 0)
            {
                MastLeft(Mathf.Abs(mastRotation + 9.9f));
            }
            else
            {
                MastStop();
            }
            lastRotation = mastRotation;
        }
    }

    public void MastLeft(float rotationTime)
    {
        AnimId = LeanTween.rotateAround(gameObject, Vector3.down, 360f, rotationTime).setLoopClamp().id;
    }
    public void MastRight(float rotationTime)
    {
        AnimId = LeanTween.rotateAround(gameObject, Vector3.up, 360f, rotationTime).setLoopClamp().id;
    }

    public void MastStop()
    {
        LeanTween.cancel(AnimId);
    }
}
