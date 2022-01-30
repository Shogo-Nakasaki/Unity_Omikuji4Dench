using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Text : MonoBehaviour
{
    // Main＝大吉とか書くところ
    // Sub ＝内容を書くところ
    public Text Text_main;
    public Text Text_sub;

    public bool playing = false;
    public float textSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // 関数：クリックで次のページを表示させる
    public bool IsClicked()
    {
        if (Input.GetMouseButtonDown(0)) return true;
        return false;
    }

    // 関数：おみくじの内容を記載させる
    public void DrawText(string main, string sub)
    {
        Text_main.text = main;
        StartCoroutine("CoDrawText", sub);
    }

    // テキストがヌルヌル出てくるためのコルーチン
    IEnumerator CoDrawText(string text)
    {
        playing = true;
        float time = 0;
        while (true)
        {
            yield return 0;
            time += Time.deltaTime;
            
            if (IsClicked()) break; // クリックされると一気に表示

            int len = Mathf.FloorToInt(time / textSpeed);
            if (len > text.Length) break;
            Text_sub.text = text.Substring(0, len);
        }
        Text_sub.text = text;
        yield return 0;
        playing = false;
    }
}
