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
                    otherbody = otherObject.GetComponent<Rigidbody>();

                    gameObject.AddComponent<FixedJoint>();
                    gameObject.GetComponent<FixedJoint>().connectedBody = otherbody;
                    hasJoint = true;
                    tag = "Untagged";
                }

            }
        }
    }


    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
