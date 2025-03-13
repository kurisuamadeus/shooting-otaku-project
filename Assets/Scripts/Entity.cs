using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Entity
{
    public string Entity名;
    public float HP;
    public float 速度;
    public int スコア;
    // public enum Entityタイプ
    // {
    //     一般人,
    //     敵
    // }

    // public enum Movement{
    //     右から左え,
    //     左から右え,
    //     動けない
    // }
    public Movement 動き;

    public Entityタイプ タイプ;
    public Sprite sprite;
}
