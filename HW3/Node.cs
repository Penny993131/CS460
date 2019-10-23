using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _460HW3
{
    class Node<T>
    {
        public T data; //This is the data that is in the Node
        public Node<T> next; // This points to the next Node

        /// <summary>
        ///This is the default constructor of the Node Class
        ///<paramref name="data"/>Object that is held within the node
        ///<paramref name="next"/>Pointer to the node next to it
        /// </summary>
        /// 
        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }

    }
}
