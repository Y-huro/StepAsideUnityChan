using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    // carPrefabを入れる
    public GameObject carPrefab;
    // coinPrefabを入れる
    public GameObject coinPrefab;
    // cornPrefabを入れる
    public GameObject conePrefab;

    // スタート地点
    private int startPos = 80;
    // ゴール地点
    private int goalPos = 360;
    // アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // 発展課題（ユニティちゃんの位置に応じてアイテム生成）用宣言
    
    // 次の作成予定位置
    private int generatePos;
    // 作成予定位置越えの判定
    private bool lineOver = false;
    // Unityちゃんから見た作成開始距離
    private int generateDifference = 40;
    // Unityちゃんのオブジェクト
    private GameObject unitychan;


    void Start()
    {
        // 一定の距離ごとにアイテムを生成
        //for (int i = startPos; i < goalPos; i += 15)

        // オブジェクト作成開始位置がユニティちゃんの視野内にある場合
        if (startPos < generateDifference)
        {
            for (generatePos = startPos; generatePos < generateDifference; generatePos += 15)
            {
                itemGenerate(generatePos);

                /*
                // どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if(num <= 2)
                {
                    // コーンをx軸方向に一直線に生成
                    for(float j = -1;j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                    }
                }
                else
                {
                    // レーンごとにアイテムを生成
                    for(int j = -1;j <= 1; j++)
                    {
                        // アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        // アイテムを置くz座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        // 60%コイン配置：30%車配置：10%何もなし
                        if(1 <= item && item <= 6)
                        {
                            // コインを生成
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                        }
                        else if(7 <= item && item <= 9)
                        {
                            // 車を生成
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                        }
                    }
                }*/

            }
        }
        else
        {
            generatePos = startPos;
        }

        // Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!lineOver)
        {
            if (generatePos < goalPos && generatePos <= unitychan.transform.position.z + generateDifference)
            {
                lineOver = true;
            }
        }
        if (lineOver)
        {
            itemGenerate(generatePos);
            generatePos += 15;
            lineOver = false;
        }

    }

    private void itemGenerate(int generatePlace)
    {
        int num = Random.Range(1, 11);
        if (num <= 2)
        {
            // コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, generatePlace);
            }
        }
        else
        {
            // レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {
                // アイテムの種類を決める
                int item = Random.Range(1, 11);
                // アイテムを置くz座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);
                // 60%コイン配置：30%車配置：10%何もなし
                if (1 <= item && item <= 6)
                {
                    // コインを生成
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, generatePlace + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    // 車を生成
                    GameObject car = Instantiate(carPrefab);
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, generatePlace + offsetZ);
                }
            }
        }
    }
}
