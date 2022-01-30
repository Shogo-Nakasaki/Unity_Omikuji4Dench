using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonMain : ButtonBase
{
    // おみくじの画像を格納
    [SerializeField] GameObject omikuji_kekka;
    [SerializeField] GameObject text_button;

    protected override void Update(){}
    protected override void OnClick(string objectName)
    {
        // 説明：渡されたオブジェクト名で処理を分岐している
        if ("Start".Equals(objectName))
        {
            // Debug.Log("動作チェック：ボタンを押された");
            text_button.SetActive(false);
            StartCoroutine(GameMain());
        }

        if ("ReStart".Equals(objectName))
        {
            // 引き直しの時の処理
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            // throw new System.Exception("Not implemented");
        }
    }

    IEnumerator GameMain()
    {
        yield return new WaitForSeconds(1);
        omikuji_kekka.SetActive(true);
    }
}
