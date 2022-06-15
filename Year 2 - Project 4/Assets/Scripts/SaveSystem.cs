using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.InputSystem;
public static class SaveSystem
{

    public static void SavePlayer(PlayerInput playerInput)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerConfiguration playerConfig = new PlayerConfiguration(playerInput);

        formatter.Serialize(stream, playerConfig);
        stream.Close();
    }

    public static PlayerConfiguration LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";

        if (File.Exists(path))
        {

            return null;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
