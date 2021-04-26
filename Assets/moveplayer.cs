using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class moveplayer : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Action_Vector2 moveValue;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private Rigidbody head;
    private float speed;
    // Update is called once per frame
    void Update()
    {
        if(moveValue.axis.y > 0)
        {
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(0, 0, moveValue.axis.y));
            speed = moveValue.axis.y * sensitivity;
            speed = Mathf.Clamp(speed, 0, maxSpeed);
            transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up);
        }        
    }
}
