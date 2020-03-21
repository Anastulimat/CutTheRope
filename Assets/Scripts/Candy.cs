using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{

    public float distanceFromChaineEnd = 0.3f;

    public void connectRopeEnd(Rigidbody2D endRB)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = endRB;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0f, -distanceFromChaineEnd);
    }

    private void Update()
    {
        if (TriggerAnimation.isEating)
        {
            Destroy(gameObject, 0.07f);
        }
    }
}
