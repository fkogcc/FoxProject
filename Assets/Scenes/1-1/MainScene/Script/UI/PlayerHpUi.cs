// プレイヤーのHPをUIに反映.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHpUi : MonoBehaviour
{
    private TextMeshProUGUI _textHp;

    // Start is called before the first frame update
    void Start()
    {
        _textHp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _textHp.SetText("X{0}", Player2DMove._instance.GetHp());
    }
}
