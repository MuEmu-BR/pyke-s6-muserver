using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MU_ToolKit
{
	// Token: 0x0200000C RID: 12
	public class Structures
	{
		// Token: 0x060003A4 RID: 932 RVA: 0x000172C8 File Offset: 0x000154C8
		private bool CheckAndFixLine(string theLine, out string[] fixedLine)
		{
			string text = theLine.Replace(" ", string.Empty).Replace("\t", string.Empty);
			if (!text.StartsWith("/") && !text.StartsWith("end") && text.Length > 0)
			{
				List<string> list = new List<string>();
				string text2 = theLine;
				int num = 0;
				List<int> list2 = new List<int>();
				foreach (char c in theLine)
				{
					if (c == '"')
					{
						list2.Add(num);
					}
					num++;
				}
				for (int j = 0; j < list2.Count; j += 2)
				{
					try
					{
						string text3 = theLine.Substring(list2[j], list2[j + 1] - list2[j]);
						string newValue = text3.Replace("\t", " ").Replace(" ", "^");
						text2 = text2.Replace(text3, newValue);
					}
					catch
					{
					}
				}
				string[] array = text2.Replace(" ", "\t").Split(new char[]
				{
					'\t'
				});
				for (int k = 0; k < array.Length; k++)
				{
					if (array[k].Replace(" ", string.Empty).Length > 0)
					{
						list.Add(array[k].Replace("^", " "));
					}
				}
				fixedLine = list.ToArray();
				return true;
			}
			fixedLine = null;
			return false;
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00017464 File Offset: 0x00015664
		public string[] FixLine(string theLine)
		{
			string text = string.Empty;
			text = theLine;
			string[] array = theLine.Split(new char[]
			{
				'"'
			});
			if (array.Length == 3)
			{
				string str = array[0];
				string text2 = array[1];
				string str2 = array[2];
				text2 = text2.Replace('\t', ' ').Replace(' ', '$');
				text = str + text2 + str2;
			}
			array = text.Replace(' ', '\t').Split(new char[]
			{
				'\t'
			});
			List<string> list = new List<string>();
			foreach (string text3 in array)
			{
				if (text3.Length > 0)
				{
					list.Add(text3);
				}
			}
			return list.ToArray();
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00017520 File Offset: 0x00015720
		public void initMapList(ref ComboBox lb, ref List<Structures.Map> mMapList)
		{
			Structures.Map item = new Structures.Map
			{
				MapCode = 0,
				MapName = "Lorencia"
			};
			mMapList.Add(item);
			item.MapCode = 1;
			item.MapName = "Dungeon";
			mMapList.Add(item);
			item.MapCode = 2;
			item.MapName = "Devias";
			mMapList.Add(item);
			item.MapCode = 3;
			item.MapName = "Noria";
			mMapList.Add(item);
			item.MapCode = 4;
			item.MapName = "Lost Tower";
			mMapList.Add(item);
			item.MapCode = 6;
			item.MapName = "Arena";
			mMapList.Add(item);
			item.MapCode = 7;
			item.MapName = "Atlans";
			mMapList.Add(item);
			item.MapCode = 8;
			item.MapName = "Tarkan";
			mMapList.Add(item);
			item.MapCode = 9;
			item.MapName = "Devil Square 1 - 4";
			mMapList.Add(item);
			item.MapCode = 32;
			item.MapName = "Devil Square 5 - 8";
			mMapList.Add(item);
			item.MapCode = 10;
			item.MapName = "Icarus";
			mMapList.Add(item);
			item.MapCode = 11;
			item.MapName = "Blood Castle 1";
			mMapList.Add(item);
			item.MapCode = 12;
			item.MapName = "Blood Castle 2";
			mMapList.Add(item);
			item.MapCode = 13;
			item.MapName = "Blood Castle 3";
			mMapList.Add(item);
			item.MapCode = 14;
			item.MapName = "Blood Castle 4";
			mMapList.Add(item);
			item.MapCode = 15;
			item.MapName = "Blood Castle 5";
			mMapList.Add(item);
			item.MapCode = 16;
			item.MapName = "Blood Castle 6";
			mMapList.Add(item);
			item.MapCode = 17;
			item.MapName = "Blood Castle 7";
			mMapList.Add(item);
			item.MapCode = 18;
			item.MapName = "Chaos Castle 1";
			mMapList.Add(item);
			item.MapCode = 19;
			item.MapName = "Chaos Castle 2";
			mMapList.Add(item);
			item.MapCode = 20;
			item.MapName = "Chaos Castle 3";
			mMapList.Add(item);
			item.MapCode = 21;
			item.MapName = "Chaos Castle 4";
			mMapList.Add(item);
			item.MapCode = 22;
			item.MapName = "Chaos Castle 5";
			mMapList.Add(item);
			item.MapCode = 23;
			item.MapName = "Chaos Castle 6";
			mMapList.Add(item);
			item.MapCode = 24;
			item.MapName = "Kalima 1";
			mMapList.Add(item);
			item.MapCode = 25;
			item.MapName = "Kalima 2";
			mMapList.Add(item);
			item.MapCode = 26;
			item.MapName = "Kalima 3";
			mMapList.Add(item);
			item.MapCode = 27;
			item.MapName = "Kalima 4";
			mMapList.Add(item);
			item.MapCode = 28;
			item.MapName = "Kalima 5";
			mMapList.Add(item);
			item.MapCode = 29;
			item.MapName = "Kalima 6";
			mMapList.Add(item);
			item.MapCode = 36;
			item.MapName = "Kalima 7";
			mMapList.Add(item);
			item.MapCode = 30;
			item.MapName = "Valley Of Loren";
			mMapList.Add(item);
			item.MapCode = 31;
			item.MapName = "Lands Of Trial";
			mMapList.Add(item);
			item.MapCode = 33;
			item.MapName = "Aida";
			mMapList.Add(item);
			item.MapCode = 34;
			item.MapName = "Cry Wolf";
			mMapList.Add(item);
			item.MapCode = 37;
			item.MapName = "Kantru";
			mMapList.Add(item);
			item.MapCode = 38;
			item.MapName = "Kantru Ruins";
			mMapList.Add(item);
			item.MapCode = 39;
			item.MapName = "Refinery Tower";
			mMapList.Add(item);
			item.MapCode = 40;
			item.MapName = "Silent Map";
			mMapList.Add(item);
			item.MapCode = 41;
			item.MapName = "Balgas Barracks";
			mMapList.Add(item);
			item.MapCode = 42;
			item.MapName = "Balgas Refuge";
			mMapList.Add(item);
			item.MapCode = 46;
			item.MapName = "Illusion Temple 1";
			mMapList.Add(item);
			item.MapCode = 47;
			item.MapName = "Illusion Temple 2";
			mMapList.Add(item);
			item.MapCode = 48;
			item.MapName = "Illusion Temple 3";
			mMapList.Add(item);
			item.MapCode = 49;
			item.MapName = "Illusion Temple 4";
			mMapList.Add(item);
			item.MapCode = 50;
			item.MapName = "Illusion Temple 5";
			mMapList.Add(item);
			item.MapCode = 51;
			item.MapName = "Elbeland";
			mMapList.Add(item);
			item.MapCode = 56;
			item.MapName = "Swamp Of Calmness";
			mMapList.Add(item);
			item.MapCode = 57;
			item.MapName = "Raklion";
			mMapList.Add(item);
			item.MapCode = 58;
			item.MapName = "Hatchery";
			mMapList.Add(item);
			item.MapCode = 62;
			item.MapName = "Santa Village";
			mMapList.Add(item);
			item.MapCode = 63;
			item.MapName = "Vulcanus";
			mMapList.Add(item);
			item.MapCode = 64;
			item.MapName = "Duel Arena";
			mMapList.Add(item);
			item.MapCode = 65;
			item.MapName = "DoppleGanger Snow";
			mMapList.Add(item);
			item.MapCode = 66;
			item.MapName = "DoppleGanger Volcan";
			mMapList.Add(item);
			item.MapCode = 67;
			item.MapName = "DoppleGanger Sea";
			mMapList.Add(item);
			item.MapCode = 68;
			item.MapName = "DoppleGanger Crystals";
			mMapList.Add(item);
			item.MapCode = 69;
			item.MapName = "Imperial Fortress 1";
			mMapList.Add(item);
			item.MapCode = 70;
			item.MapName = "Imperial Fortress 2";
			mMapList.Add(item);
			item.MapCode = 71;
			item.MapName = "Imperial Fortress 3";
			mMapList.Add(item);
			item.MapCode = 72;
			item.MapName = "Imperial Fortress 4";
			mMapList.Add(item);
			item.MapCode = 79;
			item.MapName = "Loren Market";
			mMapList.Add(item);
			item.MapCode = 80;
			item.MapName = "Karutan 1";
			mMapList.Add(item);
			item.MapCode = 81;
			item.MapName = "Karutan 2";
			mMapList.Add(item);
			item.MapCode = 91;
			item.MapName = "Acheron";
			mMapList.Add(item);
			item.MapCode = 92;
			item.MapName = "Arca War";
			mMapList.Add(item);
			item.MapCode = 93;
			item.MapName = "New Map 93";
			mMapList.Add(item);
			item.MapCode = 94;
			item.MapName = "New Map 94";
			mMapList.Add(item);
			lb.DataSource = mMapList;
			lb.ValueMember = "MapCode";
			lb.DisplayMember = "MapName";
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00017D04 File Offset: 0x00015F04
		public void initMapListBox(ref ListBox lb)
		{
			Structures.Map item = default(Structures.Map);
			List<Structures.Map> list = new List<Structures.Map>();
			item.MapCode = 0;
			item.MapName = "Lorencia";
			list.Add(item);
			item.MapCode = 1;
			item.MapName = "Dungeon";
			list.Add(item);
			item.MapCode = 2;
			item.MapName = "Devias";
			list.Add(item);
			item.MapCode = 3;
			item.MapName = "Noria";
			list.Add(item);
			item.MapCode = 4;
			item.MapName = "Lost Tower";
			list.Add(item);
			item.MapCode = 6;
			item.MapName = "Arena";
			list.Add(item);
			item.MapCode = 7;
			item.MapName = "Atlans";
			list.Add(item);
			item.MapCode = 8;
			item.MapName = "Tarkan";
			list.Add(item);
			item.MapCode = 9;
			item.MapName = "Devil Square 1 - 4";
			list.Add(item);
			item.MapCode = 32;
			item.MapName = "Devil Square 5 - 8";
			list.Add(item);
			item.MapCode = 10;
			item.MapName = "Icarus";
			list.Add(item);
			item.MapCode = 11;
			item.MapName = "Blood Castle 1";
			list.Add(item);
			item.MapCode = 12;
			item.MapName = "Blood Castle 2";
			list.Add(item);
			item.MapCode = 13;
			item.MapName = "Blood Castle 3";
			list.Add(item);
			item.MapCode = 14;
			item.MapName = "Blood Castle 4";
			list.Add(item);
			item.MapCode = 15;
			item.MapName = "Blood Castle 5";
			list.Add(item);
			item.MapCode = 16;
			item.MapName = "Blood Castle 6";
			list.Add(item);
			item.MapCode = 17;
			item.MapName = "Blood Castle 7";
			list.Add(item);
			item.MapCode = 18;
			item.MapName = "Chaos Castle 1";
			list.Add(item);
			item.MapCode = 19;
			item.MapName = "Chaos Castle 2";
			list.Add(item);
			item.MapCode = 20;
			item.MapName = "Chaos Castle 3";
			list.Add(item);
			item.MapCode = 21;
			item.MapName = "Chaos Castle 4";
			list.Add(item);
			item.MapCode = 22;
			item.MapName = "Chaos Castle 5";
			list.Add(item);
			item.MapCode = 23;
			item.MapName = "Chaos Castle 6";
			list.Add(item);
			item.MapCode = 24;
			item.MapName = "Kalima 1";
			list.Add(item);
			item.MapCode = 25;
			item.MapName = "Kalima 2";
			list.Add(item);
			item.MapCode = 26;
			item.MapName = "Kalima 3";
			list.Add(item);
			item.MapCode = 27;
			item.MapName = "Kalima 4";
			list.Add(item);
			item.MapCode = 28;
			item.MapName = "Kalima 5";
			list.Add(item);
			item.MapCode = 29;
			item.MapName = "Kalima 6";
			list.Add(item);
			item.MapCode = 36;
			item.MapName = "Kalima 7";
			list.Add(item);
			item.MapCode = 30;
			item.MapName = "Valley Of Loren";
			list.Add(item);
			item.MapCode = 31;
			item.MapName = "Lands Of Trial";
			list.Add(item);
			item.MapCode = 33;
			item.MapName = "Aida";
			list.Add(item);
			item.MapCode = 34;
			item.MapName = "Cry Wolf";
			list.Add(item);
			item.MapCode = 37;
			item.MapName = "Kantru";
			list.Add(item);
			item.MapCode = 38;
			item.MapName = "Kantru Ruins";
			list.Add(item);
			item.MapCode = 39;
			item.MapName = "Refinery Tower";
			list.Add(item);
			item.MapCode = 40;
			item.MapName = "Silent Map";
			list.Add(item);
			item.MapCode = 41;
			item.MapName = "Balgas Barracks";
			list.Add(item);
			item.MapCode = 42;
			item.MapName = "Balgas Refuge";
			list.Add(item);
			item.MapCode = 46;
			item.MapName = "Illusion Temple 1";
			list.Add(item);
			item.MapCode = 47;
			item.MapName = "Illusion Temple 2";
			list.Add(item);
			item.MapCode = 48;
			item.MapName = "Illusion Temple 3";
			list.Add(item);
			item.MapCode = 49;
			item.MapName = "Illusion Temple 4";
			list.Add(item);
			item.MapCode = 50;
			item.MapName = "Illusion Temple 5";
			list.Add(item);
			item.MapCode = 51;
			item.MapName = "Elbeland";
			list.Add(item);
			item.MapCode = 56;
			item.MapName = "Swamp Of Calmness";
			list.Add(item);
			item.MapCode = 57;
			item.MapName = "Raklion";
			list.Add(item);
			item.MapCode = 58;
			item.MapName = "Hatchery";
			list.Add(item);
			item.MapCode = 62;
			item.MapName = "Santa Village";
			list.Add(item);
			item.MapCode = 63;
			item.MapName = "Vulcanus";
			list.Add(item);
			item.MapCode = 64;
			item.MapName = "Duel Arena";
			list.Add(item);
			item.MapCode = 65;
			item.MapName = "DoppleGanger Snow";
			list.Add(item);
			item.MapCode = 66;
			item.MapName = "DoppleGanger Volcan";
			list.Add(item);
			item.MapCode = 67;
			item.MapName = "DoppleGanger Sea";
			list.Add(item);
			item.MapCode = 68;
			item.MapName = "DoppleGanger Crystals";
			list.Add(item);
			item.MapCode = 69;
			item.MapName = "Imperial Fortress 1";
			list.Add(item);
			item.MapCode = 70;
			item.MapName = "Imperial Fortress 2";
			list.Add(item);
			item.MapCode = 71;
			item.MapName = "Imperial Fortress 3";
			list.Add(item);
			item.MapCode = 72;
			item.MapName = "Imperial Fortress 4";
			list.Add(item);
			item.MapCode = 79;
			item.MapName = "Loren Market";
			list.Add(item);
			item.MapCode = 80;
			item.MapName = "Karutan 1";
			list.Add(item);
			item.MapCode = 81;
			item.MapName = "Karutan 2";
			list.Add(item);
			item.MapCode = 91;
			item.MapName = "Acheron";
			list.Add(item);
			item.MapCode = 92;
			item.MapName = "Arca War";
			list.Add(item);
			item.MapCode = 93;
			item.MapName = "New Map 93";
			list.Add(item);
			item.MapCode = 94;
			item.MapName = "New Map 94";
			list.Add(item);
			lb.DataSource = list;
			lb.ValueMember = "MapCode";
			lb.DisplayMember = "MapName";
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x000184A8 File Offset: 0x000166A8
		public void initMapListBox(ref ListBox lb, ref string[] MapName)
		{
			Structures.Map item = default(Structures.Map);
			List<Structures.Map> list = new List<Structures.Map>();
			item.MapCode = 0;
			item.MapName = "Lorencia";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 1;
			item.MapName = "Dungeon";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 2;
			item.MapName = "Devias";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 3;
			item.MapName = "Noria";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 4;
			item.MapName = "Lost Tower";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 6;
			item.MapName = "Arena";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 7;
			item.MapName = "Atlans";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 8;
			item.MapName = "Tarkan";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 9;
			item.MapName = "Devil Square 1 - 4";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 32;
			item.MapName = "Devil Square 5 - 8";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 10;
			item.MapName = "Icarus";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 11;
			item.MapName = "Blood Castle 1";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 12;
			item.MapName = "Blood Castle 2";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 13;
			item.MapName = "Blood Castle 3";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 14;
			item.MapName = "Blood Castle 4";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 15;
			item.MapName = "Blood Castle 5";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 16;
			item.MapName = "Blood Castle 6";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 17;
			item.MapName = "Blood Castle 7";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 18;
			item.MapName = "Chaos Castle 1";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 19;
			item.MapName = "Chaos Castle 2";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 20;
			item.MapName = "Chaos Castle 3";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 21;
			item.MapName = "Chaos Castle 4";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 22;
			item.MapName = "Chaos Castle 5";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 23;
			item.MapName = "Chaos Castle 6";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 24;
			item.MapName = "Kalima 1";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 25;
			item.MapName = "Kalima 2";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 26;
			item.MapName = "Kalima 3";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 27;
			item.MapName = "Kalima 4";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 28;
			item.MapName = "Kalima 5";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 29;
			item.MapName = "Kalima 6";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 36;
			item.MapName = "Kalima 7";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 30;
			item.MapName = "Valley Of Loren";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 31;
			item.MapName = "Lands Of Trial";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 33;
			item.MapName = "Aida";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 34;
			item.MapName = "Cry Wolf";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 37;
			item.MapName = "Kantru";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 38;
			item.MapName = "Kantru Ruins";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 39;
			item.MapName = "Refinery Tower";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 40;
			item.MapName = "Silent Map";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 41;
			item.MapName = "Balgas Barracks";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 42;
			item.MapName = "Balgas Refuge";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 46;
			item.MapName = "Illusion Temple 1";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 47;
			item.MapName = "Illusion Temple 2";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 48;
			item.MapName = "Illusion Temple 3";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 49;
			item.MapName = "Illusion Temple 4";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 50;
			item.MapName = "Illusion Temple 5";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 51;
			item.MapName = "Elbeland";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 56;
			item.MapName = "Swamp Of Calmness";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 57;
			item.MapName = "Raklion";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 58;
			item.MapName = "Hatchery";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 62;
			item.MapName = "Santa Village";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 63;
			item.MapName = "Vulcanus";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 64;
			item.MapName = "Duel Arena";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 65;
			item.MapName = "DoppleGanger Snow";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 66;
			item.MapName = "DoppleGanger Volcan";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 67;
			item.MapName = "DoppleGanger Sea";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 68;
			item.MapName = "DoppleGanger Crystals";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 69;
			item.MapName = "Imperial Fortress 1";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 70;
			item.MapName = "Imperial Fortress 2";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 71;
			item.MapName = "Imperial Fortress 3";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 72;
			item.MapName = "Imperial Fortress 4";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 79;
			item.MapName = "Loren Market";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 80;
			item.MapName = "Karutan 1";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 81;
			item.MapName = "Karutan 2";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 91;
			item.MapName = "Acheron";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 92;
			item.MapName = "Arca War";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 93;
			item.MapName = "New Map 93";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			item.MapCode = 94;
			item.MapName = "New Map 94";
			MapName[item.MapCode] = item.MapName;
			list.Add(item);
			lb.DataSource = list;
			lb.ValueMember = "MapCode";
			lb.DisplayMember = "MapName";
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x000190D0 File Offset: 0x000172D0
		public void ReadEventBagFile(string fLocation, ref BindingList<Structures.EventBagMap> mapList, ref Structures.EventBagDrop drop, ref BindingList<Structures.EventBagItem> BagItems, string[,] ItemName, string[] MapName)
		{
			string[] array = File.ReadAllLines(fLocation);
			int num = 0;
			foreach (string text in array)
			{
				if (!text.ToLower().Replace("\t", "").Trim().StartsWith("end") & !text.ToUpper().Replace("\t", "").Trim().StartsWith("/") & text.ToUpper().Replace("\t", "").Trim().Length != 0)
				{
					if (text.ToUpper().Replace("\t", "").Trim().Length > 1)
					{
						string text2 = string.Empty;
						text2 = text;
						string[] array3 = text.Split(new char[]
						{
							'"'
						});
						if (array3.Length == 3)
						{
							array3[1] = array3[1].Replace("\t", " ").Replace(" ", "$");
							text2 = array3[0] + array3[1] + array3[2];
						}
						string[] array4 = text2.Replace(" ", "\t").Split(new char[]
						{
							'\t'
						});
						List<string> list = new List<string>();
						for (int j = 0; j < array4.Length; j++)
						{
							if (array4[j].Trim().Length != 0)
							{
								list.Add(array4[j]);
							}
						}
						array4 = list.ToArray();
						switch (num)
						{
						case 0:
						{
							if (array4.Length < 4)
							{
								MessageBox.Show("\tInvalid line", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								return;
							}
							Structures.EventBagMap item = default(Structures.EventBagMap);
							item.ID = Convert.ToInt32(array4[0]);
							item.Drop = Convert.ToBoolean(Convert.ToInt32(array4[1]));
							item.MobMinLvl = Convert.ToInt32(array4[2]);
							item.MobMaxLvl = Convert.ToInt32(array4[3]);
							item.Name = MapName[item.ID];
							mapList.Add(item);
							break;
						}
						case 1:
							if (array4.Length < 8)
							{
								MessageBox.Show("\tInvalid line", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								return;
							}
							drop.Name = array4[0].Replace("\"", "");
							drop.Zen = Convert.ToInt32(array4[1]);
							drop.BagGroup = Convert.ToInt32(array4[2]);
							drop.BagIndex = Convert.ToInt32(array4[3]);
							drop.BagLevel = Convert.ToInt32(array4[4]);
							drop.BagDropRate = (double)Convert.ToInt32(array4[5]);
							drop.ItemDropRate = (double)Convert.ToInt32(array4[6]);
							drop.ExcDropRate = (double)Convert.ToInt32(array4[7]);
							break;
						case 2:
						{
							if (array4.Length < 8)
							{
								MessageBox.Show("\tInvalid line", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								return;
							}
							Structures.EventBagItem item2 = default(Structures.EventBagItem);
							item2.Group = Convert.ToInt32(array4[0]);
							item2.Index = Convert.ToInt32(array4[1]);
							item2.MinLevel = Convert.ToInt32(array4[2]);
							item2.MaxLevel = Convert.ToInt32(array4[3]);
							item2.Skill = Convert.ToBoolean(Convert.ToInt32(array4[4]));
							item2.Luck = Convert.ToBoolean(Convert.ToInt32(array4[5]));
							item2.Option = Convert.ToBoolean(Convert.ToInt32(array4[6]));
							item2.Excellent = Convert.ToBoolean(Convert.ToInt32(array4[7]));
							item2.Name = ItemName[item2.Group, item2.Index];
							BagItems.Add(item2);
							break;
						}
						}
					}
					else
					{
						num = (int)Convert.ToInt16(text);
					}
				}
			}
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00019494 File Offset: 0x00017694
		public void ReadItemList(string fLocation, bool isEx700ItemList, ref List<Structures.c_Groups> L_Groups, ref List<Structures.UniItem> L_Swords, ref List<Structures.UniItem> L_Axes, ref List<Structures.UniItem> L_MacesScepters, ref List<Structures.UniItem> L_Spears, ref List<Structures.UniItem> L_BowsCrossBows, ref List<Structures.UniItem> L_Staffs, ref List<Structures.UniItem> L_Shields, ref List<Structures.UniItem> L_Helms, ref List<Structures.UniItem> L_Armors, ref List<Structures.UniItem> L_Pants, ref List<Structures.UniItem> L_Gloves, ref List<Structures.UniItem> L_Boots, ref List<Structures.UniItem> L_WingsSkillsSeedsOther, ref List<Structures.UniItem> L_Others1, ref List<Structures.UniItem> L_Others2, ref List<Structures.UniItem> L_Scrolls, ref string[,] ItemName, ref string[,] ItemSize)
		{
			try
			{
				int group = 0;
				foreach (string theLine in File.ReadAllLines(fLocation))
				{
					string[] array2;
					if (this.CheckAndFixLine(theLine, out array2))
					{
						if (array2.Length == 1)
						{
							group = Convert.ToInt32(array2[0]);
							switch (group)
							{
							case 0:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Swords"));
								group = 0;
								break;
							case 1:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Axes"));
								group = 1;
								break;
							case 2:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Maces/Scepters"));
								group = 2;
								break;
							case 3:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Spears"));
								group = 3;
								break;
							case 4:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Bow/CrossBow"));
								group = 4;
								break;
							case 5:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Staffs"));
								group = 5;
								break;
							case 6:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Shield"));
								group = 6;
								break;
							case 7:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Helms"));
								group = 7;
								break;
							case 8:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Armors"));
								group = 8;
								break;
							case 9:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Pants"));
								group = 9;
								break;
							case 10:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Gloves"));
								group = 10;
								break;
							case 11:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Boots"));
								group = 11;
								break;
							case 12:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Wings/Orbs/Spheres"));
								group = 12;
								break;
							case 13:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Pets/Rings/Etc"));
								group = 13;
								break;
							case 14:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Jewels/Misc"));
								group = 14;
								break;
							case 15:
								L_Groups.Add(new Structures.c_Groups(group.ToString(), "Scrolls"));
								group = 15;
								break;
							}
						}
						else
						{
							int num = 0;
							if (isEx700ItemList)
							{
								num = 3;
							}
							string[] array3 = array2;
							Structures.UniItem item = new Structures.UniItem
							{
								Group = group,
								Index = Convert.ToInt32(array3[num]),
								Slot = Convert.ToInt32(array3[num + 1]),
								Skill = Convert.ToInt32(array3[num + 2]),
								X = Convert.ToInt32(array3[num + 3]),
								Y = Convert.ToInt32(array3[num + 4]),
								Option = Convert.ToInt32(array3[num + 6]),
								Name = array3[num + 8].Replace("\"", string.Empty)
							};
							switch (group)
							{
							case 0:
								item.Durability = (int)Convert.ToInt16(array3[num + 13]);
								item.Ancient = (int)Convert.ToInt16(array3[num + 22]);
								L_Swords.Add(item);
								break;
							case 1:
								item.Durability = (int)Convert.ToInt16(array3[num + 13]);
								item.Ancient = (int)Convert.ToInt16(array3[num + 22]);
								L_Axes.Add(item);
								break;
							case 2:
								item.Durability = (int)Convert.ToInt16(array3[num + 13]);
								item.Ancient = (int)Convert.ToInt16(array3[num + 22]);
								L_MacesScepters.Add(item);
								break;
							case 3:
								item.Durability = (int)Convert.ToInt16(array3[num + 13]);
								item.Ancient = (int)Convert.ToInt16(array3[num + 22]);
								L_Spears.Add(item);
								break;
							case 4:
								item.Durability = (int)Convert.ToInt16(array3[num + 13]);
								item.Ancient = (int)Convert.ToInt16(array3[num + 22]);
								L_BowsCrossBows.Add(item);
								break;
							case 5:
								item.Durability = (int)Convert.ToInt16(array3[num + 13]);
								item.Ancient = (int)Convert.ToInt16(array3[num + 22]);
								L_Staffs.Add(item);
								break;
							case 6:
								item.Durability = (int)Convert.ToInt16(array3[num + 12]);
								item.Ancient = (int)Convert.ToInt16(array3[num + 19]);
								L_Shields.Add(item);
								break;
							case 7:
								item.Durability = (int)Convert.ToInt16(array3[num + 12]);
								item.Ancient = (int)Convert.ToInt16(array3[num + 19]);
								L_Helms.Add(item);
								break;
							case 8:
								item.Durability = (int)Convert.ToInt16(array3[num + 12]);
								item.Ancient = (int)Convert.ToInt16(array3[num + 19]);
								L_Armors.Add(item);
								break;
							case 9:
								item.Durability = (int)Convert.ToInt16(array3[num + 12]);
								item.Ancient = (int)Convert.ToInt16(array3[num + 19]);
								L_Pants.Add(item);
								break;
							case 10:
								item.Durability = (int)Convert.ToInt16(array3[num + 12]);
								item.Ancient = (int)Convert.ToInt16(array3[num + 19]);
								L_Gloves.Add(item);
								break;
							case 11:
								item.Durability = (int)Convert.ToInt16(array3[num + 12]);
								item.Ancient = (int)Convert.ToInt16(array3[num + 19]);
								L_Boots.Add(item);
								break;
							case 12:
								item.Durability = (int)Convert.ToInt16(array3[num + 12]);
								item.Ancient = 0;
								L_WingsSkillsSeedsOther.Add(item);
								break;
							case 13:
								item.Durability = (int)Convert.ToInt16(array3[num + 11]);
								item.Ancient = 0;
								L_Others1.Add(item);
								break;
							case 14:
								item.Durability = 0;
								item.Ancient = 0;
								L_Others2.Add(item);
								break;
							case 15:
								item.Durability = 0;
								item.Ancient = 0;
								L_Scrolls.Add(item);
								break;
							}
							if (ItemName != null)
							{
								ItemName[item.Group, item.Index] = item.Name;
							}
							if (ItemSize != null)
							{
								ItemSize[item.Group, item.Index] = item.X + "x" + item.Y;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "[ReadItemList] ERROR");
				Application.Exit();
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00019BBC File Offset: 0x00017DBC
		public void ReadXMLEventBagFile(string fLocation, ref Structures.EventBagDrop drop, ref BindingList<Structures.EventBagItem> BagItems, string[,] ItemName)
		{
			foreach (XElement xelement in XDocument.Load(fLocation).Root.Elements())
			{
				string localName = xelement.Name.LocalName;
				if (localName != null)
				{
					if (!(localName == "Bag"))
					{
						if (!(localName == "Default"))
						{
							if (localName == "Items")
							{
								goto IL_343;
							}
							continue;
						}
					}
					else
					{
						using (IEnumerator<XElement> enumerator2 = xelement.Elements().GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								XElement xelement2 = enumerator2.Current;
								foreach (XAttribute xattribute in xelement2.Attributes())
								{
									string localName2 = xattribute.Name.LocalName;
									if (localName2 != null)
									{
										if (!(localName2 == "Name"))
										{
											if (!(localName2 == "ZenDrop"))
											{
												if (!(localName2 == "ItemRate"))
												{
													if (!(localName2 == "ExcRate"))
													{
														if (!(localName2 == "AncientRate"))
														{
															if (localName2 == "SocketRate")
															{
																drop.SocketDropRate = Convert.ToDouble(xattribute.Value);
															}
														}
														else
														{
															drop.AncDropRate = Convert.ToDouble(xattribute.Value);
														}
													}
													else
													{
														drop.ExcDropRate = Convert.ToDouble(xattribute.Value);
													}
												}
												else
												{
													drop.ItemDropRate = Convert.ToDouble(xattribute.Value);
												}
											}
											else
											{
												drop.Zen = Convert.ToInt32(xattribute.Value);
											}
										}
										else
										{
											drop.Name = xattribute.Value;
										}
									}
								}
							}
							continue;
						}
					}
					using (IEnumerator<XElement> enumerator4 = xelement.Elements().GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							XElement xelement3 = enumerator4.Current;
							drop.Default_Cat = Convert.ToInt32(xelement3.Attribute("cat").Value);
							drop.Default_ID = Convert.ToInt32(xelement3.Attribute("id").Value);
							drop.Default_minlv = Convert.ToInt32(xelement3.Attribute("minlv").Value);
							drop.Default_maxlv = Convert.ToInt32(xelement3.Attribute("maxlv").Value);
							drop.Default_skill = Convert.ToBoolean(Convert.ToInt32(xelement3.Attribute("skill").Value));
							drop.Default_luck = Convert.ToBoolean(Convert.ToInt32(xelement3.Attribute("luck").Value));
							drop.Default_addopt = Convert.ToInt32(xelement3.Attribute("addopt").Value);
							drop.Default_exc = Convert.ToBoolean(Convert.ToInt32(xelement3.Attribute("exc").Value));
							drop.Default_anc = Convert.ToBoolean(Convert.ToInt32(xelement3.Attribute("anc").Value));
							drop.Default_sock = Convert.ToBoolean(Convert.ToInt32(xelement3.Attribute("sock").Value));
						}
						continue;
					}
					IL_343:
					foreach (XElement xelement4 in xelement.Elements())
					{
						Structures.EventBagItem item = new Structures.EventBagItem
						{
							Group = Convert.ToInt32(xelement4.Attribute("cat").Value),
							Index = Convert.ToInt32(xelement4.Attribute("id").Value),
							MinLevel = Convert.ToInt32(xelement4.Attribute("minlv").Value),
							MaxLevel = Convert.ToInt32(xelement4.Attribute("maxlv").Value),
							Skill = Convert.ToBoolean(Convert.ToInt32(xelement4.Attribute("skill").Value)),
							Luck = Convert.ToBoolean(Convert.ToInt32(xelement4.Attribute("luck").Value)),
							new_MaxOption = Convert.ToInt32(xelement4.Attribute("addopt").Value),
							Excellent = Convert.ToBoolean(Convert.ToInt32(xelement4.Attribute("exc").Value)),
							Ancient = Convert.ToBoolean(Convert.ToInt32(xelement4.Attribute("anc").Value)),
							Socket = Convert.ToBoolean(Convert.ToInt32(xelement4.Attribute("sock").Value))
						};
						item.Name = ItemName[item.Group, item.Index];
						BagItems.Add(item);
					}
				}
			}
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0001A178 File Offset: 0x00018378
		public void Setc_LevelData(ref List<Structures.c_LevelData> c_LevelDatas)
		{
			c_LevelDatas.Add(new Structures.c_LevelData(0, "+0"));
			c_LevelDatas.Add(new Structures.c_LevelData(1, "+1"));
			c_LevelDatas.Add(new Structures.c_LevelData(2, "+2"));
			c_LevelDatas.Add(new Structures.c_LevelData(3, "+3"));
			c_LevelDatas.Add(new Structures.c_LevelData(4, "+4"));
			c_LevelDatas.Add(new Structures.c_LevelData(5, "+5"));
			c_LevelDatas.Add(new Structures.c_LevelData(6, "+6"));
			c_LevelDatas.Add(new Structures.c_LevelData(7, "+7"));
			c_LevelDatas.Add(new Structures.c_LevelData(8, "+8"));
			c_LevelDatas.Add(new Structures.c_LevelData(9, "+9"));
			c_LevelDatas.Add(new Structures.c_LevelData(10, "+10"));
			c_LevelDatas.Add(new Structures.c_LevelData(11, "+11"));
			c_LevelDatas.Add(new Structures.c_LevelData(12, "+12"));
			c_LevelDatas.Add(new Structures.c_LevelData(13, "+13"));
			c_LevelDatas.Add(new Structures.c_LevelData(14, "+14"));
			c_LevelDatas.Add(new Structures.c_LevelData(15, "+15"));
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0001A2AC File Offset: 0x000184AC
		public void Setc_OptionData(ref List<Structures.c_OptionData> c_OptionDatas)
		{
			Structures.c_OptionData item = new Structures.c_OptionData
			{
				ID = 0,
				Name = "+0"
			};
			c_OptionDatas.Add(item);
			item.ID = 1;
			item.Name = "+4";
			c_OptionDatas.Add(item);
			item.ID = 2;
			item.Name = "+8";
			c_OptionDatas.Add(item);
			item.ID = 3;
			item.Name = "+12";
			c_OptionDatas.Add(item);
			item.ID = 4;
			item.Name = "+16";
			c_OptionDatas.Add(item);
			item.ID = 5;
			item.Name = "+20";
			c_OptionDatas.Add(item);
			item.ID = 6;
			item.Name = "+24";
			c_OptionDatas.Add(item);
			item.ID = 7;
			item.Name = "+28";
			c_OptionDatas.Add(item);
		}

		// Token: 0x0200000D RID: 13
		public class c_AncientData
		{
			// Token: 0x17000354 RID: 852
			// (get) Token: 0x060003AF RID: 943 RVA: 0x0001A3AB File Offset: 0x000185AB
			// (set) Token: 0x060003B0 RID: 944 RVA: 0x0001A3B3 File Offset: 0x000185B3
			public int ID
			{
				get
				{
					return this._ID;
				}
				set
				{
					this._ID = value;
				}
			}

			// Token: 0x17000355 RID: 853
			// (get) Token: 0x060003B1 RID: 945 RVA: 0x0001A3BC File Offset: 0x000185BC
			// (set) Token: 0x060003B2 RID: 946 RVA: 0x0001A3C4 File Offset: 0x000185C4
			public string Name
			{
				get
				{
					return this._Name;
				}
				set
				{
					this._Name = value;
				}
			}

			// Token: 0x04000112 RID: 274
			private int _ID;

			// Token: 0x04000113 RID: 275
			private string _Name;
		}

		// Token: 0x0200000E RID: 14
		public class c_Groups
		{
			// Token: 0x060003B4 RID: 948 RVA: 0x0001A3D8 File Offset: 0x000185D8
			public c_Groups(string GroupID, string GroupName)
			{
				int groupID = -1;
				int.TryParse(GroupID, out groupID);
				this._GroupID = groupID;
				this._GroupName = GroupName;
			}

			// Token: 0x17000356 RID: 854
			// (get) Token: 0x060003B5 RID: 949 RVA: 0x0001A404 File Offset: 0x00018604
			// (set) Token: 0x060003B6 RID: 950 RVA: 0x0001A40C File Offset: 0x0001860C
			public int Group
			{
				get
				{
					return this._GroupID;
				}
				set
				{
					this._GroupID = value;
				}
			}

			// Token: 0x17000357 RID: 855
			// (get) Token: 0x060003B7 RID: 951 RVA: 0x0001A415 File Offset: 0x00018615
			// (set) Token: 0x060003B8 RID: 952 RVA: 0x0001A41D File Offset: 0x0001861D
			public string GroupName
			{
				get
				{
					return this._GroupName;
				}
				set
				{
					this._GroupName = value;
				}
			}

			// Token: 0x04000114 RID: 276
			public int _GroupID;

			// Token: 0x04000115 RID: 277
			public string _GroupName;
		}

		// Token: 0x0200000F RID: 15
		public class c_LevelData
		{
			// Token: 0x060003B9 RID: 953 RVA: 0x0001A426 File Offset: 0x00018626
			public c_LevelData(int ID, string Name)
			{
				this._LevelID = ID;
				this._LevelName = Name;
			}

			// Token: 0x17000358 RID: 856
			// (get) Token: 0x060003BA RID: 954 RVA: 0x0001A43C File Offset: 0x0001863C
			// (set) Token: 0x060003BB RID: 955 RVA: 0x0001A444 File Offset: 0x00018644
			public int ID
			{
				get
				{
					return this._LevelID;
				}
				set
				{
					this._LevelID = value;
				}
			}

			// Token: 0x17000359 RID: 857
			// (get) Token: 0x060003BC RID: 956 RVA: 0x0001A44D File Offset: 0x0001864D
			// (set) Token: 0x060003BD RID: 957 RVA: 0x0001A455 File Offset: 0x00018655
			public string Name
			{
				get
				{
					return this._LevelName;
				}
				set
				{
					this._LevelName = value;
				}
			}

			// Token: 0x04000116 RID: 278
			public int _LevelID;

			// Token: 0x04000117 RID: 279
			public string _LevelName;
		}

		// Token: 0x02000010 RID: 16
		public struct c_OptionData
		{
			// Token: 0x1700035A RID: 858
			// (get) Token: 0x060003BE RID: 958 RVA: 0x0001A45E File Offset: 0x0001865E
			// (set) Token: 0x060003BF RID: 959 RVA: 0x0001A466 File Offset: 0x00018666
			public int ID { get; set; }

			// Token: 0x1700035B RID: 859
			// (get) Token: 0x060003C0 RID: 960 RVA: 0x0001A46F File Offset: 0x0001866F
			// (set) Token: 0x060003C1 RID: 961 RVA: 0x0001A477 File Offset: 0x00018677
			public string Name { get; set; }
		}

		// Token: 0x02000011 RID: 17
		public class CustomPictureBox : PictureBox
		{
			// Token: 0x060003C2 RID: 962 RVA: 0x0001A480 File Offset: 0x00018680
			public CustomPictureBox()
			{
				base.SetStyle(ControlStyles.UserPaint, true);
			}

			// Token: 0x060003C3 RID: 963 RVA: 0x0001A49B File Offset: 0x0001869B
			protected override void OnPaint(PaintEventArgs e)
			{
				base.OnPaint(e);
				e.Graphics.DrawRectangle(new Pen(new SolidBrush(this.colorBorder), 4f), e.ClipRectangle);
			}

			// Token: 0x1700035C RID: 860
			// (get) Token: 0x060003C4 RID: 964 RVA: 0x0001A4CA File Offset: 0x000186CA
			// (set) Token: 0x060003C5 RID: 965 RVA: 0x0001A4D2 File Offset: 0x000186D2
			public Color BorderColor
			{
				get
				{
					return this.colorBorder;
				}
				set
				{
					this.colorBorder = value;
				}
			}

			// Token: 0x1700035D RID: 861
			// (get) Token: 0x060003C6 RID: 966 RVA: 0x0001A4DB File Offset: 0x000186DB
			// (set) Token: 0x060003C7 RID: 967 RVA: 0x0001A4E3 File Offset: 0x000186E3
			public int MSBType
			{
				get
				{
					return this._MSBType;
				}
				set
				{
					this._MSBType = value;
				}
			}

			// Token: 0x0400011A RID: 282
			private int _MSBType;

			// Token: 0x0400011B RID: 283
			private Color colorBorder = Color.Transparent;
		}

		// Token: 0x02000012 RID: 18
		public class CustomToolTip : ToolTip
		{
			// Token: 0x060003C8 RID: 968 RVA: 0x0001A4EC File Offset: 0x000186EC
			public CustomToolTip()
			{
				base.OwnerDraw = true;
				base.Popup += this.OnPopup;
				base.Draw += this.OnDraw;
			}

			// Token: 0x060003C9 RID: 969 RVA: 0x0001A540 File Offset: 0x00018740
			private void OnDraw(object sender, DrawToolTipEventArgs e)
			{
				Graphics graphics = e.Graphics;
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Bounds, Color.Silver, Color.Goldenrod, 50f);
				graphics.FillRectangle(linearGradientBrush, e.Bounds);
				graphics.DrawRectangle(new Pen(Brushes.Azure, 1f), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
				graphics.DrawString(e.ToolTipText, new Font(e.Font, FontStyle.Bold), Brushes.Silver, new PointF((float)(e.Bounds.X + 6), (float)(e.Bounds.Y + 6)));
				graphics.DrawString(e.ToolTipText, new Font(e.Font, FontStyle.Bold), Brushes.Black, new PointF((float)(e.Bounds.X + 5), (float)(e.Bounds.Y + 5)));
				linearGradientBrush.Dispose();
			}

			// Token: 0x060003CA RID: 970 RVA: 0x0001A666 File Offset: 0x00018866
			private void OnPopup(object sender, PopupEventArgs e)
			{
				e.ToolTipSize = new Size(this._sizeX, this._sizeY);
			}

			// Token: 0x1700035E RID: 862
			// (get) Token: 0x060003CB RID: 971 RVA: 0x0001A67F File Offset: 0x0001887F
			// (set) Token: 0x060003CC RID: 972 RVA: 0x0001A687 File Offset: 0x00018887
			public int sizeX
			{
				get
				{
					return this._sizeX;
				}
				set
				{
					this._sizeX = value;
				}
			}

			// Token: 0x1700035F RID: 863
			// (get) Token: 0x060003CD RID: 973 RVA: 0x0001A690 File Offset: 0x00018890
			// (set) Token: 0x060003CE RID: 974 RVA: 0x0001A698 File Offset: 0x00018898
			public int sizeY
			{
				get
				{
					return this._sizeY;
				}
				set
				{
					this._sizeY = value;
				}
			}

			// Token: 0x0400011C RID: 284
			private int _sizeX = 230;

			// Token: 0x0400011D RID: 285
			private int _sizeY = 140;
		}

		// Token: 0x02000013 RID: 19
		public struct EventBagDrop
		{
			// Token: 0x0400011E RID: 286
			public string Name;

			// Token: 0x0400011F RID: 287
			public int Zen;

			// Token: 0x04000120 RID: 288
			public int BagGroup;

			// Token: 0x04000121 RID: 289
			public int BagIndex;

			// Token: 0x04000122 RID: 290
			public int BagLevel;

			// Token: 0x04000123 RID: 291
			public double BagDropRate;

			// Token: 0x04000124 RID: 292
			public double ItemDropRate;

			// Token: 0x04000125 RID: 293
			public double ExcDropRate;

			// Token: 0x04000126 RID: 294
			public double AncDropRate;

			// Token: 0x04000127 RID: 295
			public double SocketDropRate;

			// Token: 0x04000128 RID: 296
			public int Default_Cat;

			// Token: 0x04000129 RID: 297
			public int Default_ID;

			// Token: 0x0400012A RID: 298
			public int Default_minlv;

			// Token: 0x0400012B RID: 299
			public int Default_maxlv;

			// Token: 0x0400012C RID: 300
			public bool Default_skill;

			// Token: 0x0400012D RID: 301
			public bool Default_luck;

			// Token: 0x0400012E RID: 302
			public int Default_addopt;

			// Token: 0x0400012F RID: 303
			public bool Default_exc;

			// Token: 0x04000130 RID: 304
			public bool Default_anc;

			// Token: 0x04000131 RID: 305
			public bool Default_sock;
		}

		// Token: 0x02000014 RID: 20
		public struct EventBagItem
		{
			// Token: 0x17000360 RID: 864
			// (get) Token: 0x060003CF RID: 975 RVA: 0x0001A6A1 File Offset: 0x000188A1
			// (set) Token: 0x060003D0 RID: 976 RVA: 0x0001A6A9 File Offset: 0x000188A9
			public string Name { get; set; }

			// Token: 0x17000361 RID: 865
			// (get) Token: 0x060003D1 RID: 977 RVA: 0x0001A6B2 File Offset: 0x000188B2
			// (set) Token: 0x060003D2 RID: 978 RVA: 0x0001A6BA File Offset: 0x000188BA
			public int new_MaxOption { get; set; }

			// Token: 0x04000132 RID: 306
			public int Index;

			// Token: 0x04000133 RID: 307
			public int Group;

			// Token: 0x04000134 RID: 308
			public int MaxLevel;

			// Token: 0x04000135 RID: 309
			public int MinLevel;

			// Token: 0x04000136 RID: 310
			public bool Skill;

			// Token: 0x04000137 RID: 311
			public bool Option;

			// Token: 0x04000138 RID: 312
			public bool Luck;

			// Token: 0x04000139 RID: 313
			public bool Excellent;

			// Token: 0x0400013A RID: 314
			public bool Ancient;

			// Token: 0x0400013B RID: 315
			public bool Socket;
		}

		// Token: 0x02000015 RID: 21
		public struct EventBagMap
		{
			// Token: 0x17000362 RID: 866
			// (get) Token: 0x060003D3 RID: 979 RVA: 0x0001A6C3 File Offset: 0x000188C3
			// (set) Token: 0x060003D4 RID: 980 RVA: 0x0001A6CB File Offset: 0x000188CB
			public string Name { get; set; }

			// Token: 0x17000363 RID: 867
			// (get) Token: 0x060003D5 RID: 981 RVA: 0x0001A6D4 File Offset: 0x000188D4
			// (set) Token: 0x060003D6 RID: 982 RVA: 0x0001A6DC File Offset: 0x000188DC
			public int ID { get; set; }

			// Token: 0x0400013E RID: 318
			public bool Drop;

			// Token: 0x0400013F RID: 319
			public int MobMinLvl;

			// Token: 0x04000140 RID: 320
			public int MobMaxLvl;
		}

		// Token: 0x02000016 RID: 22
		public struct IBSCategory
		{
			// Token: 0x04000143 RID: 323
			public int Index;

			// Token: 0x04000144 RID: 324
			public string Name;

			// Token: 0x04000145 RID: 325
			public short Unk1;

			// Token: 0x04000146 RID: 326
			public short Unk2;

			// Token: 0x04000147 RID: 327
			public int HeadCatIndex;

			// Token: 0x04000148 RID: 328
			public short Seq;

			// Token: 0x04000149 RID: 329
			public bool IsHeadCat;

			// Token: 0x0400014A RID: 330
			public int TraceNumber;

			// Token: 0x0400014B RID: 331
			public string TraceString;
		}

		// Token: 0x02000017 RID: 23
		public struct IBSPackage
		{
			// Token: 0x17000364 RID: 868
			// (get) Token: 0x060003D7 RID: 983 RVA: 0x0001A6E5 File Offset: 0x000188E5
			// (set) Token: 0x060003D8 RID: 984 RVA: 0x0001A6ED File Offset: 0x000188ED
			public string Name { get; set; }

			// Token: 0x0400014C RID: 332
			public short CatIndex;

			// Token: 0x0400014D RID: 333
			public short Seq;

			// Token: 0x0400014E RID: 334
			public short Index;

			// Token: 0x0400014F RID: 335
			public short Unk1;

			// Token: 0x04000150 RID: 336
			public int Price;

			// Token: 0x04000151 RID: 337
			public string Info;

			// Token: 0x04000152 RID: 338
			public string Empty;

			// Token: 0x04000153 RID: 339
			public short Unk2;

			// Token: 0x04000154 RID: 340
			public short Unk3;

			// Token: 0x04000155 RID: 341
			public string Unk4;

			// Token: 0x04000156 RID: 342
			public string Unk5;

			// Token: 0x04000157 RID: 343
			public short Unk6;

			// Token: 0x04000158 RID: 344
			public short RewardCount;

			// Token: 0x04000159 RID: 345
			public string CoinTxt1;

			// Token: 0x0400015A RID: 346
			public string CoinTxt2;

			// Token: 0x0400015B RID: 347
			public short Unk7;

			// Token: 0x0400015C RID: 348
			public short Unk8;

			// Token: 0x0400015D RID: 349
			public short Unk9;

			// Token: 0x0400015E RID: 350
			public string ProductRewardIndex1;

			// Token: 0x0400015F RID: 351
			public int ItemID;

			// Token: 0x04000160 RID: 352
			public short Unk10;

			// Token: 0x04000161 RID: 353
			public short CheckBoxCount;

			// Token: 0x04000162 RID: 354
			public string ProductRewardIndexes7;

			// Token: 0x04000163 RID: 355
			public string Unk11;

			// Token: 0x04000164 RID: 356
			public int ServerCatIndex;

			// Token: 0x04000165 RID: 357
			public int Const669;

			// Token: 0x04000166 RID: 358
			public int TraceNumber;

			// Token: 0x04000167 RID: 359
			public string TraceString;
		}

		// Token: 0x02000018 RID: 24
		public struct IBSProduct
		{
			// Token: 0x17000365 RID: 869
			// (get) Token: 0x060003D9 RID: 985 RVA: 0x0001A6F6 File Offset: 0x000188F6
			// (set) Token: 0x060003DA RID: 986 RVA: 0x0001A6FE File Offset: 0x000188FE
			public string Name { get; set; }

			// Token: 0x04000169 RID: 361
			public int Index1;

			// Token: 0x0400016A RID: 362
			public string BuyTypeTxt1;

			// Token: 0x0400016B RID: 363
			public string TypeCount;

			// Token: 0x0400016C RID: 364
			public string BuyTypeTxt2;

			// Token: 0x0400016D RID: 365
			public int Price;

			// Token: 0x0400016E RID: 366
			public int Index7;

			// Token: 0x0400016F RID: 367
			public short Unk1;

			// Token: 0x04000170 RID: 368
			public short Unk2;

			// Token: 0x04000171 RID: 369
			public short Unk3;

			// Token: 0x04000172 RID: 370
			public short Unk4;

			// Token: 0x04000173 RID: 371
			public short Unk5;

			// Token: 0x04000174 RID: 372
			public short Unk6;

			// Token: 0x04000175 RID: 373
			public string ItemID;

			// Token: 0x04000176 RID: 374
			public string Unk7;

			// Token: 0x04000177 RID: 375
			public string Unk8;

			// Token: 0x04000178 RID: 376
			public string Unk9;

			// Token: 0x04000179 RID: 377
			public int TraceNumber;

			// Token: 0x0400017A RID: 378
			public string TraceString;
		}

		// Token: 0x02000019 RID: 25
		public struct IGCCashItemInfo
		{
			// Token: 0x17000366 RID: 870
			// (get) Token: 0x060003DB RID: 987 RVA: 0x0001A707 File Offset: 0x00018907
			// (set) Token: 0x060003DC RID: 988 RVA: 0x0001A70F File Offset: 0x0001890F
			public string Name { get; set; }

			// Token: 0x0400017C RID: 380
			public int GID;

			// Token: 0x0400017D RID: 381
			public int ID;

			// Token: 0x0400017E RID: 382
			public int iGroup;

			// Token: 0x0400017F RID: 383
			public int iIndex;

			// Token: 0x04000180 RID: 384
			public int Level;

			// Token: 0x04000181 RID: 385
			public int Dur;

			// Token: 0x04000182 RID: 386
			public int Skill;

			// Token: 0x04000183 RID: 387
			public int Luck;

			// Token: 0x04000184 RID: 388
			public int Option;

			// Token: 0x04000185 RID: 389
			public int Exc;

			// Token: 0x04000186 RID: 390
			public int Ancient;

			// Token: 0x04000187 RID: 391
			public int Socket;

			// Token: 0x04000188 RID: 392
			public int Type;

			// Token: 0x04000189 RID: 393
			public int Period;

			// Token: 0x0400018A RID: 394
			public int TraceNumber;

			// Token: 0x0400018B RID: 395
			public string TraceString;
		}

		// Token: 0x0200001A RID: 26
		public struct IGCCashItemList
		{
			// Token: 0x0400018D RID: 397
			public int GUID;

			// Token: 0x0400018E RID: 398
			public int Index;

			// Token: 0x0400018F RID: 399
			public int SubIndex;

			// Token: 0x04000190 RID: 400
			public int iOpt;

			// Token: 0x04000191 RID: 401
			public int pID;

			// Token: 0x04000192 RID: 402
			public int cType;

			// Token: 0x04000193 RID: 403
			public int iPrice;

			// Token: 0x04000194 RID: 404
			public int iInfoGD;

			// Token: 0x04000195 RID: 405
			public int iInfoID;

			// Token: 0x04000196 RID: 406
			public int iCat;

			// Token: 0x04000197 RID: 407
			public int iGP;

			// Token: 0x04000198 RID: 408
			public int iSale;

			// Token: 0x04000199 RID: 409
			public int iRand;

			// Token: 0x0400019A RID: 410
			public string Name;

			// Token: 0x0400019B RID: 411
			public int TraceNumber;

			// Token: 0x0400019C RID: 412
			public string TraceString;
		}

		// Token: 0x0200001B RID: 27
		public struct IGCCashItemPackages
		{
			// Token: 0x17000367 RID: 871
			// (get) Token: 0x060003DD RID: 989 RVA: 0x0001A718 File Offset: 0x00018918
			// (set) Token: 0x060003DE RID: 990 RVA: 0x0001A720 File Offset: 0x00018920
			public string Name { get; set; }

			// Token: 0x17000368 RID: 872
			// (get) Token: 0x060003DF RID: 991 RVA: 0x0001A729 File Offset: 0x00018929
			// (set) Token: 0x060003E0 RID: 992 RVA: 0x0001A731 File Offset: 0x00018931
			public string PackName { get; set; }

			// Token: 0x0400019D RID: 413
			public int GUID;

			// Token: 0x0400019E RID: 414
			public int pID;

			// Token: 0x0400019F RID: 415
			public int iSeq;

			// Token: 0x040001A0 RID: 416
			public int iGUID;

			// Token: 0x040001A1 RID: 417
			public int iID;

			// Token: 0x040001A2 RID: 418
			public string TraceString;
		}

		// Token: 0x0200001C RID: 28
		public struct IGCDropManagerFile
		{
			// Token: 0x17000369 RID: 873
			// (get) Token: 0x060003E1 RID: 993 RVA: 0x0001A73A File Offset: 0x0001893A
			// (set) Token: 0x060003E2 RID: 994 RVA: 0x0001A742 File Offset: 0x00018942
			public string iGroup { get; set; }

			// Token: 0x1700036A RID: 874
			// (get) Token: 0x060003E3 RID: 995 RVA: 0x0001A74B File Offset: 0x0001894B
			// (set) Token: 0x060003E4 RID: 996 RVA: 0x0001A753 File Offset: 0x00018953
			public string iIndex { get; set; }

			// Token: 0x1700036B RID: 875
			// (get) Token: 0x060003E5 RID: 997 RVA: 0x0001A75C File Offset: 0x0001895C
			// (set) Token: 0x060003E6 RID: 998 RVA: 0x0001A764 File Offset: 0x00018964
			public string MinLvl { get; set; }

			// Token: 0x1700036C RID: 876
			// (get) Token: 0x060003E7 RID: 999 RVA: 0x0001A76D File Offset: 0x0001896D
			// (set) Token: 0x060003E8 RID: 1000 RVA: 0x0001A775 File Offset: 0x00018975
			public string MaxLvl { get; set; }

			// Token: 0x1700036D RID: 877
			// (get) Token: 0x060003E9 RID: 1001 RVA: 0x0001A77E File Offset: 0x0001897E
			// (set) Token: 0x060003EA RID: 1002 RVA: 0x0001A786 File Offset: 0x00018986
			public string Skill { get; set; }

			// Token: 0x1700036E RID: 878
			// (get) Token: 0x060003EB RID: 1003 RVA: 0x0001A78F File Offset: 0x0001898F
			// (set) Token: 0x060003EC RID: 1004 RVA: 0x0001A797 File Offset: 0x00018997
			public string Luck { get; set; }

			// Token: 0x1700036F RID: 879
			// (get) Token: 0x060003ED RID: 1005 RVA: 0x0001A7A0 File Offset: 0x000189A0
			// (set) Token: 0x060003EE RID: 1006 RVA: 0x0001A7A8 File Offset: 0x000189A8
			public string Opt { get; set; }

			// Token: 0x17000370 RID: 880
			// (get) Token: 0x060003EF RID: 1007 RVA: 0x0001A7B1 File Offset: 0x000189B1
			// (set) Token: 0x060003F0 RID: 1008 RVA: 0x0001A7B9 File Offset: 0x000189B9
			public string Exc { get; set; }

			// Token: 0x17000371 RID: 881
			// (get) Token: 0x060003F1 RID: 1009 RVA: 0x0001A7C2 File Offset: 0x000189C2
			// (set) Token: 0x060003F2 RID: 1010 RVA: 0x0001A7CA File Offset: 0x000189CA
			public string Ancient { get; set; }

			// Token: 0x17000372 RID: 882
			// (get) Token: 0x060003F3 RID: 1011 RVA: 0x0001A7D3 File Offset: 0x000189D3
			// (set) Token: 0x060003F4 RID: 1012 RVA: 0x0001A7DB File Offset: 0x000189DB
			public string MapID { get; set; }

			// Token: 0x17000373 RID: 883
			// (get) Token: 0x060003F5 RID: 1013 RVA: 0x0001A7E4 File Offset: 0x000189E4
			// (set) Token: 0x060003F6 RID: 1014 RVA: 0x0001A7EC File Offset: 0x000189EC
			public string MobID { get; set; }

			// Token: 0x17000374 RID: 884
			// (get) Token: 0x060003F7 RID: 1015 RVA: 0x0001A7F5 File Offset: 0x000189F5
			// (set) Token: 0x060003F8 RID: 1016 RVA: 0x0001A7FD File Offset: 0x000189FD
			public string MinMobLvl { get; set; }

			// Token: 0x17000375 RID: 885
			// (get) Token: 0x060003F9 RID: 1017 RVA: 0x0001A806 File Offset: 0x00018A06
			// (set) Token: 0x060003FA RID: 1018 RVA: 0x0001A80E File Offset: 0x00018A0E
			public string MaxMobLvl { get; set; }

			// Token: 0x17000376 RID: 886
			// (get) Token: 0x060003FB RID: 1019 RVA: 0x0001A817 File Offset: 0x00018A17
			// (set) Token: 0x060003FC RID: 1020 RVA: 0x0001A81F File Offset: 0x00018A1F
			public string Durability { get; set; }

			// Token: 0x17000377 RID: 887
			// (get) Token: 0x060003FD RID: 1021 RVA: 0x0001A828 File Offset: 0x00018A28
			// (set) Token: 0x060003FE RID: 1022 RVA: 0x0001A830 File Offset: 0x00018A30
			public string DropRate { get; set; }

			// Token: 0x17000378 RID: 888
			// (get) Token: 0x060003FF RID: 1023 RVA: 0x0001A839 File Offset: 0x00018A39
			// (set) Token: 0x06000400 RID: 1024 RVA: 0x0001A841 File Offset: 0x00018A41
			public string Name { get; set; }
		}

		// Token: 0x0200001D RID: 29
		public struct Map
		{
			// Token: 0x17000379 RID: 889
			// (get) Token: 0x06000401 RID: 1025 RVA: 0x0001A84A File Offset: 0x00018A4A
			// (set) Token: 0x06000402 RID: 1026 RVA: 0x0001A852 File Offset: 0x00018A52
			public string MapName
			{
				get
				{
					return this.mMapName;
				}
				set
				{
					this.mMapName = value;
				}
			}

			// Token: 0x1700037A RID: 890
			// (get) Token: 0x06000403 RID: 1027 RVA: 0x0001A85B File Offset: 0x00018A5B
			// (set) Token: 0x06000404 RID: 1028 RVA: 0x0001A863 File Offset: 0x00018A63
			public int MapCode
			{
				get
				{
					return this.mMapCode;
				}
				set
				{
					this.mMapCode = value;
				}
			}

			// Token: 0x040001B5 RID: 437
			private string mMapName;

			// Token: 0x040001B6 RID: 438
			private int mMapCode;
		}

		// Token: 0x0200001E RID: 30
		public struct Monster
		{
			// Token: 0x1700037B RID: 891
			// (get) Token: 0x06000405 RID: 1029 RVA: 0x0001A86C File Offset: 0x00018A6C
			// (set) Token: 0x06000406 RID: 1030 RVA: 0x0001A874 File Offset: 0x00018A74
			public int ID { get; set; }

			// Token: 0x1700037C RID: 892
			// (get) Token: 0x06000407 RID: 1031 RVA: 0x0001A87D File Offset: 0x00018A7D
			// (set) Token: 0x06000408 RID: 1032 RVA: 0x0001A885 File Offset: 0x00018A85
			public int Rate { get; set; }

			// Token: 0x1700037D RID: 893
			// (get) Token: 0x06000409 RID: 1033 RVA: 0x0001A88E File Offset: 0x00018A8E
			// (set) Token: 0x0600040A RID: 1034 RVA: 0x0001A896 File Offset: 0x00018A96
			public string Name { get; set; }

			// Token: 0x1700037E RID: 894
			// (get) Token: 0x0600040B RID: 1035 RVA: 0x0001A89F File Offset: 0x00018A9F
			// (set) Token: 0x0600040C RID: 1036 RVA: 0x0001A8A7 File Offset: 0x00018AA7
			public int Level { get; set; }

			// Token: 0x1700037F RID: 895
			// (get) Token: 0x0600040D RID: 1037 RVA: 0x0001A8B0 File Offset: 0x00018AB0
			// (set) Token: 0x0600040E RID: 1038 RVA: 0x0001A8B8 File Offset: 0x00018AB8
			public int HP { get; set; }

			// Token: 0x17000380 RID: 896
			// (get) Token: 0x0600040F RID: 1039 RVA: 0x0001A8C1 File Offset: 0x00018AC1
			// (set) Token: 0x06000410 RID: 1040 RVA: 0x0001A8C9 File Offset: 0x00018AC9
			public int MP { get; set; }

			// Token: 0x17000381 RID: 897
			// (get) Token: 0x06000411 RID: 1041 RVA: 0x0001A8D2 File Offset: 0x00018AD2
			// (set) Token: 0x06000412 RID: 1042 RVA: 0x0001A8DA File Offset: 0x00018ADA
			public int MinDmg { get; set; }

			// Token: 0x17000382 RID: 898
			// (get) Token: 0x06000413 RID: 1043 RVA: 0x0001A8E3 File Offset: 0x00018AE3
			// (set) Token: 0x06000414 RID: 1044 RVA: 0x0001A8EB File Offset: 0x00018AEB
			public int MaxDmg { get; set; }

			// Token: 0x17000383 RID: 899
			// (get) Token: 0x06000415 RID: 1045 RVA: 0x0001A8F4 File Offset: 0x00018AF4
			// (set) Token: 0x06000416 RID: 1046 RVA: 0x0001A8FC File Offset: 0x00018AFC
			public int Def { get; set; }

			// Token: 0x17000384 RID: 900
			// (get) Token: 0x06000417 RID: 1047 RVA: 0x0001A905 File Offset: 0x00018B05
			// (set) Token: 0x06000418 RID: 1048 RVA: 0x0001A90D File Offset: 0x00018B0D
			public int MagDef { get; set; }

			// Token: 0x17000385 RID: 901
			// (get) Token: 0x06000419 RID: 1049 RVA: 0x0001A916 File Offset: 0x00018B16
			// (set) Token: 0x0600041A RID: 1050 RVA: 0x0001A91E File Offset: 0x00018B1E
			public int AtkPower { get; set; }

			// Token: 0x17000386 RID: 902
			// (get) Token: 0x0600041B RID: 1051 RVA: 0x0001A927 File Offset: 0x00018B27
			// (set) Token: 0x0600041C RID: 1052 RVA: 0x0001A92F File Offset: 0x00018B2F
			public int AtkSucRate { get; set; }

			// Token: 0x17000387 RID: 903
			// (get) Token: 0x0600041D RID: 1053 RVA: 0x0001A938 File Offset: 0x00018B38
			// (set) Token: 0x0600041E RID: 1054 RVA: 0x0001A940 File Offset: 0x00018B40
			public int Move { get; set; }

			// Token: 0x17000388 RID: 904
			// (get) Token: 0x0600041F RID: 1055 RVA: 0x0001A949 File Offset: 0x00018B49
			// (set) Token: 0x06000420 RID: 1056 RVA: 0x0001A951 File Offset: 0x00018B51
			public int AType { get; set; }

			// Token: 0x17000389 RID: 905
			// (get) Token: 0x06000421 RID: 1057 RVA: 0x0001A95A File Offset: 0x00018B5A
			// (set) Token: 0x06000422 RID: 1058 RVA: 0x0001A962 File Offset: 0x00018B62
			public int ARange { get; set; }

			// Token: 0x1700038A RID: 906
			// (get) Token: 0x06000423 RID: 1059 RVA: 0x0001A96B File Offset: 0x00018B6B
			// (set) Token: 0x06000424 RID: 1060 RVA: 0x0001A973 File Offset: 0x00018B73
			public int VRange { get; set; }

			// Token: 0x1700038B RID: 907
			// (get) Token: 0x06000425 RID: 1061 RVA: 0x0001A97C File Offset: 0x00018B7C
			// (set) Token: 0x06000426 RID: 1062 RVA: 0x0001A984 File Offset: 0x00018B84
			public int MovSP { get; set; }

			// Token: 0x1700038C RID: 908
			// (get) Token: 0x06000427 RID: 1063 RVA: 0x0001A98D File Offset: 0x00018B8D
			// (set) Token: 0x06000428 RID: 1064 RVA: 0x0001A995 File Offset: 0x00018B95
			public int ASpeed { get; set; }

			// Token: 0x1700038D RID: 909
			// (get) Token: 0x06000429 RID: 1065 RVA: 0x0001A99E File Offset: 0x00018B9E
			// (set) Token: 0x0600042A RID: 1066 RVA: 0x0001A9A6 File Offset: 0x00018BA6
			public int RegTime { get; set; }

			// Token: 0x1700038E RID: 910
			// (get) Token: 0x0600042B RID: 1067 RVA: 0x0001A9AF File Offset: 0x00018BAF
			// (set) Token: 0x0600042C RID: 1068 RVA: 0x0001A9B7 File Offset: 0x00018BB7
			public int Attrib { get; set; }

			// Token: 0x1700038F RID: 911
			// (get) Token: 0x0600042D RID: 1069 RVA: 0x0001A9C0 File Offset: 0x00018BC0
			// (set) Token: 0x0600042E RID: 1070 RVA: 0x0001A9C8 File Offset: 0x00018BC8
			public int ItemR { get; set; }

			// Token: 0x17000390 RID: 912
			// (get) Token: 0x0600042F RID: 1071 RVA: 0x0001A9D1 File Offset: 0x00018BD1
			// (set) Token: 0x06000430 RID: 1072 RVA: 0x0001A9D9 File Offset: 0x00018BD9
			public int MoneyR { get; set; }

			// Token: 0x17000391 RID: 913
			// (get) Token: 0x06000431 RID: 1073 RVA: 0x0001A9E2 File Offset: 0x00018BE2
			// (set) Token: 0x06000432 RID: 1074 RVA: 0x0001A9EA File Offset: 0x00018BEA
			public int MaxIS { get; set; }

			// Token: 0x17000392 RID: 914
			// (get) Token: 0x06000433 RID: 1075 RVA: 0x0001A9F3 File Offset: 0x00018BF3
			// (set) Token: 0x06000434 RID: 1076 RVA: 0x0001A9FB File Offset: 0x00018BFB
			public int RWind { get; set; }

			// Token: 0x17000393 RID: 915
			// (get) Token: 0x06000435 RID: 1077 RVA: 0x0001AA04 File Offset: 0x00018C04
			// (set) Token: 0x06000436 RID: 1078 RVA: 0x0001AA0C File Offset: 0x00018C0C
			public int RPois { get; set; }

			// Token: 0x17000394 RID: 916
			// (get) Token: 0x06000437 RID: 1079 RVA: 0x0001AA15 File Offset: 0x00018C15
			// (set) Token: 0x06000438 RID: 1080 RVA: 0x0001AA1D File Offset: 0x00018C1D
			public int RIce { get; set; }

			// Token: 0x17000395 RID: 917
			// (get) Token: 0x06000439 RID: 1081 RVA: 0x0001AA26 File Offset: 0x00018C26
			// (set) Token: 0x0600043A RID: 1082 RVA: 0x0001AA2E File Offset: 0x00018C2E
			public int RWtr { get; set; }

			// Token: 0x17000396 RID: 918
			// (get) Token: 0x0600043B RID: 1083 RVA: 0x0001AA37 File Offset: 0x00018C37
			// (set) Token: 0x0600043C RID: 1084 RVA: 0x0001AA3F File Offset: 0x00018C3F
			public int RFire { get; set; }

			// Token: 0x17000397 RID: 919
			// (get) Token: 0x0600043D RID: 1085 RVA: 0x0001AA48 File Offset: 0x00018C48
			// (set) Token: 0x0600043E RID: 1086 RVA: 0x0001AA50 File Offset: 0x00018C50
			public int Element { get; set; }

			// Token: 0x17000398 RID: 920
			// (get) Token: 0x0600043F RID: 1087 RVA: 0x0001AA59 File Offset: 0x00018C59
			// (set) Token: 0x06000440 RID: 1088 RVA: 0x0001AA61 File Offset: 0x00018C61
			public int MaxElem { get; set; }

			// Token: 0x17000399 RID: 921
			// (get) Token: 0x06000441 RID: 1089 RVA: 0x0001AA6A File Offset: 0x00018C6A
			// (set) Token: 0x06000442 RID: 1090 RVA: 0x0001AA72 File Offset: 0x00018C72
			public int MinElem { get; set; }

			// Token: 0x1700039A RID: 922
			// (get) Token: 0x06000443 RID: 1091 RVA: 0x0001AA7B File Offset: 0x00018C7B
			// (set) Token: 0x06000444 RID: 1092 RVA: 0x0001AA83 File Offset: 0x00018C83
			public int ElemDef { get; set; }
		}

		// Token: 0x0200001F RID: 31
		public struct MSB : IComparable<Structures.MSB>
		{
			// Token: 0x1700039B RID: 923
			// (get) Token: 0x06000445 RID: 1093 RVA: 0x0001AA8C File Offset: 0x00018C8C
			// (set) Token: 0x06000446 RID: 1094 RVA: 0x0001AA94 File Offset: 0x00018C94
			public string ToolTipInfo { get; set; }

			// Token: 0x1700039C RID: 924
			// (get) Token: 0x06000447 RID: 1095 RVA: 0x0001AA9D File Offset: 0x00018C9D
			// (set) Token: 0x06000448 RID: 1096 RVA: 0x0001AAA5 File Offset: 0x00018CA5
			public string MobName { get; set; }

			// Token: 0x1700039D RID: 925
			// (get) Token: 0x06000449 RID: 1097 RVA: 0x0001AAAE File Offset: 0x00018CAE
			// (set) Token: 0x0600044A RID: 1098 RVA: 0x0001AAB6 File Offset: 0x00018CB6
			public string FileDesc { get; set; }

			// Token: 0x1700039E RID: 926
			// (get) Token: 0x0600044B RID: 1099 RVA: 0x0001AABF File Offset: 0x00018CBF
			// (set) Token: 0x0600044C RID: 1100 RVA: 0x0001AAC7 File Offset: 0x00018CC7
			public string UniKey { get; set; }

			// Token: 0x0600044D RID: 1101 RVA: 0x0001AAD0 File Offset: 0x00018CD0
			public int CompareTo(Structures.MSB cus)
			{
				return this.MapID.CompareTo(cus.MapID);
			}

			// Token: 0x040001D7 RID: 471
			public int Type;

			// Token: 0x040001D8 RID: 472
			public int MobID;

			// Token: 0x040001D9 RID: 473
			public int MapID;

			// Token: 0x040001DA RID: 474
			public int Dis;

			// Token: 0x040001DB RID: 475
			public int X;

			// Token: 0x040001DC RID: 476
			public int Y;

			// Token: 0x040001DD RID: 477
			public int EndX;

			// Token: 0x040001DE RID: 478
			public int EndY;

			// Token: 0x040001DF RID: 479
			public int Dir;

			// Token: 0x040001E0 RID: 480
			public int Total;
		}

		// Token: 0x02000020 RID: 32
		public struct ShopItem
		{
			// Token: 0x1700039F RID: 927
			// (get) Token: 0x0600044E RID: 1102 RVA: 0x0001AAE4 File Offset: 0x00018CE4
			// (set) Token: 0x0600044F RID: 1103 RVA: 0x0001AAEC File Offset: 0x00018CEC
			public byte Level { get; set; }

			// Token: 0x170003A0 RID: 928
			// (get) Token: 0x06000450 RID: 1104 RVA: 0x0001AAF5 File Offset: 0x00018CF5
			// (set) Token: 0x06000451 RID: 1105 RVA: 0x0001AAFD File Offset: 0x00018CFD
			public byte Durablity { get; set; }

			// Token: 0x170003A1 RID: 929
			// (get) Token: 0x06000452 RID: 1106 RVA: 0x0001AB06 File Offset: 0x00018D06
			// (set) Token: 0x06000453 RID: 1107 RVA: 0x0001AB0E File Offset: 0x00018D0E
			public bool Skill { get; set; }

			// Token: 0x170003A2 RID: 930
			// (get) Token: 0x06000454 RID: 1108 RVA: 0x0001AB17 File Offset: 0x00018D17
			// (set) Token: 0x06000455 RID: 1109 RVA: 0x0001AB1F File Offset: 0x00018D1F
			public bool Luck { get; set; }

			// Token: 0x170003A3 RID: 931
			// (get) Token: 0x06000456 RID: 1110 RVA: 0x0001AB28 File Offset: 0x00018D28
			// (set) Token: 0x06000457 RID: 1111 RVA: 0x0001AB30 File Offset: 0x00018D30
			public byte Option { get; set; }

			// Token: 0x170003A4 RID: 932
			// (get) Token: 0x06000458 RID: 1112 RVA: 0x0001AB39 File Offset: 0x00018D39
			// (set) Token: 0x06000459 RID: 1113 RVA: 0x0001AB41 File Offset: 0x00018D41
			public byte Excellent { get; set; }

			// Token: 0x170003A5 RID: 933
			// (get) Token: 0x0600045A RID: 1114 RVA: 0x0001AB4A File Offset: 0x00018D4A
			// (set) Token: 0x0600045B RID: 1115 RVA: 0x0001AB52 File Offset: 0x00018D52
			public byte Ancient { get; set; }

			// Token: 0x040001E5 RID: 485
			public int ShopLocX;

			// Token: 0x040001E6 RID: 486
			public int ShopLocY;

			// Token: 0x040001E7 RID: 487
			public string UniqName;

			// Token: 0x040001E8 RID: 488
			public int Group;

			// Token: 0x040001E9 RID: 489
			public int Index;
		}

		// Token: 0x02000021 RID: 33
		public struct UniItem
		{
			// Token: 0x170003A6 RID: 934
			// (get) Token: 0x0600045C RID: 1116 RVA: 0x0001AB5B File Offset: 0x00018D5B
			// (set) Token: 0x0600045D RID: 1117 RVA: 0x0001AB63 File Offset: 0x00018D63
			public int Group { get; set; }

			// Token: 0x170003A7 RID: 935
			// (get) Token: 0x0600045E RID: 1118 RVA: 0x0001AB6C File Offset: 0x00018D6C
			// (set) Token: 0x0600045F RID: 1119 RVA: 0x0001AB74 File Offset: 0x00018D74
			public int Index { get; set; }

			// Token: 0x170003A8 RID: 936
			// (get) Token: 0x06000460 RID: 1120 RVA: 0x0001AB7D File Offset: 0x00018D7D
			// (set) Token: 0x06000461 RID: 1121 RVA: 0x0001AB85 File Offset: 0x00018D85
			public int Slot { get; set; }

			// Token: 0x170003A9 RID: 937
			// (get) Token: 0x06000462 RID: 1122 RVA: 0x0001AB8E File Offset: 0x00018D8E
			// (set) Token: 0x06000463 RID: 1123 RVA: 0x0001AB96 File Offset: 0x00018D96
			public int Skill { get; set; }

			// Token: 0x170003AA RID: 938
			// (get) Token: 0x06000464 RID: 1124 RVA: 0x0001AB9F File Offset: 0x00018D9F
			// (set) Token: 0x06000465 RID: 1125 RVA: 0x0001ABA7 File Offset: 0x00018DA7
			public int X { get; set; }

			// Token: 0x170003AB RID: 939
			// (get) Token: 0x06000466 RID: 1126 RVA: 0x0001ABB0 File Offset: 0x00018DB0
			// (set) Token: 0x06000467 RID: 1127 RVA: 0x0001ABB8 File Offset: 0x00018DB8
			public int Y { get; set; }

			// Token: 0x170003AC RID: 940
			// (get) Token: 0x06000468 RID: 1128 RVA: 0x0001ABC1 File Offset: 0x00018DC1
			// (set) Token: 0x06000469 RID: 1129 RVA: 0x0001ABC9 File Offset: 0x00018DC9
			public int Option { get; set; }

			// Token: 0x170003AD RID: 941
			// (get) Token: 0x0600046A RID: 1130 RVA: 0x0001ABD2 File Offset: 0x00018DD2
			// (set) Token: 0x0600046B RID: 1131 RVA: 0x0001ABDA File Offset: 0x00018DDA
			public string Name { get; set; }

			// Token: 0x170003AE RID: 942
			// (get) Token: 0x0600046C RID: 1132 RVA: 0x0001ABE3 File Offset: 0x00018DE3
			// (set) Token: 0x0600046D RID: 1133 RVA: 0x0001ABEB File Offset: 0x00018DEB
			public int Durability { get; set; }

			// Token: 0x170003AF RID: 943
			// (get) Token: 0x0600046E RID: 1134 RVA: 0x0001ABF4 File Offset: 0x00018DF4
			// (set) Token: 0x0600046F RID: 1135 RVA: 0x0001ABFC File Offset: 0x00018DFC
			public int Ancient { get; set; }
		}
	}
}
