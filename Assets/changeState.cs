using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeState : MonoBehaviour
{
    
    public Text state;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            state.color = Color.yellow;
            state.text = "CHASING!!";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            state.color = Color.green;
            state.text = "SAFE!";
        }
    }
}
