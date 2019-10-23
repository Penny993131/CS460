using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// This is the Interface class for the LinkedQueue that we will use in the LinkedQueue class.
/// </summary>
namespace _460HW3
{
    /// <summary>
    ///  A FIFO queue interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IQueueInterface<T>
    {
        /// <summary>
        /// This method will push or add an element to the list.
        /// <param name="element"></param> this is the element being appended.
        /// <returns> return the element that was enqueued</returns>
        /// </summary>
        T Push(T element);

        /// <summary>
        ///  this function shows what is on top of the list.
        /// </summary>
        /// <returns>Remove and return the front element.|Returns the object on top or recently appended</returns>
        T Pop();


        /// <summary>
        /// Return but don't remove the front element.
        /// </summary>
    
        T Peek();


        /// <summary>
        ///  This method returns a bool (true or false) depending on if the the list is empty or not
        ///  True if it exits an element ,false if the list is empty.
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

    }
}


