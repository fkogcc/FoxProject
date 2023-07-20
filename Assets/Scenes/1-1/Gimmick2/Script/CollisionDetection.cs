using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    //[SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // プレイヤーがEmptyのコライダーに入ったとき
            Debug.Log("範囲内");
            // InspectorタブのonTriggerStayで指定された処理を実行する
            //onTriggerStay.Invoke(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // プレイヤーがEmptyのコライダーから出たとき
            Debug.Log("範囲外");
        }
    }
}
