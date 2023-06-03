using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TransScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Trans()
    {
        var button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        switch (button.name) {
            case "Start Button": 
                SceneManager.LoadScene(0);
                break;
            case "Scene Button": 
                SceneManager.LoadScene(0);
                break;
            case "Vehicle Button": 
                SceneManager.LoadScene(0);
                break;
            case "Option Button": 
                SceneManager.LoadScene(0);
                break;
        }
    }
}
