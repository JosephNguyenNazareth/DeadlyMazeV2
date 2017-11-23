using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using MyItem;
using Monster;


namespace Player
{
    [System.Serializable]
	public class Player
    {
        public string PlayerName; //should not contain special ccharacters
        int HP; //min:0, max: 100

        int process; //min:0%, max:100%
        string sceneName; //current name of the scene
        //position must not be collided with enemy area
        public float x, y, z;
        #region SavedSetting
        public float Sound;
        public float BGM;
        public bool Fullscreen;
		public  KeyCode Up = KeyCode.UpArrow;
		public  KeyCode Down = KeyCode.DownArrow;
		public  KeyCode Left = KeyCode.LeftArrow;
		public  KeyCode Right = KeyCode.RightArrow;
		public  KeyCode Jump = KeyCode.K;
		public  KeyCode Shoot = KeyCode.Mouse0;
		/// <summary>
		/// Bag item will show user items in a canvas
		/// user can choose those items by clicking on these
		/// </summary>
		public  KeyCode OpenItem = KeyCode.Tab;
		public  KeyCode SetPole = KeyCode.P;
        #endregion

        #region  backpacks for player
        public MyItem.MyItem SmallBulletPack = new MyItem.MyItem(MyItem.MyItem._Item.BulletPack);
        public MyItem.MyItem MediumBulletPack = new MyItem.MyItem(MyItem.MyItem._Item.BulletPack);
        public MyItem.MyItem LargeBulletPack = new MyItem.MyItem(MyItem.MyItem._Item.BulletPack);
        public MyItem.MyItem MediumFAK = new MyItem.MyItem(MyItem.MyItem._Item.FirstAidKit);
        public MyItem.MyItem BigFAK = new MyItem.MyItem(MyItem.MyItem._Item.FirstAidKit);
        public MyItem.MyItem Pole = new MyItem.MyItem(MyItem.MyItem._Item.Pole);
        public Gun PlayerGun = new Gun(); //containing current type of gun and numbers of bullets in each gun (This PlayerGun can change its type)
                                   /*********************/
        #endregion
        #region contructor
        public Player()
        {
            HP = 100;
            process = 0;
            SmallBulletPack.SetBulletPack(MyItem.MyItem._BulletPack.small);
            MediumBulletPack.SetBulletPack(MyItem.MyItem._BulletPack.medium);
            LargeBulletPack.SetBulletPack(MyItem.MyItem._BulletPack.large);
            MediumFAK.SetFirstAidKit(MyItem.MyItem._FirstAidKit.medium);
            BigFAK.SetFirstAidKit(MyItem.MyItem._FirstAidKit.big);
            float Sound = 100;
            float BGM = 100;
            bool Fullscreen = true;
            x = -107.2f; y = 0f; z = 83.1f;
            sceneName = "maze1";
        }
        #endregion
        #region methods used for player
        public bool HealthUp(string type) //type == "Medium" or type == "Big"
        {
            if (type == "Medium")
            {
                if (MediumFAK.GetFirstAidKitSize() > 0)
                {
                    HP += MediumFAK.GetFirstAidKitSize();
                    MediumFAK.SetFirstAidKitSize(MediumFAK.GetFirstAidKitSize() - 1);
                    if (HP > 100)
                        HP = 100;
                    return true;
                }
                else
                    return false;
            }
            else if (type == "Big")
            {
                if (BigFAK.GetFirstAidKitSize() > 0)
                    {
                        HP += BigFAK.GetFirstAidKit();
                        BigFAK.SetFirstAidKitSize(BigFAK.GetFirstAidKitSize() - 1);
                        if (HP > 100)
                            HP = 100;
                        return true;
                    }
                else
                        return false;
            }
            else
            {
                Debug.Log("First aid kit type not recognized!");
                return false;
            }
        } //two type: "Big" and "Medium", return true if sucessfully increased health, false otherwise
        public string GetScene()
        {
            return sceneName;
        }
        public void SetScene(string newScene)
        {
            sceneName = newScene;
        }
        public void MonsterDamage(Monster.Monster currentMonster)
        {
            //TODO
        }
        public string ShowStatus()
        {
            if (HP >= 80)
                return "Healthy";
            else if (HP >= 50)
                return "Normal";
            else
                return "Bad";

        } //show current player status
        public bool BulletUp(string size)// 3 types: "Handgun","Shotgun" and "AK"; 3 size: "Small", "Medium","Large"
        {
            MyItem.MyItem currentPack;
            if (size == "Small")
                currentPack = SmallBulletPack;
            else if (size == "Medium")
                currentPack = MediumBulletPack;
            else if (size == "Large")
                currentPack = LargeBulletPack;
            else
            {
                Debug.LogError(size + " type of bullet packs does not exist!");
                return false;
            }
            if (currentPack.GetBulletPackSize() > 0)
            {
                    PlayerGun.SetHGBullet(PlayerGun.GetHGBullet() + (int)currentPack.GetBulletPack());
                    currentPack.SetBulletPackSize(currentPack.GetBulletPackSize() - 1);
                    if (PlayerGun.GetHGBullet() > 40)
                        PlayerGun.SetHGBullet(40);
                    return true;
                }
                else
                    return false;

        }


        public int GetHP()
        {
            return HP;
        } //return player's HP
        public void SetHP(int newHP)
        {
            HP = newHP;
        } //set player's HP
        public void AddPoletoMap()
        {
            Pole.SetPole(Pole.GetPole() - 1);
        }
        #endregion
    }
    public class SaveDataProcessing
    {
        public static void Save(ref Player SavePlayer)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.Create(Directory.GetCurrentDirectory() + "/Assets/SaveData/" +SavePlayer.PlayerName+".sav");
            formatter.Serialize(stream, SavePlayer);
            stream.Close();
        }
        public static Player Load(string FileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = File.Open(Directory.GetCurrentDirectory() + "/Assets/SaveData/" + FileName + ".sav",FileMode.Open);
            Player obj = (Player)formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }
        public static string[] GetSaveDataName()
        {
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory() + "/Assets/SaveData");
            FileInfo[] list = d.GetFiles("*.sav");
            string[] FileList = new string[list.Length];
            for (int i = 0; i < list.Length; i++)
                FileList[i] = list[i].Name;
            return FileList;
        }
    }
}
