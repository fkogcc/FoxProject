/*敵を燃やす処理*/

using UnityEngine;

public class FireGimmick : MonoBehaviour
{
    private SolveGimmickManager _gimmickManager;

    // パーティクルオブジェクト
    [SerializeField] private ParticleSystem _particleSystem;

    // デバッグ用ゲームオブジェクト(Enemy)
    [SerializeField] private GameObject _debugEnemyObject;

    // 炎が燃え続ける最大時間
    [SerializeField] private float _burningMaxCount;

    // サウンドマネージャー.
    private SoundManager _soundManager;

    // 炎が燃え続けている時間
    private float _burningCount = 0;

    void Start()
    {
        _gimmickManager = GameObject.FindWithTag("GimmickManager").GetComponent<SolveGimmickManager>();
        _particleSystem.Pause();
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void FixedUpdate()
    {
        if (_gimmickManager._solve[3])
        {
            UpdateFire();
        }
    }

    /// <summary>
    /// 炎更新処理
    /// </summary>
    /// <param name="solve">ギミックを解いたかどうか</param>
    private void UpdateFire()
    {
        // パーティクル再生.
        _particleSystem.Play();

        if(_burningCount == 1)
        {
            _soundManager.PlaySE("1_2_0_Fire");
        }

        _debugEnemyObject.transform.position += new Vector3(0.0f, 0.12f, 0.0f);

        if( _burningCount < _burningMaxCount )
        {
            _burningCount++;
        }

        // 燃え続けている時間が最大値と同じになればパーティクル終了.
        if(_burningCount >= _burningMaxCount)
        {
            _particleSystem.Stop();
            _gimmickManager._solve[3] = false;
        }

        // デバッグ用Enemy消去
        if(_burningCount == _burningMaxCount / 2)
        _debugEnemyObject.SetActive(false);
    }


}
