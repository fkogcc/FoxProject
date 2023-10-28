using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestFadeUpdate : MonoBehaviour
{
    [SerializeField]
    string targetSceneName = "Gimmick2Scene";
    [SerializeField]
    GameObject transitionPrefab;

    readonly float waitTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(nameof(LoadScene));
        }
    }

    IEnumerator LoadScene()
    {
        Instantiate(transitionPrefab);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(targetSceneName);
    }
}
