using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static string Host;
    public static string Port;
    public static string Name;

    public static List<Message> MessageList = new();
}

public class Message
{
    public string Content;
    public int Id;
    public GameObject MessageObj;

    public Message(string _content, int _iD, GameObject _messageObj) => (Content, Id, MessageObj) = (_content, _iD, _messageObj);
}