// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGimmick : MonoBehaviour
{
    // シングルトン
    public static FireGimmick _instance;

    // パーティクルオブジェクト
    [SerializeField] private ParticleSystem _particleSystem;

    // デバッグ用ゲームオブジェクト(Enemy)
    [SerializeField] private GameObject _debugEnemyObject;

    // 炎が燃え続ける最大時間
    [SerializeField] private float _burningMaxCount;

    // 炎が燃え続けている時間
    private float _burningCount = 0;

    private void Awake()
    {
        // シングルトンの呪文
        if( _instance == null )
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem.Pause();
    }

    /// <summary>
    /// 炎更新処理
    /// </summary>
    /// <param name="solve">ギミックを解いたかどうか</param>
    public void UpdateFire(bool solve)
    {
        if (!solve) return;
        // パーティクル再生
        _particleSystem.Play();

        // 燃え続けている時間を足し続ける
        if( _burningCount < _burningMaxCount )
        {
            _burningCount++;
        }

        // 燃え続けている時間が最大値と同じになればパーティクル終了
        if(_burningCount == _burningMaxCount)
        {
            _particleSystem.Stop();
        }

        // デバッグ用Enemy消去
        if(_burningCount == _burningMaxCount / 2)
        _debugEnemyObject.SetActive(false);
    }


}
