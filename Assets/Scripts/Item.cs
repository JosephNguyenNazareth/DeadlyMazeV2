using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyItem
{
    [System.Serializable]
    public class Gun
    {
        public enum _GunPower : int { Weak = 5, Average = 20, Strong = 40 };
        #region properties
        public _GunPower GunPower;
        int HandgunBullet;
        /***************************/
        #endregion
        #region contructor
        public Gun()
        {
            HandgunBullet = 40;
        }
        #endregion
        #region Methods for struct Gun
        public void SetHGBullet(int HG)
        {
            HandgunBullet = HG;

        } //set bullet for handgun
        public int GetHGBullet()
        {
            return HandgunBullet;
        } //Get Hand gun Bullet
        #endregion
    }
    [System.Serializable]
    public class MyItem
    {
        #region THE ONLY THING THAT YOU NEED TO KNOW IN THIS PART IS PUBLIC THINGY
        /******************/
        #region properties
        //BulletPack
        public enum _BulletPack : int { small = 10, medium = 20, large = 40 };
        _BulletPack BPType;
        int BPSize;
        /*****************/

        //Gun
        Gun G;
        /****************/

        //First-aids kits
        public enum _FirstAidKit : int { medium = 20, big = 50 };
        _FirstAidKit FAKType;
        int FAKSize;
        /****************/

        //poles
        int PoleSize;

        //treasure
        const int TreasureSize = 1;
        /****************/

        //item state
        public enum _Item : int { BulletPack = 0, FirstAidKit = 1, Treasure = 2, Pole = 3};
        bool[] ItemType = { false, false, false, false }; //Determine existence of an item in Object Item
        /****************/


        #endregion
        #region contructor
        public MyItem(params _Item[] ItemTypeList)
        {
            for (int i = 0; i < ItemTypeList.Length; i++)
                ItemType[(int)ItemTypeList[i]] = true;
            FAKSize = 0;
            BPSize = 0;
            PoleSize = 0;
        }
        /****************/
        #endregion
        #endregion

        #region  Methods for status of items
    
        public bool Check(_Item i) //check the existence of an item
        {
            return ItemType[(int)i];
        }
        public void AddItem(_Item i) // add an item
        {
            if(ItemType[(int)i])
                Debug.LogWarning("There already exists that item!");
            else
                ItemType[(int)i] = true;
        }
        public void RemoveItem(_Item i) //remove an item
        {
            if (!ItemType[(int)i])
                Debug.LogWarning("Specified item does not exist in Object Item!");
            else
                ItemType[(int)i] = false;
        }
        #endregion
        #region Methods for Bullet Pack
        public void SetBulletPack(_BulletPack i)//Change the type of bullet pack
        {
            if (ItemType[(int)_Item.BulletPack])
                BPType = i;
            else
                Debug.LogError("Bullet Pack does not exist in current Object Item!");
        }
        public int GetBulletPack()//number of bullet in ONE SPECIFIC bullet pack
        {
            if(ItemType[(int)_Item.BulletPack])
                return (int)BPType;
            else
            {
                Debug.LogError("Bullet Pack does not exist in current Object Item!");
                return 0;
            }
        }
        public void SetBulletPackSize(int size)//Change the number of bullet packs
        {
            if (ItemType[(int)_Item.BulletPack])
                BPSize = size;
            else
                Debug.LogError("Bullet Pack does not exist in current Object Item!");
            
        }
        public int GetBulletPackSize() // get the numbers of bullet packs
        {
            if (ItemType[(int)_Item.BulletPack])
                return BPSize;
            else
            {
                Debug.LogError("Bullet Pack does not exist in current Object Item!");
                return 0;
            }
            
        }
        #endregion
        #region Methods for First Aid Kit
        public void SetFirstAidKit(_FirstAidKit i)//Change the type of first aid kit
        {
            if (ItemType[(int)_Item.FirstAidKit])
                FAKType = i;
            else
                Debug.LogError("First Aid Kit does not exist in current Object Item!");
        }
        public int GetFirstAidKit() //energy recovered from 1 FAK
        {
            if (ItemType[(int)_Item.FirstAidKit])
                return (int)FAKType;
            else
            {
                Debug.LogError("First Aid Kit does not exist in current Object Item!");
                return 0;
            }
        }
        public void SetFirstAidKitSize(int size) //Change the number of FAKs
        {
            if(ItemType[(int)_Item.FirstAidKit])
                FAKSize = size;
            else
                Debug.LogError("First Aid Kit does not exist in current Object Item!");
        } //change current FAK type size
        public int GetFirstAidKitSize()//get the numbers of FAKs
        {
            if (ItemType[(int)_Item.FirstAidKit])
                return FAKSize;
            else
            {
                Debug.LogError("First Aid Kit does not exist in current Object Item!");
                return 0;
            }
            
        }
        #endregion
        //no methods for treasure!
        #region Methods for Poles
        public int GetPole()
        {
            if(ItemType[(int)_Item.Pole])
                return PoleSize;
            else
            {
                Debug.LogError("Pole does not exist in current Object Item!");
                return 0;
            }
        } //Get number of poles
        public void SetPole(int i)
        {
            if (ItemType[(int)_Item.Pole])
                PoleSize = i;
            else
                Debug.LogError("Pole does not exist in current Object Item!");
        }//Set poles to i
        #endregion
    }
}
