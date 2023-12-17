using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public bool isOn;
    public Light Flight;
    public AudioSource source;
    public AudioClip clickSound;
    private float lightBattery = 10;
    public TMP_Text bateryText;
    private void Start()
    {
    }
    private void Update()
    {
        bateryText.text = (int)lightBattery + "%";
        if (Input.GetKeyDown(KeyCode.X))
        {
            isOn = !isOn;  //после нажатия меняет на противоположное значение (true/false)
            source.PlayOneShot(clickSound);
        }
        Flight.enabled = isOn;
        if (Flight.enabled = isOn)
        {
            InvokeRepeating("BateryMinus", 0, 20);
        } 
        if(lightBattery <= 0)
        {
            Flight.enabled = false;

        }
    }
    private void BateryMinus()
    {
        if(lightBattery >0)
        {
            lightBattery -= 0.01f;
        }    
    }
}
