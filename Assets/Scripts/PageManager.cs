using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public int pages;
    public Enemy enemy;
    public TMP_Text pageText;
    public FlashLight flashLight;
    public FirstPersonMovement playerMovement;
    public AudioSource source;
    public AudioClip collectClip;
    private void Update()
    {
        pageText.text = "Pages: " + pages;
    }

    private void OnTriggerEnter(Collider other)
    {
        source.PlayOneShot(collectClip);
        print("page collected!");
        Destroy(other.gameObject);
        pages++;

        if(pages == 1)
        {
            enemy.target = transform;
        }

        if(pages == 2)
        {
            enemy.speed *= 2;
        }

        if(pages == 3)
        {
            flashLight.lightBattery -= 10;
        }
        if (pages == 4)
        {
            enemy.viewDistance += 10;
            enemy.speed *= 2;
        }
        if(pages == 5)
        {
            enemy.speed -= 5;
            playerMovement.canRun = false;
            playerMovement.speed -= 1.5f;
            enemy.viewDistance += 10;
        }
        if( pages == 6)
        {
            SceneManager.LoadScene("TheEnd");
        }
    }
}
