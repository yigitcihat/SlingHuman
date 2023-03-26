using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelList
{
    public static string GameStartPanel = "GameStartPanel";
    public static string InGamePanel = "InGamePanel";
    public static string WinPanel = "WinPanel";
    public static string FailPanel = "FailPanel";

    public static Dictionary<string, Panel> Panels = new Dictionary<string, Panel>();

    private static string[] panelIDs = new string[]
    {
            "None",
            GameStartPanel,
            InGamePanel,
            WinPanel,
            FailPanel,
    };
    public static List<string> PanelIDs { get { return panelIDs.ToList(); } }
}
