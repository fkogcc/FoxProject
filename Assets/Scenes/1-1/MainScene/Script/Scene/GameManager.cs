using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("“–‚½‚Á‚Ä‚¢‚é");
        if (other.tag == "Gimmick1")
        {
            if (Input.GetKeyDown("joystick button 3"))
            {
                Debug.Log("‰Ÿ‚µ‚½");
                SceneManager.LoadScene("Gimmick1Scene");
            }
        }
    }
}
