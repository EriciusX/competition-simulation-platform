using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleLogic : MonoBehaviour
{
    public GameObject UIMain;
    public GameObject UIOpen;
    public GameObject UILocal;
    public GameObject UIParam;

    private int state = 0;
    private int preState = 0;

    public void Button()
    {
        var button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        switch (button.name) {
            case "Open Button": 
                state = 1;
                OpenInterface();
                preState = state;
                break;
            case "Param Button":
                state = 2;
                OpenInterface();
                preState = state;
                break;
            case "Back Button":
                state = 0;
                Back();
                break;
            case "Local Button":
                break;  
        }
    }

    private void OpenInterface()
    {
        if (state == 1) {
            UIOpen.SetActive(true);
            UIMain.SetActive(false);
        }
    }

    private void Back()
    {
        if (preState == 1) {
            UIOpen.SetActive(false);
            UIMain.SetActive(true);
        } else if (preState == 0) {
            SceneManager.LoadScene(0);
        }
        preState = state;
    }
}
