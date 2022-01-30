using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBase : MonoBehaviour
{
    public ButtonBase button;
    protected virtual void Update(){}
    public void OnClick()
    {
        // 警告：ボタンが無かったとき
        if(button == null)
        {
            throw new System.Exception("Button instance is null");
        }
        // 自身のオブジェクト名を渡す
        button.OnClick(this.gameObject.name);
    }

    protected virtual void OnClick(string objectName)
    {
        // 呼ばれることのないログ
        Debug.Log("Base Button");
    }
}
