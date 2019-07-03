using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerProgress;

public class Starter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BinarySaver characterDataSaver = new BinarySaver();
        CharacterDataFormat data = new CharacterDataFormat(3, 2, 1);
        characterDataSaver.AddDataToWritingStream(data);
        characterDataSaver.SaveDataToFiles(Application.persistentDataPath + "Adventure_Character_Data.sav");
	}
}
