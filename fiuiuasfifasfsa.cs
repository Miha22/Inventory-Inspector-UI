using SDG.Unturned;
using System.IO;
using System.Collections.Generic;

namespace ItemRestrictorAdvanced
{
    class fiuiuasfifasfsa
    {
        public static void gu1h3a4pu34haass1gdan(string gu1h3a4pua34has1gdan, Block gu1h3a4pu34has1gdanas, bool gu1h3a4pu34ashas1gdan)
        {
            int gu1ha3a4pu34has1gdan = 0;
            byte[] gu1h3a4pu3as4has1gdan = gu1h3a4pu34ashas1gdan ? gu1h3a4pu34has1gdanas.block : gu1h3a4pu34has1gdanas.getBytes(out gu1ha3a4pu34has1gdan);
            gu1h3a4pu34has1g(gu1h3a4pua34has1gdan, gu1h3a4pu3as4has1gdan, gu1h3a4pu34ashas1gdan ? gu1h3a4pu3as4has1gdan.Length : gu1ha3a4pu34has1gdan);
        }

        private static void gu1h3a4pu34has1g(
          string gu1h3a4pu3a4has1gdan,
          byte[] gu1h3a4pu34has1gd,
          int gu1h3a4pu34has1g)
        {
            using (FileStream gu1h3a4pu34has1gdan = new FileStream(gu1h3a4pu3a4has1gdan, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                gu1h3a4pu34has1gdan.Write(gu1h3a4pu34has1gd, 0, gu1h3a4pu34has1g);
                gu1h3a4pu34has1gdan.SetLength(gu1h3a4pu34has1g);
            }
        }

        public static Block gu1h3a4pu34h1gdan(string path, byte gu1h34pu314h1gdan)
        {
            byte[] gu1h34pu34h1gdan = gu1h34puh8asg934h1gdan(path);
            if (gu1h34pu34h1gdan == null)
                return null;
            return new Block(gu1h34pu314h1gdan, gu1h34pu34h1gdan);
        }

        private static byte[] gu1h34puh8asg934h1gdan(string gu1h34puh8gas934h1gdan)
        {
            using (FileStream gu1h34puh8asg934h1gdan = new FileStream(gu1h34puh8gas934h1gdan, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                byte[] gu1h34puasdh8g934h1gdan = new byte[gu1h34puh8asg934h1gdan.Length];
                if (gu1h34puh8asg934h1gdan.Read(gu1h34puasdh8g934h1gdan, 0, gu1h34puasdh8g934h1gdan.Length) != gu1h34puasdh8g934h1gdan.Length)
                {
                    Rocket.Core.Logging.Logger.LogError($"Error: Failed to read the correct file size in {System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.Functions.readBytes(string, FileMode, FileAcess, FileShare), returning null"); ;
                    return null;
                }
                return gu1h34puasdh8g934h1gdan;
            }
        }

        private static Block gu1h34puh8g934h1gdan(Block gu1h34puh8g934h1gasdd, string gu1asdh34puh8g934h1gd)
        {
            byte[] gu1h34puh8g934h1gd1 = gu1h34puh8g934h1gasdd.getBytes(out int size);
            gu1h34puh8g934h1gasdd.block = new byte[size];
            for (ushort i = 0; i < size; i++)
                gu1h34puh8g934h1gasdd.block[i] = gu1h34puh8g934h1gd1[i];

            Block gu1h34puh8g934h1gdan = gu1h3a4pu34h1gdan(gu1asdh34puh8g934h1gd, 0);
            ushort gu1h34pu2h8g934h1gd = 0;
            byte[] gu1h34pnh8g934h1gd = new byte[(gu1h34puh8g934h1gdan.block.Length + gu1h34puh8g934h1gasdd.block.Length)];
            if (gu1h34puh8g934h1gdan.block.Length != 0)
                gu1h34pu2h8g934h1gd = (ushort)(gu1h34puh8g934h1gdan.readByte() + (256 * gu1h34puh8g934h1gdan.readByte()));
            else
                gu1h34pnh8g934h1gd = new byte[2 + (gu1h34puh8g934h1gdan.block.Length + gu1h34puh8g934h1gasdd.block.Length)];



            byte gu1h34puh8g93423h1gd = (byte)System.Math.Floor((gu1h34pu2h8g934h1gd + 1) / 256.0);

            gu1h34pnh8g934h1gd[0] = (byte)(++gu1h34pu2h8g934h1gd);
            gu1h34pnh8g934h1gd[1] = gu1h34puh8g93423h1gd;
            for (int i = 2; i < gu1h34puh8g934h1gdan.block.Length; i++)
                gu1h34pnh8g934h1gd[i] = gu1h34puh8g934h1gdan.block[i];

            if (gu1h34puh8g934h1gdan.block.Length != 0)
                for (int i = 0; i < gu1h34puh8g934h1gasdd.block.Length; i++)
                    gu1h34pnh8g934h1gd[i + gu1h34puh8g934h1gdan.block.Length] = gu1h34puh8g934h1gasdd.block[i];
            else
                for (int i = 0; i < gu1h34puh8g934h1gasdd.block.Length; i++)
                    gu1h34pnh8g934h1gd[i + 2] = gu1h34puh8g934h1gasdd.block[i];

            return new Block(0, gu1h34pnh8g934h1gd);
        }

        public static void WriteItem(Item gu1h34puh8g934h1gd, string gu1h34puha8g934h1gd)//to heap
        {
            Block gu1h34puhBg934h1gd = new Block();
            gu1h34puhBg934h1gd.writeUInt16(gu1h34puh8g934h1gd.id);
            gu1h34puhBg934h1gd.writeByte(gu1h34puh8g934h1gd.amount);
            gu1h34puhBg934h1gd.writeByte(gu1h34puh8g934h1gd.quality);
            gu1h34puhBg934h1gd.writeUInt16((ushort)gu1h34puh8g934h1gd.state.Length);
            foreach (byte bite in gu1h34puh8g934h1gd.state)
                gu1h34puhBg934h1gd.writeByte(bite);

            gu1h3a4pu34haass1gdan(gu1h34puha8g934h1gd, gu1h34puh8g934h1gdan(gu1h34puhBg934h1gd, gu1h34puha8g934h1gd), true);
        }

        public static (List<List<MyItem>>, byte) gu1h34puh8g934h1gd(Block fh3f44qnrugiqb5pb)
        {
            List<List<MyItem>> fh3f44qnrugiqbx5pb = new List<List<MyItem>>();
            List<MyItem> fh3f44qnrugiqqb5pb = new List<MyItem>();
            ushort rfbhiybf783g7 = (ushort)(fh3f44qnrugiqb5pb.readByte() + (256 * fh3f44qnrugiqb5pb.readByte()));
            //System.Console.WriteLine($"itemsCount: {itemsCount}");
            for (ushort i = 0; i < rfbhiybf783g7; i++)
            {
                ushort fh3f44qnrugiqvb5pb = fh3f44qnrugiqb5pb.readUInt16();
                byte fh3f44qnrdfugiqb5pb = fh3f44qnrugiqb5pb.readByte();
                byte fh3f44qnrfdugiqb5pb = fh3f44qnrugiqb5pb.readByte();
                ushort fh3f44qnrasugiqb5pb = fh3f44qnrugiqb5pb.readUInt16();
                byte[] fh3f44qn5rugiqb5pb = new byte[fh3f44qnrasugiqb5pb];
                for (ushort j = 0; j < fh3f44qnrasugiqb5pb; j++)
                    fh3f44qn5rugiqb5pb[j] = fh3f44qnrugiqb5pb.readByte();
                MyItem fh3f44qnrcugiqb5pb = new MyItem(fh3f44qnrugiqvb5pb, fh3f44qnrdfugiqb5pb, fh3f44qnrfdugiqb5pb, fh3f44qn5rugiqb5pb);
                //System.Console.WriteLine($"myItem: {id}");
                if (Plugin.Instance.HasItem(fh3f44qnrcugiqb5pb, fh3f44qnrugiqqb5pb))
                    continue;
                else
                    fh3f44qnrugiqqb5pb.Add(fh3f44qnrcugiqb5pb);
            }
            //System.Console.WriteLine($"myItems count: {myItems.Count}");
            byte fh34qnrugiqb5pb = (byte)System.Math.Ceiling(fh3f44qnrugiqqb5pb.Count / 24.0);
            //System.Console.WriteLine($"pagesCount: {pagesCount}");
            byte qrufburbfi5 = 0;
            for (byte i = 0; i < fh34qnrugiqb5pb; i++)
            {
                List<MyItem> q4fub4ub = new List<MyItem>();
                for (ushort j = 0; j < 24 && qrufburbfi5++ < fh3f44qnrugiqqb5pb.Count; j++)
                    q4fub4ub.Add(fh3f44qnrugiqqb5pb[j]);
                fh3f44qnrugiqbx5pb.Add(q4fub4ub);
                //System.Console.WriteLine($"items: {items.Count}");
            }

            return (fh3f44qnrugiqbx5pb, fh34qnrugiqb5pb);
        }
    }
}
