using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3D : MonoBehaviour
{
    bool _isJumpNow;// �W�����v���Ă��邩�ǂ���
    private Rigidbody _Rigid;// �v���C���[�̃��W�b�g�{�f�B
    float _jumpPower = 25.0f;// �W�����v��
    private Vector3 _latestPos;// �O���Position
    float _topSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _Rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float hori = Input.GetAxis("Horizontal");
        //float vert = Input.GetAxis("Vertical");
        //float speedX = hori * 0.01f;// ����
        //float speedZ = vert * 0.01f;// ����
        ////float speedX = hori * 25.0f;// ����
        ////float speedZ = vert * 25.0f;// ����
        //Vector3 vec = new Vector3(speedX, 0, speedZ);

        //if (hori != 0 || vert != 0)
        //{
        //    //transform.position += new Vector3(hori / 10.0f, 0.0f, 0.0f);
        //    // �X�e�B�b�N�̕������x�����ő��x����
        //    //rigid.transform.position += new Vector3(speed, 0.0f, 0.0f);
        //    //rigid.transform.position += new Vector3(0.1f, 0.0f, 0.0f);

        //    Vector3 diff = new Vector3(transform.position.x - _latestPos.x, 0.0f, transform.position.z - _latestPos.z);// �O�񂩂�ǂ��ɐi�񂾂����x�N�g���Ŏ擾
        //    _latestPos = transform.position;

        //    // �X�e�B�b�N�̕������x�����ő��x����
        //    _Rigid.transform.position += new Vector3(speedX, 0.0f, speedZ);

        //    if(diff.magnitude > 0.01f)
        //    {
        //        _Rigid.transform.rotation = Quaternion.LookRotation(diff);// �����̕ύX
        //    }



        //    // ���x��10�ȉ��Ȃ�Η͂�������
        //    if (_Rigid.velocity.x < _topSpeed && _Rigid.velocity.x > -_topSpeed &&
        //        _Rigid.velocity.z < _topSpeed && _Rigid.velocity.z > -_topSpeed)
        //    {
        //        //rigid.AddForce(vec);

        //        //rigid.velocity = new Vector3(speed, 0.0f, 0.0f);
        //    }

        //}

        if (Input.GetKeyDown("joystick button 0"))
        {
            //transform.position += new Vector3(0.0f, 1.0f, 0.0f);
            Jump();
        }

        // �ړ�
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * 1);// ����
        }

        // ����
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            transform.rotation = Quaternion.LookRotation(
                transform.position +
                (Vector3.right * Input.GetAxisRaw("Horizontal")) +
                (Vector3.forward * Input.GetAxisRaw("Vertical")) -
                transform.position);
        }

    }

    private void FixedUpdate()
    {
        // �������珉���ʒu�ɖ߂�
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �n�ʂ��痣�ꂽ��
        if (_isJumpNow)
        {
            _isJumpNow = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // �n�ʂɂ�����
        if (!_isJumpNow)
        {
            _isJumpNow = true;
        }
    }

    // �W�����v����
    void Jump()
    {
        if (_isJumpNow)
        {
            return;
        }
        _Rigid.AddForce(transform.up * _jumpPower, ForceMode.Impulse);
        _isJumpNow = true;
    }
}
