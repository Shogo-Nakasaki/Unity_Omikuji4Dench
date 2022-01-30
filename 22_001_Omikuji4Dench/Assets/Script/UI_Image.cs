using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Image : MonoBehaviour
{
    // 画像の表示場所
    public Image image;

    // 使用するキャラ
    public Sprite chara_0;
    public Sprite chara_1;
    public Sprite chara_2;
    public Sprite chara_3;
    public Sprite chara_4;
    public Sprite chara_5;
    public Sprite chara_6;
    
    private Sprite sprite;
    
    // 映像を描きだす処理
    public void DrawPic(int chara)
    {
        // キャラクターの選択
        sprite = (chara == 1) ? sprite = chara_1 :
                 (chara == 2) ? sprite = chara_2 :
                 (chara == 3) ? sprite = chara_3 :
                 (chara == 4) ? sprite = chara_4 :
                 (chara == 5) ? sprite = chara_5 :
                 (chara == 6) ? sprite = chara_6 :
                                sprite = chara_0;

        // 画像の挿入場所
        image.sprite = sprite;
    }
}
