using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + 2.6f, _player.transform.position.z - 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // �J�����̌���
        float x = Input.GetAxis("Horizontal2");
        float y = Input.GetAxis("Vertical2");

        // X�����ɉ�]
        if(Mathf.Abs(x) > 0.1f)
        {
            //Debug.Log(x);
            transform.RotateAround(_player.transform.position, Vector3.up, x);
        }
        // Y�����ɉ�]
        if(Mathf.Abs(y) > 0.1f)
        {
            //Debug.Log(y);
            //if(transform.position.y < 1.0f)
            //{
            //    transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
            //}
            //if(transform.position.y < 5.5f)
            //{
            //    transform.position = new Vector3(transform.position.x, 5.5f, transform.position.z);
            //}
            transform.RotateAround(_player.transform.position, transform.right, y);
        }

        Debug.Log(transform.position);

        //// �J�����̈ړ�
        //Vector3 cameraForward = Vector3.Scale(transform.position, new Vector3(1.0f,0.0f,1.0f)).normalized;

        //// �J�����
        //Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * Player3DMove._speed;// �O��
        //Vector3 moveX = this.transform.right * Input.GetAxis("Horizontal") * Player3DMove._speed;// ���E
    }

    private void FixedUpdate()
    {
        //this.transform.position = _player.transform.position;
    }
}
