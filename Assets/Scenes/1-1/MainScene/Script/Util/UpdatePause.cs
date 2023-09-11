// �|�[�Y��ʂ̏���
using System.Collections;
using System.Collections.Generic;
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
        //if(!_isPause)
        //{
        //    _pauseCanvas.gameObject.SetActive(false);
        //}
        //else
        //{
        //    _pauseCanvas.gameObject.SetActive(true);
        //}

        _pauseCanvas.gameObject.SetActive(_isPause);

        if (!_isPause)
        {
            Time.timeScale = 1;
        }
    }

    private void FixedUpdate()
    {
        if (_isPause)
        {
            Time.timeScale = 0;
        }
    }

}
