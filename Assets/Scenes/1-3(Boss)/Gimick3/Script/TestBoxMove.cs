using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoxMove : MonoBehaviour
{
	// Rigidbody�̎擾.
	Rigidbody _rb;
	// �v���C���[�̉�����.
	public float _pushPower = 2.0f;
	// �����Ă������.
	Vector3 _pushDir;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void FixedUpdate()
    {
        
    }

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		_rb = hit.collider.attachedRigidbody;
		// ����̃I�u�W�F�N�g��Rigidbody�����Ă��Ȃ�������AisKinematic�Ƀ`�F�b�N�������Ă���ꍇ�ɂ͉����Ȃ�.
		if (_rb == null || _rb.isKinematic)
		{
			return;
		}

		if (hit.moveDirection.y < -0.3f)
		{
			return;
		}
		// �����Ă���������擾����
		_pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		// �����Ă�������ɉ����Ă���͂��|���Ĉړ�������
		_rb.velocity = _pushDir * _pushPower;
	}
}
