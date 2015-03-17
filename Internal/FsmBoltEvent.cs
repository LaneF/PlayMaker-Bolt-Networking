using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Bolt;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

public class FsmBoltEvent : FsmStateAction {

    public string[] targetList;
	
	public int selectionId = 0;

	// I am hosting editor values cause I can't find a way to serialize them inside my editor since I am generating that editor gui with a static util class
    //
    // don't need these for this class??
	public bool _minimized;
	public Vector2 _scroll;
	public bool _sourcePreview = true;
    public bool _sourceEdit = true;
	
	public string Value
	{
        get
        {
            return targetList[selectionId];
        }
	}
}