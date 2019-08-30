using SDG.Unturned;
using System.Collections.Generic;

namespace ItemRestrictorAdvanced
{
    class furhfuh4uhf
    {
        byte gu1h3a4pu34gdan;
        byte gu1h3a4pu3as4gdan;
        byte gu1h3aasd4pu34gdan;
        List<List<MyItem>> gu1h3a4pu34gasdan;

        public furhfuh4uhf(List<List<MyItem>> gu1h3a4puas34gdan, byte gu1h3a4pua34gdan)
        {
            gu1h3aasd4pu34gdan = 1;
            gu1h3a4pu34gasdan = gu1h3a4puas34gdan;
            this.gu1h3a4pu3as4gdan = gu1h3a4pua34gdan;
        }

        public void OnEffectButtonClick8101(Player gu1h3a4puas34gdan, string gu1h3aas4pu34gdan)
        {
            if (gu1h3aas4pu34gdan.Substring(0, 4) == "item")
            {
                byte.TryParse(gu1h3aas4pu34gdan.Substring(4), out gu1h3a4pu34gdan);
                //itemIndex += (byte)((currentPage - 1) * 24);
                gu1h3aas4pu34gdan = "item";
            }

            switch (gu1h3aas4pu34gdan)
            {
                case "item":
                    if((gu1h3a4pu34gdan + 1) <= gu1h3a4pu34gasdan[gu1h3aasd4pu34gdan - 1].Count)
                    {
                        MyItem gu1h3a4pu34gdasan = gu1h3a4pu34gasdan[gu1h3aasd4pu34gdan - 1][gu1h3a4pu34gdan];
                        if (gu1h3a4puas34gdan.inventory.tryAddItemAuto(new Item(gu1h3a4pu34gdasan.ID, gu1h3a4pu34gdasan.X, gu1h3a4pu34gdasan.Quality, gu1h3a4pu34gdasan.State), false, false, false, false))
                        {
                            //MyItemsPages[currentPage - 1][itemIndex].Count--;
                            if (--gu1h3a4pu34gasdan[gu1h3aasd4pu34gdan - 1][gu1h3a4pu34gdan].Count == 0)
                                gu1h3a4pu34gasdan[gu1h3aasd4pu34gdan - 1].RemoveAt(gu1h3a4pu34gdan);
                            //ReturnLoad(MyItemsPages, callerPlayer.channel.owner.playerID.steamID.ToString());
                        }
                        else
                            Rocket.Unturned.Chat.UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromPlayer(gu1h3a4puas34gdan), "You inventory is full, remove something");
                        EffectManager.askEffectClearByID(26, gu1h3a4puas34gdan.channel.owner.playerID.steamID);
                        ShowItemsUI(gu1h3a4puas34gdan, gu1h3aasd4pu34gdan);
                    }                  
                    break;

                case "ButtonNext":
                    if (gu1h3aasd4pu34gdan == gu1h3a4pu3as4gdan)
                        gu1h3aasd4pu34gdan = 1;
                    else
                        gu1h3aasd4pu34gdan++;
                    EffectManager.askEffectClearByID(8101, gu1h3a4puas34gdan.channel.owner.playerID.steamID);
                    ShowItemsUI(gu1h3a4puas34gdan, gu1h3aasd4pu34gdan);
                    break;

                case "ButtonPrev":
                    if (gu1h3aasd4pu34gdan == 1)
                        gu1h3aasd4pu34gdan = gu1h3a4pu3as4gdan;
                    else
                        gu1h3aasd4pu34gdan--;
                    EffectManager.askEffectClearByID(8101, gu1h3a4puas34gdan.channel.owner.playerID.steamID);
                    ShowItemsUI(gu1h3a4puas34gdan, gu1h3aasd4pu34gdan);
                    break;

                case "MainPage":
                    EffectManager.onEffectButtonClicked -= this.OnEffectButtonClick8101;
                    ReturnLoad(gu1h3a4pu34gasdan, gu1h3a4puas34gdan.channel.owner.playerID.steamID.ToString());
                    QuitUI(gu1h3a4puas34gdan, 8101);
                    break;
                case "ButtonExit":
                    EffectManager.onEffectButtonClicked -= this.OnEffectButtonClick8101;
                    ReturnLoad(gu1h3a4pu34gasdan, gu1h3a4puas34gdan.channel.owner.playerID.steamID.ToString());
                    QuitUI(gu1h3a4puas34gdan, 8101);
                    break;
                default://non button click
                    return;
            }
        }
        private void ShowItemsUI(Player gu1h3a4pu34gd, byte gu1h3a4pu34g)//target player idnex in provider.clients
        {
            try
            {
                EffectManager.sendUIEffect(8101, 26, gu1h3a4pu34gd.channel.owner.playerID.steamID, true);
                if (gu1h3a4pu34gasdan[gu1h3a4pu34g - 1].Count != 0)
                    for (byte i = 0; i < gu1h3a4pu34gasdan[gu1h3a4pu34g - 1].Count; i++)
                        EffectManager.sendUIEffectText(26, gu1h3a4pu34gd.channel.owner.playerID.steamID, true, $"item{i}", $"{((ItemAsset)Assets.find(EAssetType.ITEM, gu1h3a4pu34gasdan[gu1h3a4pu3as4gdan - 1][i].ID)).itemName}\r\nID: {gu1h3a4pu34gasdan[gu1h3a4pu3as4gdan - 1][i].ID}\r\nCount: {gu1h3a4pu34gasdan[gu1h3a4pu3as4gdan - 1][i].Count}");
                for (byte i = (byte)gu1h3a4pu34gasdan[0].Count; i < 24; i++)
                    EffectManager.sendUIEffectText(26, gu1h3a4pu34gd.channel.owner.playerID.steamID, true, $"item{i}", $"");
                EffectManager.sendUIEffectText(26, gu1h3a4pu34gd.channel.owner.playerID.steamID, true, "page", $"{gu1h3a4pu34g}");
                EffectManager.sendUIEffectText(26, gu1h3a4pu34gd.channel.owner.playerID.steamID, true, "pagemax", $"{gu1h3a4pu3as4gdan}");
                EffectManager.sendUIEffectText(26, gu1h3a4pu34gd.channel.owner.playerID.steamID, true, "playerName", $"Cloud: {gu1h3a4pu34gd.channel.owner.playerID.characterName}");
            }
            catch (System.Exception e)
            {
                Rocket.Core.Logging.Logger.LogException(e, "Exception in ManageCloudUI.ShowItemsUI(Player, byte)");
                QuitUI(gu1h3a4pu34gd, 8101);
                return;
            }
        }

        private void ReturnLoad(List<List<MyItem>> gu1h3a4pu34gdanasd, string gu1h3a4aspu34gdan)
        {
            Block gu1h3a4pu3s4gdan = new Block(0);
            ushort gu1h3a4pu34gdaan = 0;
            foreach (List<MyItem> gu1u34gdan in gu1h3a4pu34gdanasd)
            {
                foreach (MyItem asd32g24g in gu1u34gdan)
                    gu1h3a4pu34gdaan += asd32g24g.Count;
            }
            byte gu1h3a4p = (byte)System.Math.Floor(gu1h3a4pu34gdaan / 256.0);
            gu1h3a4pu3s4gdan.writeByte((byte)gu1h3a4pu34gdaan);
            gu1h3a4pu3s4gdan.writeByte(gu1h3a4p);
            if (!System.IO.Directory.Exists(Plugin.Instance.pathTemp + $"\\{gu1h3a4aspu34gdan}"))
                System.IO.Directory.CreateDirectory(Plugin.Instance.pathTemp + $"\\{gu1h3a4aspu34gdan}");
            if (gu1h3a4pu34gdaan == 0)
            {
                fiuiuasfifasfsa.gu1h3a4pu34haass1gdan(Plugin.Instance.pathTemp + $"\\{gu1h3a4aspu34gdan}\\Heap.dat", gu1h3a4pu3s4gdan, false);
                return;
            }


            foreach (List<MyItem> gu1h3a4pu34asgdan in gu1h3a4pu34gdanasd)
            {
                foreach (MyItem gu1h3a4pu34gdanasdsd2 in gu1h3a4pu34asgdan)
                {
                    //itemsCount += item.Count;
                    for (byte i = 0; i < gu1h3a4pu34gdanasdsd2.Count; i++)
                    {
                        gu1h3a4pu3s4gdan.writeUInt16(gu1h3a4pu34gdanasdsd2.ID);
                        gu1h3a4pu3s4gdan.writeByte(gu1h3a4pu34gdanasdsd2.X);
                        gu1h3a4pu3s4gdan.writeByte(gu1h3a4pu34gdanasdsd2.Quality);
                        gu1h3a4pu3s4gdan.writeUInt16((ushort)gu1h3a4pu34gdanasdsd2.State.Length);
                        foreach (byte bite in gu1h3a4pu34gdanasdsd2.State)
                            gu1h3a4pu3s4gdan.writeByte(bite);
                    }
                    
                    //block.writeUInt16(item.id);
                    //block.writeByte(item.amount);
                    //block.writeByte(item.quality);
                    //block.writeUInt16((ushort)item.state.Length);
                    //foreach (byte bite in item.state)
                    //    block.writeByte(bite);
                }
            }

            fiuiuasfifasfsa.gu1h3a4pu34haass1gdan(Plugin.Instance.pathTemp + $"\\{gu1h3a4aspu34gdan}\\Heap.dat", gu1h3a4pu3s4gdan, false);
        }

        private void QuitUI(Player gu1h3aas4pu34gdan, ushort gu1h3a4pu3)
        {
            EffectManager.askEffectClearByID(gu1h3a4pu3, gu1h3aas4pu34gdan.channel.owner.playerID.steamID);
            gu1h3aas4pu34gdan.serversideSetPluginModal(false);
            //ManageUI.UICallers.Remove(callerPlayer);
            gu1h3a4pu34gasdan.Clear();
        }
    }
}
//Effect ID is the id parameter, key is an optional instance identifier for modifying instances of an effect, 
//and child name is the unity name of a GameObject with a Text component.