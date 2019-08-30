using System;
using System.Collections.Generic;
using SDG.Unturned;
using Rocket.Unturned.Player;
using Logger = Rocket.Core.Logging.Logger;
using System.IO;
using Rocket.Unturned.Chat;
using System.Linq;
using Rocket.API;

namespace ItemRestrictorAdvanced
{
    class fuirhfgui2h5
    {
        internal static List<fuirhfgui2h5> gu1h3a4pu34gdan;
        internal static List<Player> gu1h3a4pu3asd4gdan;
        internal static byte gu1h3a4pu34gdanasd { get; set; }
        //private static CancellationTokenSource cts;
        //private static CancellationToken token;
        internal byte gu1h3a4pu34asgdan { get; set; }
        private byte gu1h3a4pu34gdansa;
        private IRocketPlayer gu1h3a4pu34g3dan;
        private byte gu1h316153a4pu34gdan;
        private byte gu1h3a4pasdu34gdan;
        private Player gu1h3a123gwef4pu34gdan;
        private string gu1h3a4pasdghu34gdan;
        private string gu1h3a4pu3141244gdan;
        private readonly Player gu1hasd33a4pu34gdan;
        private List<List<MyItem>> gu1h3a4puasda134gdan;
        private ushort gu1h3aasd14pu34gdan;
        private string gu1h3a4pu34gdfjghn4an;
        private string gu1h3a4pu348917gdan;
        private fhui35hof893h9 gu11231h3a4pu34gdan;

        static fuirhfgui2h5()
        {
            gu1h3a4pu34gdan = new List<fuirhfgui2h5>();
            gu1h3a4pu3asd4gdan = new List<Player>();
            //cts = new CancellationTokenSource();
            //token = cts.Token;
        }

        public fuirhfgui2h5(byte gu1h3a4apu34gdfcjghn4an, Player gua1h3a4pu34gdcfjghn4an, Rocket.API.IRocketPlayer cgu1h3a4pu34gdfjghn4anasllerP)
        {
            gu1h3a4pasdu34gdan = 1;
            gu1hasd33a4pu34gdan = gua1h3a4pu34gdcfjghn4an;
            fuirhfgui2h5.gu1h3a4pu34gdanasd = gu1h3a4apu34gdfcjghn4an;// !
            gu1h3a4puasda134gdan = new List<List<MyItem>>();
            gu1h3a4pu34gdan.Add(this);
            gu11231h3a4pu34gdan = fhui35hof893h9.None;
            gu1h3aasd14pu34gdan = 0;
            this.gu1h3a4pu34g3dan = cgu1h3a4pu34gdfjghn4anasllerP;
        }

        internal static void gu1h3a4pu34gadfjghn4an()
        {
            //cts.Cancel();
            if (fuirhfgui2h5.gu1h3a4pu34gdan != null)
            {
                foreach (fuirhfgui2h5 manageUI in fuirhfgui2h5.gu1h3a4pu34gdan)
                    manageUI.UnLoadEvents();
            }
            
            foreach (Player caller in gu1h3a4pu3asd4gdan)
            {
                EffectManager.askEffectClearByID(8100, caller.channel.owner.playerID.steamID);
                EffectManager.askEffectClearByID(8101, caller.channel.owner.playerID.steamID);
                EffectManager.askEffectClearByID(8102, caller.channel.owner.playerID.steamID);
                EffectManager.askEffectClearByID(8103, caller.channel.owner.playerID.steamID);
                caller.serversideSetPluginModal(false);
            }
        }

        private void UnLoadEvents()
        {
            EffectManager.onEffectButtonClicked -= this.gu1h3ca4pu34cdfjghnc4an;
            EffectManager.onEffectButtonClicked -= this.gu1ch3a4puc34gdfjghnc4an;
            EffectManager.onEffectButtonClicked -= this.gu1ah3a4pu34cgdfjghna4an;
            EffectManager.onEffectButtonClicked -= this.gu1hb3a4puc34gdfjgahn4an;
            EffectManager.onEffectTextCommitted -= this.gu1hc3a4pu34gdafjghnc4an;
            EffectManager.onEffectTextCommitted -= this.gu1hc3a4pu3a4gdfjgchn4an;
        }

        private void gu1h3a4pua34gdfcjghn4an(byte page, ulong mSteamID)
        {
            for (byte i = 0; i < Refresh.Refreshes.Length; i++)
            {
                if (Refresh.Refreshes[i].CallerSteamID.m_SteamID == mSteamID)
                {
                    Refresh.Refreshes[i].CurrentPage = page;
                    return;
                }
            }
        }

        private void gu1h3ca4pu34cgdfjghc4an(byte CurrentPage, Steamworks.CSteamID CallerSteamID)
        {
            byte multiplier = (byte)((CurrentPage - 1) * 24);
            for (byte i = multiplier; (i < (24 + multiplier)) && (i < (byte)Provider.clients.Count); i++)
                EffectManager.sendUIEffectText(22, CallerSteamID, false, $"text{i}", $"{Provider.clients[i].playerID.characterName}");
        }

        public void gu1h3ca4pu34cdfjghnc4an(Player gu1h3a4pu34ggi5dan, string gu1h3a4pu34123gdan)
        {
            //System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"text[0-9]", System.Text.RegularExpressions.RegexOptions.Compiled);
            
            if(gu1h3a4pu34123gdan.Substring(0, 4) == "text")
            {
                byte.TryParse(gu1h3a4pu34123gdan.Substring(4), out gu1h3a4pu34gdansa);
                gu1h3a4pu34123gdan = "text";
            }
            switch (gu1h3a4pu34123gdan)
            {
                case "text":
                    if (Provider.clients.Count < ((gu1h3a4pu34gdansa + 1) * gu1h3a4pu34gdanasd))
                        return;
                    gu1h3a4pu34gdansa = (byte)((gu1h3a4pasdu34gdan - 1) * 24);
                    gu1h3a4pasdu34gdan = 1;
                    try
                    {
                        gu1h3a123gwef4pu34gdan = Provider.clients[gu1h3a4pu34gdansa].player;
                        gu1h3a4pu3141244gdan = gu1h3a123gwef4pu34gdan.channel.owner.playerID.steamID.ToString();
                        gu1h3a4pasdghu34gdan = gu1h3a123gwef4pu34gdan.channel.owner.playerID.characterName;
                    }
                    catch (Exception)
                    {
                        Logger.Log($"Player not found: player has just left the server. UI call from: {gu1h3a4pu34ggi5dan.channel.owner.playerID.characterName}");
                        return;
                    }
                    gu1h3a123gwef4pu34gdan.inventory.onInventoryAdded += gu1ah3a4pu34agdfjghnc4an;
                    gu1h3a123gwef4pu34gdan.inventory.onInventoryRemoved += gu1ah3a4pu34agdfjghnc4an;
                    EffectManager.askEffectClearByID(8100, gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID);
                    gu1h3ac4pu34dgdfjghn4aan();
                    gu1h3aca4pu34gdfjgahn4an(gu1h3a4pu34ggi5dan, gu1h3a4pasdu34gdan);

                    EffectManager.onEffectButtonClicked -= gu1h3ca4pu34cdfjghnc4an;
                    EffectManager.onEffectButtonClicked += gu1ch3a4puc34gdfjghnc4an;
                    for (byte gu1h3a4pug87334gdan = 0; gu1h3a4pug87334gdan < Refresh.Refreshes.Length; gu1h3a4pug87334gdan++)
                    {
                        if (Refresh.Refreshes[gu1h3a4pug87334gdan].CallerSteamID.m_SteamID == gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID.m_SteamID)
                        {
                            Refresh.Refreshes[gu1h3a4pug87334gdan].TurnOff(gu1h3a4pug87334gdan);
                            break;
                        }
                    }
                    break;

                case "ButtonNext":
                    if (gu1h3a4pasdu34gdan == gu1h3a4pu34gdanasd)
                    {
                        EffectManager.sendUIEffectText(22, gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID, true, "page", $"{gu1h3a4pu34gdanasd}");
                        gu1h3a4pua34gdfcjghn4an(gu1h3a4pu34gdanasd, gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID.m_SteamID);
                        gu1h3ca4pu34cgdfjghc4an(gu1h3a4pu34gdanasd, gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID);
                        gu1h3a4pasdu34gdan = 1;
                    }
                    else
                    {
                        EffectManager.sendUIEffectText(22, gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID, true, "page", $"{gu1h3a4pasdu34gdan}");
                        gu1h3a4pua34gdfcjghn4an(gu1h3a4pasdu34gdan, gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID.m_SteamID);
                        gu1h3ca4pu34cgdfjghc4an(gu1h3a4pasdu34gdan, gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID);
                        gu1h3a4pasdu34gdan++;
                        //sends current page
                    }
                    break;
                case "ButtonPrev":
                    if (gu1h3a4pasdu34gdan == 1)
                    {
                        EffectManager.sendUIEffectText(22, gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID, true, "page", $"1");
                        gu1h3a4pua34gdfcjghn4an(1, gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID.m_SteamID);
                        gu1h3ca4pu34cgdfjghc4an(1, gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID);
                        gu1h3a4pasdu34gdan = gu1h3a4pu34gdanasd;
                        //sends 1st page
                    }
                    else
                    {
                        EffectManager.sendUIEffectText(22, gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID, true, "page", $"{gu1h3a4pasdu34gdan}");
                        gu1h3a4pua34gdfcjghn4an(gu1h3a4pasdu34gdan, gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID.m_SteamID);
                        gu1h3ca4pu34cgdfjghc4an(gu1h3a4pasdu34gdan, gu1h3a4pu34ggi5dan.channel.owner.playerID.steamID);
                        gu1h3a4pasdu34gdan--;
                        //sends current page
                    }
                    break;
                case "ButtonExit":
                    EffectManager.onEffectButtonClicked -= gu1h3ca4pu34cdfjghnc4an;
                    gu1h3a4pu34cgadfjghnc4an(gu1h3a4pu34ggi5dan, 8100);
                    break;
                default://non button click
                    return;
            }
        }

        public void gu1ch3a4puc34gdfjghnc4an(Player gu1h3a4puasd4y34gdan, string gu1hasd4563a4pu34gdan)
        {
            if(gu1hasd4563a4pu34gdan.Substring(0, 4) == "item")
            {
                if (!gu1h3a4pu34g3dan.HasPermission("rocket.invsee.edit") || !gu1h3a4pu34g3dan.HasPermission("rocket.ins.edit"))
                    return;
                byte.TryParse(gu1hasd4563a4pu34gdan.Substring(4), out gu1h316153a4pu34gdan);
                //itemIndex += (byte)((currentPage - 1) * 24); 
                gu1hasd4563a4pu34gdan = "item";
                gu1h3a4pu34gdfjghn4an = "";
                gu1h3a4pu348917gdan = "";
            }
                
            switch (gu1hasd4563a4pu34gdan)
            {
                case "item":
                    //show 8102
                    //EffectManager.askEffectClearByID(8101, callerPlayer.channel.owner.playerID.steamID);
                    if (gu1h3a4puasda134gdan[gu1h3a4pasdu34gdan - 1].Count >= gu1h316153a4pu34gdan + 1)
                        gu1h3aasd14pu34gdan = gu1h3a4puasda134gdan[gu1h3a4pasdu34gdan - 1][gu1h316153a4pu34gdan].ID;
                    //else
                    //    return;    
                    //selectedItem = (UIitemsPages[currentPage - 1].Count >= (itemIndex + 1))?(selectedItem = UIitemsPages[currentPage - 1][itemIndex]):(selectedItem = null);
                    //if (UIitemsPages[currentPage - 1].Count >= (itemIndex + 1))// editing item
                    //{
                    //    selectedItem = UIitemsPages[currentPage - 1][itemIndex];
                    //    //backUpItem = UIitemsPages[currentPage - 1][itemIndex];
                    //}
                    //else
                        //selectedItem = null;// + button

                    EffectManager.onEffectButtonClicked -= this.gu1ch3a4puc34gdfjghnc4an;
                    EffectManager.onEffectButtonClicked += gu1ah3a4pu34cgdfjghna4an;
                    EffectManager.onEffectTextCommitted += gu1hc3a4pu34gdafjghnc4an;
                    EffectManager.sendUIEffect(8102, 24, gu1h3a4puasd4y34gdan.channel.owner.playerID.steamID, true);
                    gu11231h3a4pu34gdan = fhui35hof893h9.One;
                    break;

                case "ButtonNext":
                    if (gu1h3a4pasdu34gdan == gu1h3a4pu34asgdan)
                        gu1h3a4pasdu34gdan = 1;
                    else
                        gu1h3a4pasdu34gdan++;
                    gu1h3ac4pu34dgdfjghn4aan();
                    EffectManager.askEffectClearByID(8101, gu1h3a4puasd4y34gdan.channel.owner.playerID.steamID);
                    gu1h3aca4pu34gdfjgahn4an(gu1h3a4puasd4y34gdan, gu1h3a4pasdu34gdan);
                    break;

                case "ButtonPrev":
                    if (gu1h3a4pasdu34gdan == 1)
                        gu1h3a4pasdu34gdan = gu1h3a4pu34asgdan;
                    else
                        gu1h3a4pasdu34gdan--;
                    gu1h3ac4pu34dgdfjghn4aan();
                    EffectManager.askEffectClearByID(8101, gu1h3a4puasd4y34gdan.channel.owner.playerID.steamID);
                    gu1h3aca4pu34gdfjgahn4an(gu1h3a4puasd4y34gdan, gu1h3a4pasdu34gdan);
                    break;

                case "MainPage":
                    gu11231h3a4pu34gdan = fhui35hof893h9.None;
                    if (gu1h3a123gwef4pu34gdan != null)
                    {
                        gu1h3a123gwef4pu34gdan.inventory.onInventoryAdded -= gu1ah3a4pu34agdfjghnc4an;
                        gu1h3a123gwef4pu34gdan.inventory.onInventoryRemoved -= gu1ah3a4pu34agdfjghnc4an;
                    }
                    EffectManager.askEffectClearByID(8101, UnturnedPlayer.FromPlayer(gu1h3a4puasd4y34gdan).CSteamID);
                    EffectManager.onEffectButtonClicked -= gu1ch3a4puc34gdfjghnc4an;
                    CommandGetInventory.Instance.Execute(UnturnedPlayer.FromPlayer(gu1h3a4puasd4y34gdan), null);
                    break;

                case "ButtonExit":
                    gu11231h3a4pu34gdan = fhui35hof893h9.None;
                    if (gu1h3a123gwef4pu34gdan != null)
                    {
                        gu1h3a123gwef4pu34gdan.inventory.onInventoryAdded -= gu1ah3a4pu34agdfjghnc4an;
                        gu1h3a123gwef4pu34gdan.inventory.onInventoryRemoved -= gu1ah3a4pu34agdfjghnc4an;
                    }
                    EffectManager.onEffectButtonClicked -= gu1ch3a4puc34gdfjghnc4an;
                    gu1h3a4pu34cgadfjghnc4an(gu1h3a4puasd4y34gdan, 8101);
                    break;
                default://non button click
                    break;
            }
        }

        private void gu1h3ac4pu34gadfjgchn4an(Player gu1h3aasdy4pu34gdan, PlayerInventory gu1h3aasd1554pu34gdan, ushort gu1h3a4pu34gdasd1an)
        {
            if (gu1h3a123gwef4pu34gdan != null)
            {
                gu1h3a123gwef4pu34gdan.inventory.onInventoryAdded -= gu1ah3a4pu34agdfjghnc4an;
                gu1h3a123gwef4pu34gdan.inventory.onInventoryRemoved -= gu1ah3a4pu34agdfjghnc4an;
            }
            //List<ItemsPair> PageIndexPair = new List<ItemsPair>();
            //ushort counter = 0;
            ////Console.WriteLine($"iteratuin started");
            //foreach (Items page in inventory.items)
            //{
            //    if (page == null)
            //        continue;
            //    foreach (ItemJar item in page.items)
            //    {
            //        if (item.item.id == id)
            //            counter++;
            //            //PageIndexPair.Add(new ItemsPair() { page = page, index = page.getIndex(item.x, item.y)});
            //    }
            //}
            //Console.WriteLine($"PageIndexPair.Count: {PageIndexPair.Count}");
            //foreach (var pair in PageIndexPair)
            //    pair.page.removeItem(pair.index);
            for (ushort gu1h3a4pu34gasd1dan = 0; gu1h3a4pu34gasd1dan < (ushort)gu1h3aasd1554pu34gdan.items.Length; gu1h3a4pu34gasd1dan++)
            {
                if (gu1h3aasd1554pu34gdan.items[gu1h3a4pu34gasd1dan] == null)
                    continue;
                if (gu1h3aasd1554pu34gdan.items[gu1h3a4pu34gasd1dan].items.Count == 0)
                    continue;
                ushort len2 = (ushort)gu1h3aasd1554pu34gdan.items[gu1h3a4pu34gasd1dan].items.Count;
                for (ushort j = 0; j < len2; j++)
                {
                    if(gu1h3aasd1554pu34gdan.items[gu1h3a4pu34gasd1dan].items[j].item.id == gu1h3a4pu34gdasd1an)
                    {
                        gu1h3aasd1554pu34gdan.items[gu1h3a4pu34gasd1dan].removeItem(gu1h3aasd1554pu34gdan.items[gu1h3a4pu34gasd1dan].getIndex(gu1h3aasd1554pu34gdan.items[gu1h3a4pu34gasd1dan].items[j].x, gu1h3aasd1554pu34gdan.items[gu1h3a4pu34gasd1dan].items[j].y));
                        len2--;
                        j--;
                    }
                }
            }

            if (gu1h3a123gwef4pu34gdan != null)
            {
                gu1h3ac4pu34dgdfjghn4aan();
                EffectManager.askEffectClearByID(8101, gu1hasd33a4pu34gdan.channel.owner.playerID.steamID);
                gu1h3aca4pu34gdfjgahn4an(gu1h3aasdy4pu34gdan, gu1h3a4pasdu34gdan);
                gu1h3a123gwef4pu34gdan.inventory.onInventoryAdded += gu1ah3a4pu34agdfjghnc4an;
                gu1h3a123gwef4pu34gdan.inventory.onInventoryRemoved += gu1ah3a4pu34agdfjghnc4an;
            }
        }

        private void gu1h3a4pu34gadfjghcn4an(Player gu1h3a4puasd34gdan, PlayerInventory gu1hasd13a4pu34gdan, ushort gu1h3a4pu34gdanasd1, ushort gu1h3a4pu34gdan123d1)//as much as possible will delete
        {
            if (gu1h3a123gwef4pu34gdan != null)
            {
                gu1h3a123gwef4pu34gdan.inventory.onInventoryAdded -= gu1ah3a4pu34agdfjghnc4an;
                gu1h3a123gwef4pu34gdan.inventory.onInventoryRemoved -= gu1ah3a4pu34agdfjghnc4an;
            }
            ushort itemsRemoved = 0;
            for (ushort gu1h3a4pu34gdasd1an = 0; gu1h3a4pu34gdasd1an < (ushort)gu1hasd13a4pu34gdan.items.Length && itemsRemoved < gu1h3a4pu34gdan123d1; gu1h3a4pu34gdasd1an++)
            {
                if (gu1hasd13a4pu34gdan.items[gu1h3a4pu34gdasd1an] == null)
                    continue;
                if (gu1hasd13a4pu34gdan.items[gu1h3a4pu34gdasd1an].items.Count == 0)
                    continue;
                ushort gu1h3a4p81hru34gdan = (ushort)gu1hasd13a4pu34gdan.items[gu1h3a4pu34gdasd1an].items.Count;
                for (ushort j = 0; j < gu1h3a4p81hru34gdan && itemsRemoved < gu1h3a4pu34gdan123d1; j++)
                {
                    if (gu1hasd13a4pu34gdan.items[gu1h3a4pu34gdasd1an].items[j].item.id == gu1h3a4pu34gdanasd1)
                    {
                        gu1hasd13a4pu34gdan.items[gu1h3a4pu34gdasd1an].removeItem(gu1hasd13a4pu34gdan.items[gu1h3a4pu34gdasd1an].getIndex(gu1hasd13a4pu34gdan.items[gu1h3a4pu34gdasd1an].items[j].x, gu1hasd13a4pu34gdan.items[gu1h3a4pu34gdasd1an].items[j].y));
                        gu1h3a4p81hru34gdan--;
                        j--;
                        itemsRemoved++;
                    }
                }
            }
            if (gu1h3a123gwef4pu34gdan != null)
            {
                gu1h3a123gwef4pu34gdan.inventory.onInventoryAdded += gu1ah3a4pu34agdfjghnc4an;
                gu1h3a123gwef4pu34gdan.inventory.onInventoryRemoved += gu1ah3a4pu34agdfjghnc4an;
                gu1h3ac4pu34dgdfjghn4aan();
                EffectManager.askEffectClearByID(8101, gu1hasd33a4pu34gdan.channel.owner.playerID.steamID);
                gu1h3aca4pu34gdfjgahn4an(gu1h3a4puasd34gdan, gu1h3a4pasdu34gdan);
            }
        }

        public void gu1ah3a4pu34cgdfjghna4an(Player gu1h3a4pu34gdanasd173, string gu1h3a4p811488u34gdan)
        {
            //Console.WriteLine($"button clicked: {buttonName}");
            if (!Directory.Exists(Plugin.Instance.pathTemp + $"\\{gu1h3a4pu3141244gdan}"))
                Directory.CreateDirectory(Plugin.Instance.pathTemp + $"\\{gu1h3a4pu3141244gdan}");
            if (gu1h3a4p811488u34gdan == "SaveExit" && gu1h3a4pu34gdfjghn4an != "" && gu1h3a4pu348917gdan != "")
            {
                gu11231h3a4pu34gdan = fhui35hof893h9.None;
                if (!ushort.TryParse(gu1h3a4pu34gdfjghn4an, out ushort gu1h3a4asdj1pu34gdan) || !short.TryParse(gu1h3a4pu348917gdan, out short gu1h3a4puasd134gdan))
                {
                    UnturnedChat.Say(gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID, $"Provided ID or amount is not a number", UnityEngine.Color.red);
                    EffectManager.onEffectButtonClicked -= gu1ah3a4pu34cgdfjghna4an;
                    EffectManager.onEffectButtonClicked += gu1ch3a4puc34gdfjghnc4an;
                    EffectManager.askEffectClearByID(8102, gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID);
                    EffectManager.onEffectTextCommitted -= gu1hc3a4pu34gdafjghnc4an;

                    return;
                }

                if (Assets.find(EAssetType.ITEM, gu1h3a4asdj1pu34gdan) == null)
                {
                    UnturnedChat.Say(gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID, $"ID: {gu1h3a4asdj1pu34gdan} cannot be found, check if your id exists", UnityEngine.Color.red);
                    EffectManager.onEffectButtonClicked -= gu1ah3a4pu34cgdfjghna4an;
                    EffectManager.onEffectButtonClicked += gu1ch3a4puc34gdfjghnc4an;
                    EffectManager.onEffectTextCommitted -= gu1hc3a4pu34gdafjghnc4an;
                    EffectManager.askEffectClearByID(8102, gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID);

                    return;
                }

                ItemAsset gu13a4pu34gdaasd173 = (ItemAsset)Assets.find(EAssetType.ITEM, gu1h3a4asdj1pu34gdan);
                Item newgu1h3gdanasd173tem = new Item(gu13a4pu34gdaasd173.id, gu13a4pu34gdaasd173.amount, 100, gu13a4pu34gdaasd173.getState());
                if (gu1h3a123gwef4pu34gdan != null && gu1h3a4puasd134gdan >= 0)
                {
                    for (short i = 0; i < gu1h3a4puasd134gdan; i++)
                    {
                        if (!gu1h3a123gwef4pu34gdan.inventory.tryAddItemAuto(newgu1h3gdanasd173tem, false, false, false, false))
                        {
                            UnturnedChat.Say(gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID, $"{(gu1h3a123gwef4pu34gdan != null ? gu1h3a123gwef4pu34gdan.channel.owner.playerID.characterName + "'s" : "player's")} inventory is full, loading item: {gu13a4pu34gdaasd173.name} to his virtual inventory");
                            fiuiuasfifasfsa.WriteItem(newgu1h3gdanasd173tem, Plugin.Instance.pathTemp + $"\\{gu1h3a4pu3141244gdan}\\Heap.dat");
                        }
                        //else
                        //{
                        //    OnInventoryChange triggers => sends 8101 update
                        //}
                    }
                }
                else if (gu1h3a123gwef4pu34gdan != null && gu1h3a4puasd134gdan < 0)
                    gu1h3a4pu34gadfjghcn4an(gu1h3a4pu34gdanasd173, gu1h3a123gwef4pu34gdan.inventory, gu1h3a4asdj1pu34gdan, (ushort)gu1h3a4puasd134gdan);
                else
                {
                    UnturnedChat.Say(gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID, $"Player has just left the server, loading to player's virtual inventory..");
                    for (ushort i = 0; i < Convert.ToUInt16(gu1h3a4pu348917gdan); i++)
                        fiuiuasfifasfsa.WriteItem(newgu1h3gdanasd173tem, Plugin.Instance.pathTemp + $"\\{gu1h3a4pu3141244gdan}\\Heap.dat");// if player is offline load to virtual heap
                }
                EffectManager.onEffectButtonClicked -= gu1ah3a4pu34cgdfjghna4an;
                EffectManager.onEffectButtonClicked += gu1ch3a4puc34gdfjghnc4an;
                EffectManager.onEffectTextCommitted -= gu1hc3a4pu34gdafjghnc4an;
                EffectManager.askEffectClearByID(8102, gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID);

                return;
            }
            switch (gu1h3a4p811488u34gdan)
            {
                case "ButtonRemove":
                    if (gu1h3aasd14pu34gdan == 0)
                        break;
                    if (gu1h3a123gwef4pu34gdan != null)
                    {
                        gu1h3ac4pu34gadfjgchn4an(gu1h3a4pu34gdanasd173, gu1h3a123gwef4pu34gdan.inventory, gu1h3aasd14pu34gdan);
                        UnturnedChat.Say(gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID, $"All ID: {gu1h3aasd14pu34gdan} items were removed from {gu1h3a123gwef4pu34gdan.channel.owner.playerID.characterName}");
                    }
                    else
                        UnturnedChat.Say(gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID, $"Cannot remove items from player, because player left the server");
                    //EffectManager.askEffectClearByID(8102, callerPlayer.channel.owner.playerID.steamID);
                    //EffectManager.sendUIEffect(8102, 24, callerPlayer.channel.owner.playerID.steamID, true);
                    break;
                case "ButtonAdd":
                    if (gu1h3aasd14pu34gdan == 0)
                        break;
                    ItemAsset gu1h3a4asd1pu34gdanasd173 = (ItemAsset)Assets.find(EAssetType.ITEM, gu1h3aasd14pu34gdan);
                    Item gu1h3a4pu34gdan1232asd173 = new Item(gu1h3a4asd1pu34gdanasd173.id, gu1h3a4asd1pu34gdanasd173.amount, 100, gu1h3a4asd1pu34gdanasd173.getState());
                    if (gu1h3a123gwef4pu34gdan != null)
                    {
                        if (!gu1h3a123gwef4pu34gdan.inventory.tryAddItemAuto(gu1h3a4pu34gdan1232asd173, false, false, false, false))
                        {
                            UnturnedChat.Say(gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID, $"{(gu1h3a123gwef4pu34gdan != null ? gu1h3a123gwef4pu34gdan.channel.owner.playerID.characterName + "'s" : "player's")} inventory is full, loading item: {gu1h3a4asd1pu34gdanasd173.name} to his virtual inventory");
                            fiuiuasfifasfsa.WriteItem(gu1h3a4pu34gdan1232asd173, Plugin.Instance.pathTemp + $"\\{gu1h3a4pu3141244gdan}\\Heap.dat");
                        }
                    }
                    else
                    {
                        UnturnedChat.Say(gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID, $"Player has just left the server, loading to player's virtual inventory..");
                        for (ushort i = 0; i < Convert.ToUInt16(gu1h3a4pu348917gdan); i++)
                            fiuiuasfifasfsa.WriteItem(gu1h3a4pu34gdan1232asd173, Plugin.Instance.pathTemp + $"\\{gu1h3a4pu3141244gdan}\\Heap.dat");// if player is offline load to virtual heap
                    }
                    //EffectManager.askEffectClearByID(8102, callerPlayer.channel.owner.playerID.steamID);
                    //EffectManager.sendUIEffect(8102, 24, callerPlayer.channel.owner.playerID.steamID, true);
                    break;
                case "ButtonDel":
                    if (gu1h3aasd14pu34gdan == 0)
                        break;
                    if (gu1h3a123gwef4pu34gdan != null)
                    {
                        gu1h3a4pu34gadfjghcn4an(gu1h3a4pu34gdanasd173, gu1h3a123gwef4pu34gdan.inventory, gu1h3aasd14pu34gdan, 1);
                        //UnturnedChat.Say(callerPlayer.channel.owner.playerID.steamID, $"ID: {selectedId} item was removed from {targetPlayer.channel.owner.playerID.characterName}");
                    }
                    else
                        UnturnedChat.Say(gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID, $"Cannot remove item from player, because player left the server");
                    EffectManager.askEffectClearByID(8102, gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID);
                    EffectManager.sendUIEffect(8102, 24, gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID, true);
                    break;
                case "MainPage":
                    gu11231h3a4pu34gdan = fhui35hof893h9.None;
                    EffectManager.onEffectButtonClicked -= gu1ah3a4pu34cgdfjghna4an;
                    EffectManager.onEffectButtonClicked += gu1ch3a4puc34gdfjghnc4an;
                    EffectManager.onEffectTextCommitted -= gu1hc3a4pu34gdafjghnc4an;
                    EffectManager.askEffectClearByID(8102, gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID);
                    break;
                case "ButtonHelp":
                    EffectManager.onEffectButtonClicked -= gu1ah3a4pu34cgdfjghna4an;
                    EffectManager.onEffectButtonClicked += gu1hb3a4puc34gdfjgahn4an;
                    EffectManager.onEffectTextCommitted += gu1hc3a4pu3a4gdfjgchn4an;
                    EffectManager.sendUIEffect(8103, 27, gu1h3a4pu34gdanasd173.channel.owner.playerID.steamID, true);
                    gu11231h3a4pu34gdan = fhui35hof893h9.Two;
                    break;
                //case "ButtonOk":
                //    EffectManager.onEffectButtonClicked -= OnEffectButtonClick8102;
                //    EffectManager.onEffectButtonClicked += OnEffectButtonClick8101;
                //    EffectManager.onEffectTextCommitted -= OnTextCommited;
                //    EffectManager.askEffectClearByID(8102, callerPlayer.channel.owner.playerID.steamID);
                //    break;
                default://non button click
                    //EffectManager.askEffectClearByID(8102, callerPlayer.channel.owner.playerID.steamID);
                    //EffectManager.sendUIEffect(8102, 24, callerPlayer.channel.owner.playerID.steamID, false);
                    break;
            }
            //Console.WriteLine("IF AND ELSE PASSED");
            //EffectManager.onEffectButtonClicked -= OnEffectButtonClick8102;
            //EffectManager.onEffectButtonClicked += OnEffectButtonClick8101;
            //EffectManager.askEffectClearByID(8102, callerPlayer.channel.owner.playerID.steamID);
            //EffectManager.onEffectTextCommitted -= OnTextCommited;
        }

        private void gu1hc3a4pu34gdafjghnc4an(Player player, string gu1h3a4pu34gdfjgh4an, string text)
        {
            if (gu1h3a4pu34gdfjgh4an == "ID")
                gu1h3a4pu34gdfjghn4an = text;
            else
                gu1h3a4pu348917gdan = text;
        }

        private void gu1hc3a4pu3a4gdfjgchn4an(Player player, string field, string text)
        {
            //Console.WriteLine($"field: {field}");
            if (field == "Input")
                gu1h3a4pbu34gdafjaghn4an(player.channel.owner.playerID.steamID, text);
        }

        private void gu1h3a4pbu34gdafjaghn4an(Steamworks.CSteamID gu1h3a4pu34gdasdfjghn4an, string gu1h3a4pu34gdfjgasdhn4an)
        {
            //EffectManager.askEffectClearByID(8103, callerPlayer.channel.owner.playerID.steamID);
            ItemAsset gu1h3a4pu34gdsfjghn4an = new List<ItemAsset>(Assets.find(EAssetType.ITEM).Cast<ItemAsset>()).Where<ItemAsset>((Func<ItemAsset, bool>)(i => i.itemName != null)).OrderBy<ItemAsset, int>((Func<ItemAsset, int>)(i => i.itemName.Length)).Where<ItemAsset>((Func<ItemAsset, bool>)(i => i.itemName.ToLower().Contains(gu1h3a4pu34gdfjgasdhn4an.ToLower()))).FirstOrDefault<ItemAsset>();
            if (gu1h3a4pu34gdsfjghn4an == null)
            {
                EffectManager.sendUIEffect(8103, 27, gu1hasd33a4pu34gdan.channel.owner.playerID.steamID, true);
                EffectManager.sendUIEffectText(27, gu1h3a4pu34gdasdfjghn4an, true, "Output", "Failed to find ID");
            }
            else
            {
                EffectManager.sendUIEffect(8103, 27, gu1hasd33a4pu34gdan.channel.owner.playerID.steamID, true);
                EffectManager.sendUIEffectText(27, gu1h3a4pu34gdasdfjghn4an, true, "Output", $"{gu1h3a4pu34gdsfjghn4an.id}");
                EffectManager.sendUIEffectText(27, gu1h3a4pu34gdasdfjghn4an, true, "OutputName", $"{gu1h3a4pu34gdsfjghn4an.itemName}");
            }
        }

        private void gu1hb3a4puc34gdfjgahn4an(Player callerPlayer, string button)
        {
            if(button == "ButtonOk")
            {
                gu11231h3a4pu34gdan = fhui35hof893h9.One;
                EffectManager.onEffectButtonClicked -= gu1hb3a4puc34gdfjgahn4an;
                EffectManager.onEffectButtonClicked += gu1ah3a4pu34cgdfjghna4an;
                EffectManager.askEffectClearByID(8103, callerPlayer.channel.owner.playerID.steamID);
            }
        }

        private void gu1ah3a4pu34agdfjghnc4an(byte page, byte index, ItemJar item)//if player exits this automatically removed
        {
            //if (token.IsCancellationRequested)
            //    return;
            //EffectManager.askEffectClearByID(8101, this.callerPlayer.channel.owner.playerID.steamID);
            gu1h3ac4pu34dgdfjghn4aan();
            //await System.Threading.Tasks.Task.Run(()=> ShowItemsUI(this.callerPlayer, currentPage));
            gu1h3aca4pu34gdfjgahn4an(this.gu1hasd33a4pu34gdan, gu1h3a4pasdu34gdan);
            //ShowItemsUI(this.callerPlayer, currentPage);
        }

        private void gu1h3aca4pu34gdfjgahn4an(Player gu1h3a4pu34ngdfjghn4an, byte gu1h3a4pu34cgdfjghn4an)//target player idnex in provider.clients
        {
            Console.WriteLine();
            //foreach (var pag in UIitemsPages)
            //{
            //    Console.WriteLine($"page count in ShowUI: {pag.Count}");
            //}
            Console.WriteLine();
            try
            {
                EffectManager.sendUIEffect(8101, 23, gu1h3a4pu34ngdfjghn4an.channel.owner.playerID.steamID, true);
                if(gu1h3a4puasda134gdan[gu1h3a4pu34cgdfjghn4an - 1].Count != 0)
                    for (byte i = 0; i < gu1h3a4puasda134gdan[gu1h3a4pu34cgdfjghn4an - 1].Count; i++)
                        EffectManager.sendUIEffectText(23, gu1h3a4pu34ngdfjghn4an.channel.owner.playerID.steamID, true, $"item{i}", $"{((ItemAsset)Assets.find(EAssetType.ITEM, gu1h3a4puasda134gdan[gu1h3a4pu34cgdfjghn4an - 1][i].ID)).itemName}\r\nID: {gu1h3a4puasda134gdan[gu1h3a4pu34cgdfjghn4an - 1][i].ID}\r\nCount: {gu1h3a4puasda134gdan[gu1h3a4pu34cgdfjghn4an - 1][i].Count}");
                EffectManager.sendUIEffectText(23, gu1h3a4pu34ngdfjghn4an.channel.owner.playerID.steamID, true, "page", $"{gu1h3a4pu34cgdfjghn4an}");
                EffectManager.sendUIEffectText(23, gu1h3a4pu34ngdfjghn4an.channel.owner.playerID.steamID, true, "pagemax", $"{gu1h3a4pu34asgdan}");
                EffectManager.sendUIEffectText(23, gu1h3a4pu34ngdfjghn4an.channel.owner.playerID.steamID, true, "playerName", $"{gu1h3a4pasdghu34gdan}");
                if (gu11231h3a4pu34gdan == fhui35hof893h9.One)
                {
                    EffectManager.askEffectClearByID(8102, gu1h3a4pu34ngdfjghn4an.channel.owner.playerID.steamID);
                    EffectManager.sendUIEffect(8102, 24, gu1h3a4pu34ngdfjghn4an.channel.owner.playerID.steamID, true);
                }
                    
                else if (gu11231h3a4pu34gdan == fhui35hof893h9.Two)
                {
                    EffectManager.askEffectClearByID(8102, gu1h3a4pu34ngdfjghn4an.channel.owner.playerID.steamID);
                    EffectManager.askEffectClearByID(8103, gu1h3a4pu34ngdfjghn4an.channel.owner.playerID.steamID);
                    EffectManager.sendUIEffect(8102, 24, gu1h3a4pu34ngdfjghn4an.channel.owner.playerID.steamID, true);
                    EffectManager.sendUIEffect(8103, 27, gu1h3a4pu34ngdfjghn4an.channel.owner.playerID.steamID, true);
                }
                    
            }
            catch (Exception e)
            {
                Console.WriteLine("exception in show ui");
                Console.WriteLine(e);
                gu1h3a4pu34cgadfjghnc4an(gu1h3a4pu34ngdfjghn4an, 8101);
                return;
            }
        }

        private void gu1h3ac4pu34dgdfjghn4aan()
        {
            gu1h3a4puasda134gdan.Clear();
            Items[] gu1h3a4pau34gdfjghn4an;
            try
            {
                gu1h3a4pau34gdfjghn4an = gu1h3a123gwef4pu34gdan.inventory.items;// array (reference type in stack => by value)
            }
            catch (Exception e)
            {
                // load to Inventory.dat and maybe to virtual inventory
                Console.WriteLine("exception in target items");
                Console.WriteLine(e);
                gu1h3a4pu34cgadfjghnc4an(gu1hasd33a4pu34gdan, 8101);
                return;
            }
            List<MyItem> gu1h3a4pu34gdfasjghn4an = new List<MyItem>();

            foreach (var gu1h3ac4pu34gdfjcghn4an in gu1h3a4pau34gdfjghn4an)
            {
                if (gu1h3ac4pu34gdfjcghn4an == null)
                    continue;
                foreach (ItemJar gu1h3a4pu34gdfjasghn4an in gu1h3ac4pu34gdfjcghn4an.items)
                {
                    MyItem myItem = new MyItem(gu1h3a4pu34gdfjasghn4an.item.id, gu1h3a4pu34gdfjasghn4an.item.amount, gu1h3a4pu34gdfjasghn4an.item.quality, gu1h3a4pu34gdfjasghn4an.item.state);
                    if (Plugin.Instance.HasItem(myItem, gu1h3a4pu34gdfasjghn4an))
                        continue;
                    else
                        gu1h3a4pu34gdfasjghn4an.Add(myItem);
                }
            }

            if (gu1h3a4pu34gdfasjghn4an.Count == 0)
            {
                //Console.WriteLine("items.count in get gettarget is 0");
                gu1h3a4pu34asgdan = 1;
                gu1h3a4puasda134gdan.Add(gu1h3a4pu34gdfasjghn4an);
                return;
            }
                
            ushort gu1h3a4pu34asgdfjghn4an = 0;
            for (byte i = 0; i < (byte)Math.Ceiling(gu1h3a4pu34gdfasjghn4an.Count / 24.0); i++)
            {
                List<MyItem> myPage = new List<MyItem>();
                for (ushort j = 0; j < 24 && gu1h3a4pu34asgdfjghn4an < (ushort)gu1h3a4pu34gdfasjghn4an.Count; j++, gu1h3a4pu34asgdfjghn4an++)
                    myPage.Add(new MyItem(gu1h3a4pu34gdfasjghn4an[gu1h3a4pu34asgdfjghn4an].ID, gu1h3a4pu34gdfasjghn4an[gu1h3a4pu34asgdfjghn4an].X, gu1h3a4pu34gdfasjghn4an[gu1h3a4pu34asgdfjghn4an].Quality, gu1h3a4pu34gdfasjghn4an[gu1h3a4pu34asgdfjghn4an].State, gu1h3a4pu34gdfasjghn4an[gu1h3a4pu34asgdfjghn4an].Count));
                gu1h3a4puasda134gdan.Add(myPage);
            }
            gu1h3a4pu34asgdan = (byte)gu1h3a4puasda134gdan.Count;
            //Console.WriteLine("in get target items");
            //Console.WriteLine($"UIitemsPages.Count: {UIitemsPages.Count}");
            //Console.WriteLine($"PagesCountInv: {PagesCountInv}");
        }

        private void gu1h3a4pu34cgadfjghnc4an(Player gu1h3a4pu34gdasfjghn4an, ushort effectId)
        {
            EffectManager.askEffectClearByID(effectId, gu1h3a4pu34gdasfjghn4an.channel.owner.playerID.steamID);
            gu1h3a4pu34gdasfjghn4an.serversideSetPluginModal(false);
            fuirhfgui2h5.gu1h3a4pu3asd4gdan.Remove(gu1h3a4pu34gdasfjghn4an);
            //Console.WriteLine($"caller: {callerPlayer.channel.owner.playerID.characterName} removed from list!");
            gu1h3a4puasda134gdan.Clear();
        }
    }
}