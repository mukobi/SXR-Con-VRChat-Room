using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerCounter : UdonSharpBehaviour
{
    [SerializeField] private UnityEngine.UI.Text text; //カウンターのTextを指定
    private int inroom = 0; //人数

    //人が入ってきたとき
    public override void OnPlayerJoined(VRCPlayerApi player){
        inroom++;
        UpdateText();
    }

    //人が出ていったとき
    public override void OnPlayerLeft(VRCPlayerApi player){
        inroom--;
        UpdateText();
    }

    //カウンターの数値を更新
    private void UpdateText(){
        text.text = inroom.ToString();
    }
}
