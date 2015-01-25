using UnityEngine;
using System.Collections;
using System;

public class AssetMgr
{
    //note:the class is add const path
    //==========player=============
    public const string FlowerMonster_Blue = "PlayerPrefabs/FlowerMonster-Blue";
    public const string FlowerMonster_Brown = "PlayerPrefabs/FlowerMonster-Brown";
    public const string FlowerMonster_Purple = "PlayerPrefabs/FlowerMonster-Purple";
    public const string FlowerMonster_Red = "PlayerPrefabs/FlowerMonster-Red";
    public const string MagmaDemon_Blue = "PlayerPrefabs/MagmaDemon-Blue";
    public const string MagmaDemon_Green = "PlayerPrefabs/MagmaDemon-Green";
    public const string MagmaDemon_Purple = "PlayerPrefabs/MagmaDemon-Purple";
    public const string MagmaDemon_Orange = "PlayerPrefabs/MagmaDemon-Orange";

    //============UI Prefab Path==================
    public const string AnimationStatePath = "PlayerPrefabs/BtnAnimationState";



    //===========Event===================
    public static event Func<int, GameObject, bool> OpenAnimationStateHandler;
    public static bool OpenAnimationState(int id, GameObject target)
    {
        if (OpenAnimationStateHandler != null)
        {
            return OpenAnimationStateHandler(id, target);
        }
        return false;
    }
}
