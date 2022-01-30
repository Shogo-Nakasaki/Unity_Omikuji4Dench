/** --------------------------------------------------
 * @file    UI_Writer.cs
 * @brief   画像や文章などの出力処理を記載
 * @author  ShogoN
 * @date    2022.1.2
 * 
 -------------------------------------------------- */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

/** -----------------------------------------------------------
* @class   UI_Writter
* @brief   おみくじの内容を作成・出力
* 
------------------------------------------------------------- */
public class UI_Writer : MonoBehaviour
{
    // 画像やテキストの表示場所
    public UI_Text uitext;
    public UI_Image uiimage;

    // CSVファイル関連
    TextAsset csvFile;
    public int height;
    List<string[]> csvDatas = new List<string[]>();

    //! 使用するキャラクターを格納
    public int check_chara = 0;
    //! おみくじの結果を格納「大吉！」
    public int check_main = 0;
    //! おみくじの結果を格納「学業：blahblahblah」
    public int check_sub = 0;
    //! テキストデータの格納
    public string text_main;
    public string text_sub;
    //! 再度おみくじを回すための変数
    public bool check_restart = false;

    /** --------------------------------------------------
     * @fn      Start
     * @brief   csvにあるおみくじの結果データを読み込む
     * 
     -------------------------------------------------- */
    private void Start()
    {
        csvFile = Resources.Load("Omikuji") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        // 「,」で分割しつつ、1行ずつ読み込み
        // 1行ずつリストに追加していく
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
            height++;
        }
        // 文章を表記させるコルーチンのスタート
        StartCoroutine("MainWritter");
    }

    /** --------------------------------------------------
     * @fn      Checker
     * @brief   乱数を生成し、結果を格納する
     * 
     -------------------------------------------------- */
    private void Checker()
    {
        //! キャラクターの決定
        check_chara = Random.Range(0, 6);
        check_main = Random.Range(1, 6);
        check_sub = Random.Range(1, 4);
        Write();
        check_restart = true;
    }

    /** --------------------------------------------------
     * @fn      Write
     * @brief   おみくじの結果を出力する
     * @detail  mainでおみくじの結果を、subでおみくじの詳細を出力する
     * 
     -------------------------------------------------- */
    private void Write()
    {
        text_main = csvDatas[0][check_main];
        text_sub = csvDatas[check_sub][0]+"\n"+csvDatas[check_sub][check_main];
    }

    /** --------------------------------------------------
     * @enum    Skip
     * @brief   スキップするコルーチン
     * 
     -------------------------------------------------- */
    IEnumerator Skip()
    {
        while (uitext.playing) yield return 0;
        while (!uitext.IsClicked()) yield return 0;
    }

    /** --------------------------------------------------
     * @enum    MainWritter
     * @brief   出力内容を記述していくコルーチン
     * 
     -------------------------------------------------- */
    public IEnumerator MainWritter()
    {
        Checker();
        uitext.DrawText(text_main,text_sub);
        uiimage.DrawPic(check_chara);
        yield return StartCoroutine("Skip");
    }
}
