using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class bustedScript : MonoBehaviour
{
    public Text state;
    public GameObject canvas;
    public GameObject score;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //new WaitForSeconds(5);
            Time.timeScale = 0;
            canvas.SetActive(true);
            score.SetActive(false);
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }
      
    }

}
