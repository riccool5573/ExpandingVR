using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingHand : MonoBehaviour
{
    private bool touching;
    private bool grabbing;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.CompareTag("Climb"))
        {
            touching = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Climb"))
            touching = false;
       
    }
    public void SetGrabbing(bool set)
    {
        grabbing = set;
    }
    public bool GetGrabbing()
    {
        return grabbing;
    }
    public bool GetTouching()
    {
        return touching;
    }
}
