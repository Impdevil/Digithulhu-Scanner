using BepInEx;
using LethalLib;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace MyFirstPlugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency(LethalLib.Plugin.ModGUID)]
    public class Plugin : BaseUnityPlugin
    {
        AssetBundle myAssBundle; 
        private void Awake()
        {
            string sAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} potato 1" );
            myAssBundle = AssetBundle.LoadFromFile(Path.Combine(sAssemblyLocation, "DigithulhuAssets"));
            if (myAssBundle == null)
            {
                Logger.LogError("Failed to load custom assets."); // ManualLogSource for your plugin
                return;
            }
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} potato 2");
            //int itemRarity = 100;
            Item Scanner = myAssBundle.LoadAsset<Item>("Scanner Scrap");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} potato 3");
            LethalLib.Modules.NetworkPrefabs.RegisterNetworkPrefab(Scanner.spawnPrefab);
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} potato 4");
            LethalLib.Modules.Items.RegisterShopItem(Scanner,1);
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!" + Scanner.itemName);
        }
    }

}
