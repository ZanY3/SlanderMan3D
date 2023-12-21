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
    private float lightBattery = 100;
    public TMP_Text bateryText;
    private void Start()
    {
        Application.targetFrameRate = 60;
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
        if (isOn)
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
            lightBattery -= 0.07f;
        }    
    }
}
