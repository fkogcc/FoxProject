using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    // ��̈ړ����x.
    private float speed;
    // �{�^���̖��O������p�̕ϐ�.
    public string _buttonName;
    // �{�^���̏�Ԃ�����t���O.
    public bool _isButtonState;
    // �v���C���[�̎肪������ɂ��邩�ǂ�����Ԃ��t���O.
    private bool _isCollision;

    // Start is called before the first frame update
    void Start()
    {
        // ����������.
        speed = 5.0f;
        _isButtonState = false;
        _isCollision = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�̎肪������ɂ��āA�{�^���������ꂽ��.
        if (_isCollision && Input.GetKeyDown("joystick button 1"))
        {
            // �{�^���������ꂽ�t���O��Ԃ�.
            _isButtonState = true;
        }
        // �����ɓ��Ă͂܂�Ȃ�������.
        else
        {
            // �{�^���̃t���O��false�ŕԂ�.
            _isButtonState = false ;
        }
    }
    void FixedUpdate()
    {
        // HACK �Ƃ肠������𓮂����p�̏���(��ł����Ƃ������@�ɏ�������������).
        if (Input.GetAxis("Vertical") > 0)
        {
            // ��.
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            // ��.
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            // �E.
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            // ��.
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // �v���C���[���R���C�_�[�ɓ������Ƃ�.
        if (other.tag == "Button")
        {
            // ������ɂ���Ƃ����t���O��Ԃ�.
            _isCollision = true;
            // ���G��Ă���{�^�����擾����
            _buttonName = other.gameObject.name;

        }
    }

    void OnTriggerExit(Collider other)
    {
        // �v���C���[���R���C�_�[����o���Ƃ�.
        if (other.tag == "Button")
        {
            // ����O�ɂ���Ƃ����t���O��Ԃ�.
            _isCollision = false;
        }
    }
}
