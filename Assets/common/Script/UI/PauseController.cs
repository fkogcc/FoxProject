// ポーズ画面を開く閉じる操作.
// 何もなかったのでとりあえずここで、BGMを流す処理しています。
// HACK:ポーズ画面を雑に作ったのでコーディング規約だけ見てほしい.

using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    private SoundManager _sound;
    [SerializeField] private string bgmName;

    void Start()
    {
        _sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _sound.PlayBGM(bgmName);
    }
}
