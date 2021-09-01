using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{

    public GameObject _cubeFactoryObj;
    public GameObject _cubeObj;
    // Start is called before the first frame update

    void Start()
    {
        //Debug.Log("Make Test Cube");
        MakeCube();
    }

    // This method manufactures a new cube by cloning the Cube object and placing it under the Cube Factory object
    //  where it will fall to the ground by gravity
    public GameObject MakeCube()
    {
        if (_cubeFactoryObj && _cubeObj)
        {
            GameObject newCube = Instantiate(_cubeObj, _cubeFactoryObj.transform.position, _cubeFactoryObj.transform.rotation) as GameObject;
            Vector3 cubepos = _cubeFactoryObj.transform.position;
            cubepos.x += .125f;
            cubepos.z -= .125f;
            cubepos.y -= .36f;
            newCube.transform.position = cubepos;
            newCube.transform.rotation = _cubeFactoryObj.transform.rotation;
            
            // Must not have glueable tag on creation or wonky stuff happens
            newCube.tag = "Untagged";

            return newCube;
        }

        return null;
    }


    //This is the event receiver from the button that actuates the Cube Factory.  It just calls the MakeCube function
    public void MakeCubeCallback()
    {
       //Debug.Log("Cube Factory Button Pressed");
       MakeCube();
    }
}
