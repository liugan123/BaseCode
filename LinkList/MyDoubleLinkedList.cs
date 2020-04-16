using System;
using System.Collections.Generic;
using System.Text;

namespace LinkList
{
    /// <summary>
    /// 双向链表
    /// </summary>
    public class MyDoubleLinkedList<T>
    {
        /*
         每个节点都有两个指针域，一个指向前驱节点，一个指向后继节点
         index为索引
         */
        private int count;
        private DbNode<T> head;
        public MyDoubleLinkedList() 
        {
            count = 0;
            head = null;
        }
        public int Count 
        {
            get { return this.count; }
        }
        /// <summary>
        /// 根据索引获取数据
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return GetNodeByIndex(index).Item; }
            set { GetNodeByIndex(index).Item = value; }
        }
        private DbNode<T> GetNodeByIndex(int index) 
        {
            if (index < 0 || index >this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }
            DbNode<T> dbNode = this.head;
            for (int i = 0; i < index; i++)
            {
                dbNode = dbNode.NextNode;
            }
            return dbNode;
        }
        /// <summary>
        /// 在末尾添加节点
        /// </summary>
        /// <param name="value"></param>
        public void AddAfter(T value) 
        {
            DbNode<T> dbNode = new DbNode<T>(value);
            if (this.head==null)
            {
                this.head = dbNode;
            }
            else
            {
                DbNode<T> lastNode = GetNodeByIndex(this.count - 1);
                lastNode.NextNode = dbNode;
                dbNode.PrevNode = lastNode;
            }
            this.count++;
        }
        /// <summary>
        /// 在尾节点前插入新节点
        /// </summary>
        /// <param name="value"></param>
        public void AddBefore(T value) 
        {
            DbNode<T> dbNode = new DbNode<T>(value);
            if (this.head == null)
            {
                this.head = dbNode;
            }
            else if (this.head.NextNode == null)
            {
                dbNode.NextNode = this.head;
                this.head.PrevNode = dbNode;
                this.head = dbNode;
            }
            else
            {
                DbNode<T> lastNode = GetNodeByIndex(this.count - 1);
                DbNode<T> lastSecondNode = lastNode.PrevNode;//倒数第二个
                //调整倒数第二个节点
                lastSecondNode.NextNode = dbNode;
                dbNode.PrevNode = lastSecondNode;
                //调整倒数第一个节点
                lastNode.PrevNode = dbNode;
                dbNode.NextNode = lastNode;
            }
            this.count++;
        }
        /// <summary>
        /// 在指定位置后插入新节点
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void InsertAfter(int index,T value) 
        {
            DbNode<T> dbNode = new DbNode<T>(value);
            if (index < 0 || index >this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }
            else if (index == 0)
            {
                if (this.head == null)
                {
                    this.head = dbNode;
                }
                else
                {
                    this.head.NextNode = dbNode;
                    dbNode.PrevNode = this.head;
                }
            }
            else
            {
                DbNode<T> currNode = GetNodeByIndex(index);
                DbNode<T> nextNode = currNode.NextNode;
                currNode.NextNode = dbNode;
                dbNode.PrevNode = currNode;
                if (nextNode!=null)
                {
                    nextNode.PrevNode = dbNode;
                    dbNode.NextNode = nextNode;
                }
            }
            this.count++;
        }
        /// <summary>
        /// 在指定位置前插入新节点
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value"></param>
        public void InsertBefore(int index,T value) 
        {
            DbNode<T> dbNode = new DbNode<T>(value);
            if (index < 0 || index > this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }
            else if(index == 0)
            {
                if (this.head == null)
                {
                    this.head = dbNode;
                }
                else
                {
                    this.head.PrevNode = dbNode;
                    dbNode.NextNode = this.head;
                    this.head = dbNode;
                }
            }
            else
            {
                DbNode<T> currNode = GetNodeByIndex(index);
                DbNode<T> prevNode = currNode.PrevNode;
                currNode.PrevNode = dbNode;
                prevNode.NextNode = dbNode;
                dbNode.PrevNode = prevNode;
                dbNode.NextNode = currNode;
            }
            this.count++;
        }
        /// <summary>
        /// 移除指定位置节点
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index) 
        {
            if (index < 0 || index > this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }
            else if(index == 0)
            {
                this.head = this.head?.NextNode;
            }
            else
            {
                DbNode<T> delNode = GetNodeByIndex(index);
                DbNode<T> nextNode = delNode.NextNode;
                DbNode<T> prevNode = delNode.PrevNode;
                prevNode.NextNode = nextNode;
                if (nextNode!=null)
                {
                    nextNode.PrevNode = prevNode;
                }
                delNode = null;
            }
            this.count--;
        }
        #region 测试
        public static void MyDoubleLinkedListTest()
        {
            MyDoubleLinkedList<int> linkedList = new MyDoubleLinkedList<int>();
            // Test1:顺序插入4个节点
            linkedList.AddAfter(0);
            linkedList.AddAfter(1);
            linkedList.AddAfter(2);
            linkedList.AddAfter(3);

            Console.WriteLine("The nodes in the DoubleLinkedList:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            // Test2.1:在尾节点之前插入2个节点
            linkedList.AddBefore(10);
            linkedList.AddBefore(20);
            Console.WriteLine("After add 10 and 20:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            // Test2.2:在索引为2(即第3个节点)的位置之后插入单个节点
            linkedList.InsertAfter(2, 50);
            Console.WriteLine("After add 50:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            // Test2.3:在索引为2(即第3个节点)的位置之前插入单个节点
            linkedList.InsertBefore(2, 40);
            Console.WriteLine("After add 40:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            // Test3.1:移除索引为7(即最后一个节点)的位置的节点
            linkedList.RemoveAt(7);
            Console.WriteLine("After remove an node in index of 7:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            // Test3.2:移除索引为0(即第一个节点)的位置的节点的值
            linkedList.RemoveAt(0);
            Console.WriteLine("After remove an node in index of 0:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            // Test3.3:移除索引为2(即第3个节点)的位置的节点
            linkedList.RemoveAt(2);
            Console.WriteLine("After remove an node in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            // Test4:修改索引为2(即第3个节点)的位置的节点的值
            linkedList[2] = 9;
            Console.WriteLine("After update the value of node in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");
        }
        #endregion
    }
    class DbNode<T>
    {
        public T Item { get; set; }
        public DbNode<T> PrevNode { get; set; }
        public DbNode<T> NextNode { get; set; }
        public DbNode() { }
        public DbNode(T item) 
        {
            Item = item;
        }
    }
}
