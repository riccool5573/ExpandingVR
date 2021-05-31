using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
public class GUN : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Action_Boolean trigger, eject;
    [SerializeField]
    private Transform barrelPos;
    private Magazine magazine;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip gunFire, click;
    [SerializeField]
    private Rigidbody recoilPos;
    private bool shot, isMagIn = false;
    [SerializeField]
    private GameObject bullet;
    private Rigidbody rb;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    public void Shoot()
    {
        if (trigger.state && !shot && isMagIn)
        {
            int bullets = magazine.GetHolding();
            if (bullets >= 1)
            {
                Gun();
            }
            else
            {
                source.PlayOneShot(click);
            }
        }
        else if (!trigger.state)
        {
            shot = false;
        }
        if (eject.state)
        {
            Eject();
        }
    }


    private void Gun()
    {
        Debug.Log("shot");
        GameObject temp = Instantiate(bullet, barrelPos.position, Quaternion.identity);
        Rigidbody body = temp.GetComponent<Rigidbody>();
        body.velocity = transform.TransformDirection(-Vector3.forward * 20);
        source.PlayOneShot(gunFire);
        magazine.Shot();
        shot = true;
        recoilPos.velocity += transform.forward * 30;
        recoilPos.velocity += transform.up * 30;
    }
    private void Eject() {
        magazine.Eject();
        isMagIn = false;
    }
    public void setMag(bool set)
    {
        isMagIn = set;
    }  
    public void SetMagazine(Magazine mag)
    {
        magazine = mag;
    }
}
