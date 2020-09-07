using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HellGame;

public class ResultSceneController : MonoBehaviour
{
    [SerializeField]
    Text resultText;

    // Start is called before the first frame update
    void Start()
    {
        var gc = GameController.Instance;

        resultText.text = $"スーパーチャット　¥{gc.SuperChatTotal:#,0}\n"
                         + $"欲しいものリスト　¥{gc.WishlistTotal:#,0}\n"
                         + $"<size=40>計　¥{(gc.WishlistTotal + gc.SuperChatTotal):#,0}</size>\n"
                         + "ご支援ありがとうにゃ！";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
