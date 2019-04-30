using Amazon.Polly;
using Amazon.Polly.Model;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using static Helpers;

public class GenerateSpeechMenuItem : MonoBehaviour
{
    [MenuItem("Assets/Generate Speech Using AWS Polly")]
    static void GenerateSpeechPolly()
    {
        // init AWS client
        AmazonPollyClient client = new AmazonPollyClient(Amazon.RegionEndpoint.EUWest2);

        // process lines serially
        foreach (string line in GetDialogueLines(@"Assets/Story/Story.html"))
        {
            string hash = DialogueLineToHash(line);
            string speechFilePath = @"Assets/Resources/Speech/" + hash + @".ogg";

            if (File.Exists(speechFilePath))
            {
                continue;
            }

            var synthesizeSpeechRequest = new SynthesizeSpeechRequest()
            {
                OutputFormat = OutputFormat.Ogg_vorbis,
                VoiceId = VoiceId.Geraint,
                Text = line
            };

            using (var outputStream = new FileStream(speechFilePath, FileMode.Create, FileAccess.Write))
            {
                var synthesizeSpeechResponse = client.SynthesizeSpeech(synthesizeSpeechRequest);
                byte[] buffer = new byte[2 * 1024];
                int readBytes;

                var inputStream = synthesizeSpeechResponse.AudioStream;
                while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                {
                    outputStream.Write(buffer, 0, readBytes);
                }
            }

            Debug.Log("saved " + hash + " " + line);
        }
    }

    private static List<string> GetDialogueLines(string filePath)
    {
        var lines = new List<string>();

        // parse html
        HtmlDocument storyHtml = new HtmlDocument();
        storyHtml.Load(filePath);

        // process each passage
        foreach (HtmlNode passage in storyHtml.DocumentNode.SelectNodes("//tw-passagedata"))
        {
            foreach (string line in HtmlEntity.DeEntitize(passage.InnerText).Split('\n'))
            {
                if (line.StartsWith("[[") || line.StartsWith("(") || line.Length == 0)
                {
                    continue;
                }

                lines.Add(line);
            }
        }

        // done
        return lines;
    }
}
