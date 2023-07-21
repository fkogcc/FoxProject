using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3D : MonoBehaviour
{
    bool jumpNow;// �W�����v���Ă��邩�ǂ���
    private Rigidbody rigid;// �v���C���[�̃��W�b�g�{�f�B
    float jumpPower = 25.0f;// �W�����v��
    private Vector3 latestPos;// �O���Position
    float topSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        float speedX = hori * 25.0f;// ����
        float speedZ = vert * 25.0f;// ����
        Vector3 vec = new Vector3(speedX, 0, speedZ);

        if (hori != 0 || vert != 0)
        {
            //transform.position += new Vector3(hori / 10.0f, 0.0f, 0.0f);
            // �X�e�B�b�N�̕������x�����ő��x����
            //rigid.transform.position += new Vector3(speed, 0.0f, 0.0f);
            //rigid.transform.position += new Vector3(0.1f, 0.0f, 0.0f);

            Vector3 diff = new Vector3(transform.position.x - latestPos.x, 0.0f, transform.position.z - latestPos.z);// �O�񂩂�ǂ��ɐi�񂾂����x�N�g���Ŏ擾
            latestPos = transform.position;

            // �X�e�B�b�N�̕������x�����ő��x����
            //rigid.transform.position += new Vector3(speedX, 0.0f, speedZ);

            if(diff.magnitude > 0.01f)
            {
                rigid.transform.rotation = Quaternion.LookRotation(diff);// �����̕ύX
            }



            // ���x��10�ȉ��Ȃ�Η͂�������
            if (rigid.velocity.x < topSpeed && rigid.velocity.x > -topSpeed &&
                rigid.velocity.z < topSpeed && rigid.velocity.z > -topSpeed)
            {
                rigid.AddForce(vec);

                //rigid.velocity = new Vector3(speed, 0.0f, 0.0f);
            }

        }

        if (Input.GetKeyDown("joystick button 0"))
        {
            //transform.position += new Vector3(0.0f, 1.0f, 0.0f);
            Jump();
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
        if (jumpNow)
        {
            jumpNow = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // �n�ʂɂ�����
        if (!jumpNow)
        {
            jumpNow = true;
        }
    }

    // �W�����v����
    void Jump()
    {
        if (jumpNow)
        {
            return;
        }
        rigid.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        jumpNow = true;
    }
}
