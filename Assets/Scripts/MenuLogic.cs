using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour {
    public void MainTrans() {
        var button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        switch (button.name) {
            case "Start Button": 
                SceneManager.LoadScene(1);
                break;
            case "Scene Button": 
                SceneManager.LoadScene(2);
                break;
            case "Vehicle Button": 
                SceneManager.LoadScene(3);
                break;
            case "Option Button": 
                SceneManager.LoadScene(4);
                break;
            case "Quit Button":
                Application.Quit();
                break;
        }
    }
}
