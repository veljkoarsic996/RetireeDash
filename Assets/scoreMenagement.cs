using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreMenagement : MonoBehaviour
{
    public int score = 0;
    int remaining = 2;

    public Text scoreTxt;
    public Text remainingTxt;

    public GameObject victory;
    public GameObject scoreCanvas;
    private void Start()
    {
        remaining = GameObject.FindGameObjectsWithTag("Papir").Length;
        scoreTxt.text = score + "";
        remainingTxt.text = remaining + "";
    }

    private void Update()
    {
        if (remaining == 0) {
            Time.timeScale = 0;
            victory.SetActive(true);
            scoreCanvas.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Papir"))
        {

            Destroy(other.gameObject);
            score++;
            remaining--;
            remainingTxt.text = remaining + "";
            scoreTxt.text = score + "";
        }
    }
 }
