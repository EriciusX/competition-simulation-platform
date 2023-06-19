using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class OptionLogic : MonoBehaviour
{
    public void Button()
    {
        var button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        switch (button.name) {
            case "Back Button":
                SceneManager.LoadScene(0);
                break;
        }
    }
}
