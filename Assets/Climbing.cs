using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
class Climbing : MonoBehaviour
{
    [SerializeField]
    private ClimbingHand climbingHandL;
    [SerializeField]
    private ClimbingHand climbingHandR;
    [SerializeField]
    private SteamVR_Action_Boolean gripL;
    [SerializeField]
    private SteamVR_Action_Boolean gripR;
    [SerializeField]
    private ConfigurableJoint clumberHandle;
    private ClimbingHand activeHand;
    private bool climbing;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        UpdateHand(climbingHandL);// check both hands every frame
        UpdateHand(climbingHandR);
        if (climbing)
        {
            clumberHandle.targetPosition = -activeHand.transform.localPosition; //if climbing put joint at position of hand
        }

    }
    private void UpdateHand(ClimbingHand Hand)
    {
        if (climbing && Hand == activeHand)
        {
            if (activeHand == climbingHandL)
            { //if climbing check if grip is loosened, if it is disable climbing
                if (!gripL.state)
                {
                    clumberHandle.connectedBody = null;
                    climbing = false;
                }
            }
            else
            {
                if (!gripR.state)
                {
                    clumberHandle.connectedBody = null;
                    climbing = false;
                }
            }

        }
        else
        {
            Debug.Log("do teh thing");//when not climbing check if the grip is pressed, and if the hand is colliding with a climbable object, if so start climbing
            if ((Hand = climbingHandL) && gripL.state)
            {
                Hand.SetGrabbing(true);
                if (Hand.GetTouching())
                {
                    activeHand = Hand;
                    climbing = true;
                    clumberHandle.transform.position = Hand.transform.position;
                    clumberHandle.connectedBody = GetComponent<Rigidbody>();
                    Hand.SetGrabbing(false);
                }
            }
            else if ((Hand = climbingHandR) && gripR.state)// do that for both hands
            {
                Hand.SetGrabbing(true);
                if (Hand.GetTouching())
                {
                    activeHand = Hand;
                    climbing = true;
                    clumberHandle.transform.position = Hand.transform.position;
                    clumberHandle.connectedBody = GetComponent<Rigidbody>();
                    Hand.SetGrabbing(false);
                }
            }
        }
    }
}
