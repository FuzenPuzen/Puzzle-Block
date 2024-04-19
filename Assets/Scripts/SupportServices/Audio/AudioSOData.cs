using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioSOData", menuName = "ScriptableObjects/AudioSOData", order = 1)]
public class AudioSOData : SerializedScriptableObject
{
    [DictionaryDrawerSettings(KeyLabel = "AudioEnum", ValueLabel = "AudioClip")]
    public Dictionary<AudioEnum, AudioClip> audioDictionary = new Dictionary<AudioEnum, AudioClip>();


    /*[Button]
    // ����� ��� ���������� ������� ������
    public void FillAudioDictionary()
    {
        // �������� ������� ����� �����������
        audioDictionary.Clear();

        // ��������� ��� ���������� �� ����� Resources/Audio
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("Audio");

        // ��������� ��� ���������� � �������� �� � �������
        foreach (AudioClip clip in audioClips)
        {
            // �������� ��� ����� ��� ����������
            string fileName = Path.GetFileNameWithoutExtension(clip.name);

            // ������������� ��� ����� � AudioEnum
            AudioEnum audioEnum;
            if (Enum.TryParse(fileName, out audioEnum))
            {
                // �������� ���� � �������
                audioDictionary.Add(audioEnum, clip);
            }
            else
            {
                Debug.LogWarning("Failed to parse audio file: " + fileName);
            }
        }
    }

    [Button]
    private void UpdateAudioEnum()
    {

        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("Audio");
        // ��������� ����� ������ ��� ����������
        List<string> audioNames = new List<string>();
        foreach (AudioClip clip in audioClips)
        {
            string fileName = Path.GetFileNameWithoutExtension(clip.name);
            audioNames.Add(fileName);
        }

        // ��������� ������� enum
        string enumPath = FindEnumFile("AudioEnum");
        string[] existingEnumLines = File.Exists(enumPath) ? File.ReadAllLines(enumPath) : new string[0];

        // ������� ������� ��� �������� ������ ��������� enum
        Dictionary<string, bool> existingEnumElements = new Dictionary<string, bool>();
        foreach (string line in existingEnumLines)
        {
            if (line.Contains("public enum AudioEnum"))
                continue;

            string elementName = line.Trim().TrimEnd(',');
            existingEnumElements[elementName] = true;
        }

        // ���������� ��� enum
        string enumCode = "public enum AudioEnum\n{\n";
        foreach (string audioName in audioNames)
        {
            enumCode += $"\t{audioName},\n";
        }
        enumCode += "}\n";

        // ���������� ��� enum � ����
        File.WriteAllText(enumPath, enumCode);

        // ��������� ��������, ����� ������� ����� ���� � �������
       
        AssetDatabase.Refresh();
    }

    private string FindEnumFile(string enumName)
    {
        string[] files = Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories);

        foreach (string filePath in files)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    if (line.Contains("enum " + enumName))
                    {
                        return filePath;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error reading file: " + e.Message);
            }
        }

        return null;
    }*/
}