using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is linked to the cube gameobject to enable snap and glue
public class CubeBehaviors : MonoBehaviour
{
    bool hasJoint;
    GameObject otherObject;
    Rigidbody otherbody;
    string glueState = "Glueable";


    private void Start()
    {
        tag = glueState;
    }

    void OnCollisionEnter(Collision collision)
    {

        //belt and suspenders checks to ensure we can glue this object
        if (!hasJoint && CompareTag(glueState))
        {
            otherObject = collision.gameObject;

            if (otherObject.CompareTag(glueState))
            {
                if (otherObject.GetComponent<Rigidbody>() != null)
                {
                    //otherObject.transform.parent = gameObject.transform;
                    //otherObject.transform.localRotation = Quaternion.identity;
                    //otherObject.transform.localPosition = Vector3.zero;

                    otherbody = otherObject.GetComponent<Rigidbody>();

                    gameObject.AddComponent<FixedJoint>();
                    gameObject.GetComponent<FixedJoint>().connectedBody = otherbody;
                    hasJoint = true;
                    
                    // Untag the newly attached object so it cannot try to glue again.
                    otherObject.tag = "Untagged";

                    
                }

            }
        }
    }


    //// Update is called once per frame
    void Update()
    {
        if (Input.GetKey("z"))
        {
            // slow down time from 1 too 0.5
            Time.timeScale = .01f;
        }
        else if(Input.GetKey("x"))
        {
            Time.timeScale = 1;
        }
    }
}
