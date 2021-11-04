using System.Collections;
using System.Collections.Generic;
using BNG;
using TMPro;
using UnityEngine;

public class HeadsUpDisplay : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    private Grabber _grabber;
    private TMP_Text _debugtext;


    // Start is called before the first frame update
    void Start()
    {
        _grabber = GetComponentInChildren<Grabber>();
        _debugtext = GetComponentInChildren<TMP_Text>();
        hud.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        var rotation = transform.rotation.eulerAngles;
        
        var rotx = rotation.x;
        var rotz = rotation.z;
        var xrange = rotation.x > -10f && rotation.x < 10f;  // fingers forward, palm flat
        var zrange = rotation.z > 75f && rotation.z < 105f;  // palm within 15 degrees of up

        _debugtext.text = "";
        _debugtext.text = "xrot: " + rotx.ToString();
        _debugtext.text += " -- ";
         _debugtext.text += "zrot: " + rotz.ToString();


        if (xrange && zrange && !_grabber.HoldingItem)
        {
            hud.SetActive(true);
        }
        else
        {
            hud.SetActive(false);
        }

    }
}
