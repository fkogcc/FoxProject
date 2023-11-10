// プレイヤーのHPをUIに反映.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHpUi : MonoBehaviour
{
    private TextMeshProUGUI _textHp;
    private Player2DMove _player;

    // Start is called before the first frame update
    void Start()
    {
        _textHp = GetComponent<TextMeshProUGUI>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player2DMove>();
    }

    // Update is called once per frame
    void Update()
    {
        _textHp.SetText("X{0}", _player.GetHp());
    }
}
