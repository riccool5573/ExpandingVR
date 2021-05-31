using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class Magazine : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip insert, eject;
    [SerializeField]
    private int capacity;
    private int holding;
    private bool attached;
    private bool timer;
    private int counter;
    private Rigidbody body;
    private Interactable interact;
    private Throwable throwable;

    private void Start()
    {
        holding = capacity;
        attached = false;
        timer = false;
        body = this.gameObject.GetComponent<Rigidbody>();
        interact = this.gameObject.GetComponent<Interactable>();
        throwable = this.gameObject.GetComponent<Throwable>();
    }
    private void Update()
    {
        if (timer && counter <= 30)
        {
            counter++;
           
        }
        else
        {
            timer = false;
            counter = 0;
        }
    }
    public int GetHolding()
    {
        return holding;
    }
    public void Shot()
    {
        holding--;
    }
    public void Eject()
    {
        if (attached)
        {
            this.gameObject.transform.parent = null;
            source.PlayOneShot(eject);
            body.useGravity = true;
            body.isKinematic = false;
            attached = false;
            timer = true;
            interact.enabled = true;
            throwable.enabled = true;
            body.velocity = this.transform.forward * 2;
        }
    }
    private void Attach(GameObject position)
    {
        
        if (!attached && !timer)
        {
            if (this.gameObject.transform.parent != null)
            {
                interact.attachedToHand.DetachObject(this.gameObject, false);
            }
            interact.enabled = false;
            throwable.enabled = false;
            this.gameObject.transform.parent = position.transform.GetChild(0);
            this.gameObject.transform.localPosition = position.transform.GetChild(0).gameObject.transform.localPosition;
            body.useGravity = false;
            body.isKinematic = true;
            source.PlayOneShot(insert);
            attached = true;
            if(position.transform.parent.GetComponent<GUN>() != null)
            position.transform.parent.GetComponent<GUN>().SetMagazine(this.gameObject.GetComponent<Magazine>()); //this is one of the most horrible lines of code i've written
            else
            {
                position.transform.parent.parent.parent.GetComponent<MachineGun>().OnMagEnter(this.gameObject.GetComponent<Magazine>()); //gotta fix

            }
            this.gameObject.transform.parent.parent.parent.GetComponent<GUN>().setMag(true);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "magazineSlot")
        {
            Attach(other.gameObject);
            
        }

    }
}
