using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace spirit.Chan
{

    public class GameData
    {
        public KeyCode ViewSwapKey = KeyCode.None;
        public KeyCode SprintKey = KeyCode.None;
        public KeyCode JumpKey = KeyCode.None;

        public bool isFirstView = true;

        public GameData()
        {
            ViewSwapKey = KeyCode.V;
            SprintKey = KeyCode.LeftShift;
            JumpKey = KeyCode.Space;

            isFirstView = true;
        }
    }

    public class DataManger : MonoBehaviour
    {
        public GameData gameData = null;

        private string dataPath = string.Empty;

        private void Awake()
        {
            dataPath = Application.persistentDataPath + "/SpiritofKnight.txt";
            print(dataPath);

            if (File.Exists(dataPath))
                gameData = LoadGameData();
            else
                gameData = new GameData();
        }

        public void SaveGameData()
        {
            File.WriteAllText(dataPath, Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(gameData))));
        }
        public GameData LoadGameData()
        {
            return JsonConvert.DeserializeObject<GameData>(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(File.ReadAllText(dataPath))));
        }

        private void OnApplicationQuit()
        {
            SaveGameData();
        }
        private void OnApplicationFocus(bool focus)
        {
            if (!focus)
                SaveGameData();
        }
        private void OnApplicationPause(bool pause)
        {
            if (pause)
                SaveGameData();
        }

    }

}