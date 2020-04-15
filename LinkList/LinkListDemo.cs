using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkList
{
    /// <summary>
    /// 线性表
    /// </summary>
    public class LinkListDemo
    {
        /*线性表：0个或多个数据元素的有限序列；线性表的前后两个元素存在一一对应关系。逻辑对应而非物理对应，如银行取号
          顺序表：用一块地址连续的存储空间依次存储线性表中的数据元素；特性：逻辑相邻的元素在物理上也是相邻的，如排队买包子，程序体现为数组
          链表：逻辑相邻的元素物理上可以不相邻，如银行取号，特定场合，链表的使用优先于顺序表
          必须占用一块事先分好的存储空间*/


        #region 数组
        /*数组：存放值类型时，存放的是值类型本身，存放引用类型时，存放的是对象的引用（指针）*/
        int[] arrayInt = new int[5];
        string[] arrayString = new string[5];
        public void GetArrayValue()
        {
            arrayInt[0] = 2;
            arrayInt[3] = 5;
            arrayString[0] = "abc";
            arrayString[3] = "xyz";
            foreach (var item in arrayInt)
            {
                Console.WriteLine(item);//2,0,0,5,0
            }
            foreach (var item in arrayString)
            {
                Console.WriteLine(item);//abc,null,null,xyz,null(null体现为空)
            }
        }
        #endregion

        #region ArrayList<T>和List<T>
        //ArrayList<T>简单好用但不是类型安全
        ArrayList ArrayList;
        public void Add(object value) 
        {
            ArrayList.Add(value);
        }
        public void RemoveAt(int index) 
        {
            ArrayList.Remove(index);
        }
        /*源码
        public virtual int Add(object value)
        {
            判断链表是否溢出
            if(this._size==this._item.length)
            {
                调整存储空间大小
                this.EnsureCapacity(this._size + 1);
            }
            在末尾添加数据
            this._item[this._size]=value;
            retrun this._size++;
        }
        移除某个位置的数据
        public virtual void RemoveAt(int index)
        {
            if(index < 0 || index >this._size)
            {
                throw new ArgumentOutOfRangeException("index","索引超出范围");
            }
            for(int i=index+1;i<this._size;i++)
            {
                this._item[index - 1]=this._item[i];
            }
            this._size--;
            this._item[this._size]=null;//空出最后一位
        }
        动态调整数组大小
        private void EnsureCapacity(int min)
        {
            if(this._size < min)
            {
                新空间大小为原空间大小的两倍
                int num = this._item.length == 0 ?_defaultCapacity : this._item.length * 2;
                if(num < min)
                {
                    num = min;
                }
                //调整数组空间大小
                this.Capacity = mun;
            }
        }
        ArrayList在删除、扩容时会进行大量的数据移动。不断的装箱拆箱会降低程序性能，故诞生泛型版本List<T>
         */
        List<int> list = new List<int>();
        //避免了装箱、拆箱，而且是安全的
        #endregion

        
    }
    
}
