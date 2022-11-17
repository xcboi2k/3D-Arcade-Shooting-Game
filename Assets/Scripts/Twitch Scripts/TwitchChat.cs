using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class TwitchChat : MonoBehaviour
{
    [SerializeField]
    CommandReader commandReader;

    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;

    // Your username
    public string username;
    // Generate oauth at https://twitchapps.com/tmi/
    public string password;
    // Channel you want to join to
    public string channelName;

    private string lastLine;

    public Text chatText;

    private void Awake()
    {
        ConnectToTwitch();       
    }

    float test = 0f;

    private void Update()
    {
        test = Time.deltaTime;
    }

    private void Reconnect()
    {
        if (!twitchClient.Connected)
        {
            Debug.Log("Reconnecting");
            ConnectToTwitch();
        }
    }

    private async void ConnectToTwitch()
    {
        twitchClient = new TcpClient();

        await twitchClient.ConnectAsync("irc.chat.twitch.tv", 6667);

        reader = new StreamReader(twitchClient.GetStream());
        writer = new StreamWriter(twitchClient.GetStream()) { NewLine = "\r\n", AutoFlush = true };

        await writer.WriteLineAsync("PASS " + password);
        await writer.WriteLineAsync("NICK " + username);
        await writer.WriteLineAsync("JOIN #" + channelName);

        ReadMessage();
    }   

    private async void ReadMessage()
    {
        while(Application.isPlaying)
        {
            Reconnect();
            lastLine = await reader.ReadLineAsync();

            if(lastLine != null)
            {
                lastLine = Regex.Replace(lastLine, "@s", " ");
                if(lastLine != null && lastLine.StartsWith("PING"))
                {
                    Debug.Log("PING");
                    lastLine.Replace("PING", "PONG");
                    await writer.WriteAsync(lastLine);
                }
                if (lastLine.Contains("PRIVMSG"))
                {
                    var splitPoint = lastLine.IndexOf("!", 1);
                    var chatName = lastLine.Substring(0, splitPoint);
                    chatName = chatName.Substring(1);

                    splitPoint = lastLine.IndexOf(":", 1);
                    //string user = lastLine.Substring(splitPoint);
                    lastLine = lastLine.Substring(splitPoint + 1);
                    //repeat = lastline.Substring(splitPoint + 2);
                    commandReader.ReadInput(lastLine);
                    chatText.text = chatName + ": " + lastLine;
                    Debug.Log(lastLine);
               }
            }
        }
    }
}
