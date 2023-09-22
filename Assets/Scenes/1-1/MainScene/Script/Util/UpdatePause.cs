// �|�[�Y��ʂ̏���.
// FIXME:�܂��ǉ��������@�\������̂œr����

using UnityEngine;

public class UpdatePause : MonoBehaviour
{
    // �|�[�Y��ʂ��J�������ǂ���.
    [SerializeField] private bool _isPause = false;
    // �|�[�Y��ʂ̃I�u�W�F�N�g
    [SerializeField] private GameObject _pauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �|�[�Y��ʂ��J���Ă��邩�ǂ���.
        _pauseCanvas.gameObject.SetActive(_isPause);

        // ���Ԃ𓮂���
        if (!_isPause)
        {
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown("joystick button 7"))
        {
            _isPause = !_isPause;
        }
    }

    private void FixedUpdate()
    {
        // ���Ԃ��~�߂�
        if (_isPause)
        {
            Time.timeScale = 0;
        }
    }

}
