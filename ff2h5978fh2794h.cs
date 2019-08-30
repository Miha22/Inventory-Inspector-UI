using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;

namespace ItemRestrictorAdvanced
{
    public class ff2h5978fh2794h : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "incloud";
        public string Help => "Shows your virtual inventory using UI";
        public string Syntax => "/incloud or /inc";
        public List<string> Aliases => new List<string>() { "inc" };
        public List<string> Permissions => new List<string>() { "rocket.incloud", "rocket.inc"};

        public void Execute(IRocketPlayer gu1hb34puh8g934h1gd, string[] command)
        {
            UnturnedPlayer gu1h34puh8g934asdh1gd = (UnturnedPlayer)gu1hb34puh8g934h1gd;
            if (!System.IO.Directory.Exists(Plugin.Instance.pathTemp + $"\\{gu1h34puh8g934asdh1gd.CSteamID}"))
                System.IO.Directory.CreateDirectory(Plugin.Instance.pathTemp + $"\\{gu1h34puh8g934asdh1gd.CSteamID}");
            Block gu1h34puhn8g934h1gd = fiuiuasfifasfsa.gu1h3a4pu34h1gdan(Plugin.Instance.pathTemp + $"\\{gu1h34puh8g934asdh1gd.CSteamID}\\Heap.dat", 0);
            if (gu1h34puhn8g934h1gd.block.Length == 0)
            {
                Rocket.Unturned.Chat.UnturnedChat.Say(gu1hb34puh8g934h1gd, "You do not have items in cloud inventory!");
                return;
            }
            (List<List<MyItem>> gu1h34puhasds8g934h1gd, byte gu1h34puhasd8g934h1gd) = fiuiuasfifasfsa.gu1h34puh8g934h1gd(gu1h34puhn8g934h1gd);
            EffectManager.sendUIEffect(8101, 26, gu1h34puh8g934asdh1gd.CSteamID, false);
            for (byte i = 0; i < gu1h34puhasds8g934h1gd[0].Count; i++)
                EffectManager.sendUIEffectText(26, gu1h34puh8g934asdh1gd.CSteamID, false, $"item{i}", $"{((ItemAsset)Assets.find(EAssetType.ITEM, gu1h34puhasds8g934h1gd[0][i].ID)).itemName}\r\nID: {gu1h34puhasds8g934h1gd[0][i].ID}\r\nCount: {gu1h34puhasds8g934h1gd[0][i].Count}");
            for (byte i = (byte)gu1h34puhasds8g934h1gd[0].Count; i < 24; i++)
                EffectManager.sendUIEffectText(26, gu1h34puh8g934asdh1gd.CSteamID, false, $"item{i}", $"");
            EffectManager.sendUIEffectText(26, gu1h34puh8g934asdh1gd.CSteamID, false, "playerName", $"Cloud: {gu1h34puh8g934asdh1gd.CharacterName}");
            EffectManager.sendUIEffectText(26, gu1h34puh8g934asdh1gd.CSteamID, false, "page", $"{1}");
            EffectManager.sendUIEffectText(26, gu1h34puh8g934asdh1gd.CSteamID, false, "pagemax", $"{gu1h34puhasd8g934h1gd}");
            EffectManager.sendUIEffectText(26, gu1h34puh8g934asdh1gd.CSteamID, false, "playerName", $"Cloud: {gu1h34puh8g934asdh1gd.Player.channel.owner.playerID.characterName}");
            EffectManager.onEffectButtonClicked += new furhfuh4uhf(gu1h34puhasds8g934h1gd, gu1h34puhasd8g934h1gd).OnEffectButtonClick8101;
            gu1h34puh8g934asdh1gd.Player.serversideSetPluginModal(true);  
        }
    }
}
//Effect ID is the id parameter, key is an optional instance identifier for modifying instances of an effect, 
//and child name is the unity name of a GameObject with a Text component.