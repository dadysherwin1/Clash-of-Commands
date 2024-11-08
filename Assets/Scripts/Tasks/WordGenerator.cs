using System;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class WordGenerator
{
    List<string> folderNames = new List<string>
    {
        "Docs", "Work", "Home", "Pics", "Temp", "Misc", "Code", "Data", "Test", "Todo",
        "Logs", "Back", "Arch", "Olds", "Mail", "Plan", "Site", "Info", "List", "Save",
        "Proj", "Code", "Move", "Jobs", "Bank", "News", "Scan", "Sync", "Note", "Book",
        "Idea", "Time", "Keep", "Read", "Team", "Copy", "Link", "Meet", "Tech", "User",
        "Life", "Trip", "Taxe", "Task", "Sent", "Edit", "Docs", "Play", "Help", "Arch",
        "Call", "Club", "Plan", "Grab", "Blog", "Drop", "Pubs", "Mode", "Form", "Demo",
        "Core", "Acts", "Walk", "Show", "Shop", "Main", "Cash", "Lead", "Misc", "Tour",
        "Camp", "Game", "Appx", "Quiz", "Food", "Task", "Stat", "Fund", "Port", "Chat",
        "Food", "Task", "Sync", "Tips", "Code", "Hold", "Fun1", "Work", "Logs", "Live",
        "Meet", "Stat", "Chat", "Edit", "Mock", "Plan", "Temp", "Link", "Data", "Part"
    };

    List<string> fileNames = new List<string>
    {
        "aqua", "axis", "bake", "bark", "base", "beam", "beep", "bent", "bold", "boot",
        "buzz", "card", "chip", "club", "core", "cram", "dash", "demo", "dial", "disk",
        "echo", "edit", "fair", "feat", "file", "flip", "flow", "font", "fork", "fuse",
        "gale", "gear", "glow", "grip", "hail", "heal", "hike", "hint", "icon", "inch",
        "jazz", "jolt", "jump", "kind", "knob", "lace", "lake", "lamp", "leap", "line",
        "link", "list", "loop", "mash", "mint", "mode", "name", "note", "null", "open",
        "page", "palm", "part", "peak", "ping", "port", "pull", "push", "ramp", "rate",
        "save", "scan", "seed", "send", "ship", "shot", "snap", "spin", "stem", "step",
        "swap", "sync", "tape", "task", "team", "test", "time", "tone", "tool", "type",
        "unit", "user", "wave", "view", "vine", "word", "wing", "work", "zone"
    };

    List<string> fileExtensions = new List<string>
    {
        ".txt", ".pdf", ".docx", ".xlsx", ".pptx", ".jpg", ".png", ".gif", ".bmp", ".svg",
        ".mp3", ".wav", ".flac", ".aac", ".ogg", ".mp4", ".mov", ".avi", ".mkv", ".wmv",
        ".html", ".css", ".js", ".json", ".xml", ".csv", ".sql", ".php", ".asp",
        ".c", ".cpp", ".cs", ".java", ".py", ".rb", ".go", ".swift", ".kt", ".sh",
        ".bat", ".exe", ".dll", ".iso", ".zip", ".rar", ".tar", ".gz", ".dmg",
        ".apk", ".bin", ".jar", ".war", ".class", ".log", ".bak",
        ".ini", ".cfg", ".conf", ".md", ".ai", ".psd",
        ".fla", ".blend", ".3ds", ".obj", ".fbx", ".stl", ".dwg", ".dxf", ".step",
        ".ifo", ".bup", ".m4a", ".m4v", ".ts", ".flv", ".swf",
        ".ics", ".vcs", ".msg",
    };


    public string GetRandomFolderName()
    {
        int index = UnityEngine.Random.Range(0, folderNames.Count);
        return folderNames[index];
    }

    public string GetRandomFileName()
    {
        int index = UnityEngine.Random.Range(0, fileNames.Count);
        return fileNames[index];
    }
    public string GetRandomFileExtension()
    {
        int index = UnityEngine.Random.Range(0, fileExtensions.Count);
        return fileExtensions[index];
    }

}
