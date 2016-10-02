using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFF_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    // MASTER VOLUMER GETTER/SETTER
    public static float GetMasterVolume () {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetMasterVolume (float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Master Volume out of range");
        }
    }

    // UNLOCKED LEVEL GETTER/SETTER
    public static bool IsLevelUnlocked (int level) {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            return isLevelUnlocked;
        } else {
            Debug.LogError("Trying to unlock level not in build order");
            return false;
        }
    }

    public static void UnlockLevel (int level) {
        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // use one for true
        } else {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    // DIFFICULTY GETTER/SETTER
    public static float GetDifficulty () {
        return PlayerPrefs.GetFloat(DIFF_KEY);
    }

    public static void SetDifficulty (float difficulty) {
        if (difficulty >= 0f && difficulty <= 1f) {
            PlayerPrefs.SetFloat(DIFF_KEY, difficulty);
        } else {
            Debug.LogError("Difficulty setting out of range");
        }
    }
}
