using UdonSharp;
using UnityEngine;

namespace FairlySadPanda
{
    namespace Utilities
    {
        public class Logger : UdonSharpBehaviour
        {
            public TMPro.TextMeshProUGUI text;
            public int maxChars;

            public void Start()
            {
                Log("TestLogger", "Start");
            }

            public void Log(string source, string log)
            {
                Debug.Log($"[{Time.timeSinceLevelLoad:N2}] [<color=green>{source}</color>] {log}");
                text.text += $"\n[{Time.timeSinceLevelLoad:N2}] [<color=green>{source}</color>] {log}";
                while (text.text.Length > maxChars && text.text.Contains("\n"))
                {
                    text.text = text.text.Substring(text.text.IndexOf("\n") + 1);
                }
            }

            public void Error(string source, string log)
            {
                Debug.LogError($"[{Time.timeSinceLevelLoad:N2}] [<color=red>{source}</color>] {log}");
                text.text += $"\n[{Time.timeSinceLevelLoad:N2}] [<color=red>{source}</color>] {log}";
                while (text.text.Length > maxChars && text.text.Contains("\n"))
                {
                    text.text = text.text.Substring(text.text.IndexOf("\n") + 1);
                }
            }

            public void Clear()
            {
                text.text = string.Empty;
            }
        }
    }
}