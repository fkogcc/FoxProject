using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaCol : MonoBehaviour
{
    Vector3 kjumpForce = new Vector3(0, 30.0f, 0);
    Rigidbody _rb;
    // 当たった回数のカウント.
    private int _collCount = 0;

    private void Start()
    {
    }
    private void FixedUpdate()
    {
        SceneReset();
    }
    private void SceneReset()
    {
        //// 三回以上マグマに触れたら強制的に再スタート
        //if(_collCount > 3)
        //{
        //    // シーンを読み込む
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _rb = other.gameObject.GetComponent<Rigidbody>();
            //_rb = other.GetComponent<Rigidbody>();
            _rb.velocity = kjumpForce;
 //           _rb.AddForce(kjumpForce,ForceMode.Impulse);
        }
    }
}
