using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHP : MonoBehaviour
{
    public RectTransform icon;
    float scale;
    public float tic;
    void Start()
    {
        scale = icon.sizeDelta.x;
    }
    void Update()
    {
        icon.sizeDelta = new Vector2( scale * playerdata.hp, icon.sizeDelta.y);
        tic += Time.deltaTime;
        if (playerdata.hp <= 2&& tic >= 3)
        {


            playerdata.hp += 1;
            tic = 0;
        }
    }
}
