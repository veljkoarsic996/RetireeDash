using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    #region Singleton

    public static UImanager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Text state;

}
