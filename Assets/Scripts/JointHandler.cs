using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointHandler : MonoBehaviour
{
    private ConfigurableJoint joint;
    private Rigidbody rb;
    [SerializeField]
    private Rigidbody gun;
    [SerializeField]
    private Transform position;
    private void Start()
    {
        joint = gameObject.GetComponent<ConfigurableJoint>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    public void Enable()
    {
        joint.xMotion = ConfigurableJointMotion.Limited;
        joint.yMotion = ConfigurableJointMotion.Limited;
        joint.zMotion = ConfigurableJointMotion.Limited;
        joint.angularXMotion = ConfigurableJointMotion.Limited;
        joint.angularYMotion = ConfigurableJointMotion.Limited;
        joint.angularZMotion = ConfigurableJointMotion.Limited;
        //joint.connectedBody = gun;
    }
    public void Disable()
    {
        joint.xMotion = ConfigurableJointMotion.Free;
        joint.yMotion = ConfigurableJointMotion.Free;
        joint.zMotion = ConfigurableJointMotion.Free;
        joint.angularXMotion = ConfigurableJointMotion.Free;
        joint.angularYMotion = ConfigurableJointMotion.Free;
        joint.angularZMotion = ConfigurableJointMotion.Free;
        //joint.connectedBody = null;
        //transform.parent = position;
        //transform.position = position.position;
    }
}
