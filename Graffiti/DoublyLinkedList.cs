using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graffiti
{
    class DoublyLinkedList
    {
        Node head; // головной/первый элемент
        Node tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        //Формальные параметры: data- ключ
        //Входные данные:список
        //Выходные данные: список
        public void Add(int data)
        {
            Node node = new Node(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        //добавление элемента в начало
        //Формальные параметры:data- ключ
        //Входные данные: список
        //Выходные данные:список
        public void AddFirst(int data)
        {
            Node node = new Node(data);
            Node temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        // удаление
        //Формальные параметры:data- ключ
        //Входные данные: ключ
        //Выходные данные: список
        public bool Remove(int data)
        {
            Node current = head;

            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = current.Previous;
                }

                // если узел не первый
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        //Очистка списка
        //Формальные параметры:пусто
        //Входные данные: список
        //Выходные данные: пустой список
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        //Содержится ли
        //Формальные параметры:data- ключ
        //Входные данные: список
        //Выходные данные: список
        public bool Contains(int data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        //Вывод
        //Формальные параметры:пусто
        //Входные данные: список
        //Выходные данные: список
        public void Print()
        {
            if (count==0)
            {
                Console.WriteLine(" ");
                return;
            }
            Node current = head;
            while (current!=tail)
            {
                Console.Write(current.Data+", ");
                current = current.Next;
            }
            Console.WriteLine(current.Data);
        }



    }
}
