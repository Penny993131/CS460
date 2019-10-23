using System;
using System.Collections.Generic;
using System.Text;

namespace _460HW3
{
    /// <summary>
    /// Singly Linked FIFO Queue that Implements the IQueueInterface
    /// See IQueueInterface class for more information
    /// </summary>
    /// <typeparam name="T">takes in the node object</typeparam>
    class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> front; //This points to the Node in the front
        private Node<T> rear; //This points to the Node in the back\


        /// <summary>
        /// This Constructor initializes the node objects by setting both to null
        /// </summary>
        public LinkedQueue()
        {
            front = null;
            rear = null;
        }
        /// <summary>
        /// This implements the method in IQueueInterface
        /// Takes an elements and pushes it in the Queue
        /// </summary>
        /// <param name="element">The element that is being added</param>
        /// <returns>the element that has been added</returns>
        public T Push(T element)
        {
            if (element == null)
            {
                throw new NullReferenceException();
            }

            if (IsEmpty())
            {
                Node<T> tmp = new Node<T>(element, null);
                rear = front = tmp;
            }
            else
            {
                Node<T> tmp = new Node<T>(element, null);
                rear.next = tmp;
                rear = tmp;
            }

            return element;
        }

        /// <summary>
        /// This method implements the method from IQueueInterface
        /// This method returns the item on top of the Queue
        /// </summary>
        /// <returns>item on top of the Queue</returns>
        public T Pop()
        {
            T tmp = default(T); // not sure
            if (IsEmpty())
            {
                throw new QueueUnderflowException("This queue was empty when pop was invoked.");
            }
            else if (front == rear)
            {
                tmp = front.data;
                front = null;
                rear = null;
            }
            else
            {
                tmp = front.data;
                front = front.next;
            }

            return tmp;

        }
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when peek was invoked.");
            }
            return front.data;
        }
        /// <summary>
        /// Implements method of the IQueueInterface
        /// This shows whether the queue is currently empty or not
        /// </summary>
        /// <returns>true if there is an item existing, false if Queue is empty</returns>
        public bool IsEmpty()
        {
            if (front == null && rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

