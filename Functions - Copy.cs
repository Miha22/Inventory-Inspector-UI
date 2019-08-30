using SDG.Unturned;
using System.IO;
using System.Collections.Generic;

namespace ItemRestrictorAdvanced
{
    class Functions
    {
        public static void WriteBlock(string path, Block block, bool isUnited)
        {
            int size = 0;
            byte[] bytes = isUnited ? block.block : block.getBytes(out size);
            writeBytes(path, bytes, isUnited ? bytes.Length : size);
        }

        private static void writeBytes(
          string path,
          byte[] bytes,
          int size)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                fileStream.Write(bytes, 0, size);
                fileStream.SetLength(size);
            }
        }

        public static Block ReadBlock(string path, byte step)
        {
            byte[] contents = readBytes(path);
            if (contents == null)
                return null;
            return new Block(step, contents);
        }

        private static byte[] readBytes(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                byte[] buffer = new byte[fileStream.Length];
                if (fileStream.Read(buffer, 0, buffer.Length) != buffer.Length)
                {
                    Rocket.Core.Logging.Logger.LogError($"Error: Failed to read the correct file size in {System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.Functions.readBytes(string, FileMode, FileAcess, FileShare), returning null"); ;
                    return null;
                }
                return buffer;
            }
        }

        private static Block UniteBlocks(Block blockAdd, string path)
        {
            byte[] buffer = blockAdd.getBytes(out int size);
            blockAdd.block = new byte[size];
            for (ushort i = 0; i < size; i++)
                blockAdd.block[i] = buffer[i];

            Block blockExist = ReadBlock(path, 0);
            ushort blockCount = 0;
            byte[] contents = new byte[(blockExist.block.Length + blockAdd.block.Length)];
            if (blockExist.block.Length != 0)
                blockCount = (ushort)(blockExist.readByte() + (256 * blockExist.readByte()));
            else
                contents = new byte[2 + (blockExist.block.Length + blockAdd.block.Length)];



            byte multiplier = (byte)System.Math.Floor((blockCount + 1) / 256.0);

            contents[0] = (byte)(++blockCount);
            contents[1] = multiplier;
            for (int i = 2; i < blockExist.block.Length; i++)
                contents[i] = blockExist.block[i];

            if (blockExist.block.Length != 0)
                for (int i = 0; i < blockAdd.block.Length; i++)
                    contents[i + blockExist.block.Length] = blockAdd.block[i];
            else
                for (int i = 0; i < blockAdd.block.Length; i++)
                    contents[i + 2] = blockAdd.block[i];

            return new Block(0, contents);
        }

        public static void WriteItem(Item item, string pathHeap)//to heap
        {
            Block block = new Block();
            block.writeUInt16(item.id);
            block.writeByte(item.amount);
            block.writeByte(item.quality);
            block.writeUInt16((ushort)item.state.Length);
            foreach (byte bite in item.state)
                block.writeByte(bite);

            WriteBlock(pathHeap, UniteBlocks(block, pathHeap), true);
        }

        public static (List<List<MyItem>>, byte) GetMyItems(Block block)
        {
            List<List<MyItem>> wfuiheuihwui = new List<List<MyItem>>();
            List<MyItem> f3u2ghf7ug3igu = new List<MyItem>();
            ushort rfbhiybf783g7 = (ushort)(block.readByte() + (256 * block.readByte()));
            //System.Console.WriteLine($"itemsCount: {itemsCount}");
            for (ushort i = 0; i < rfbhiybf783g7; i++)
            {
                ushort werjniorng = block.readUInt16();
                byte whefubp4ub = block.readByte();
                byte bh2fubf82 = block.readByte();
                ushort jwef834jhf34 = block.readUInt16();
                byte[] ehr8fherp89fh = new byte[jwef834jhf34];
                for (ushort j = 0; j < jwef834jhf34; j++)
                    ehr8fherp89fh[j] = block.readByte();
                MyItem hf29p834hf9p4 = new MyItem(werjniorng, whefubp4ub, bh2fubf82, ehr8fherp89fh);
                //System.Console.WriteLine($"myItem: {id}");
                if (Plugin.Instance.HasItem(hf29p834hf9p4, f3u2ghf7ug3igu))
                    continue;
                else
                    f3u2ghf7ug3igu.Add(hf29p834hf9p4);
            }
            //System.Console.WriteLine($"myItems count: {myItems.Count}");
            byte pagesCount = (byte)System.Math.Ceiling(f3u2ghf7ug3igu.Count / 24.0);
            //System.Console.WriteLine($"pagesCount: {pagesCount}");
            byte counter = 0;
            for (byte i = 0; i < pagesCount; i++)
            {
                List<MyItem> items = new List<MyItem>();
                for (ushort j = 0; j < 24 && counter++ < f3u2ghf7ug3igu.Count; j++)
                    items.Add(f3u2ghf7ug3igu[j]);
                wfuiheuihwui.Add(items);
                //System.Console.WriteLine($"items: {items.Count}");
            }

            return (wfuiheuihwui, pagesCount);
        }
    }
}
