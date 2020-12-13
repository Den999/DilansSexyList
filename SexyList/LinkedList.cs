using System;
using System.Data.Common;
using System.Collections;

namespace LinkedList
{
    /// <summary>
    /// Необходимо реализовать унаследованный классом LinkedList интерфейс 
    /// (реализовать = написать все объявленные в нем методы)
    /// throw new NotImplementedException(); подлежат удалению и замене на реализацию каждой ветви кода, где такие бросания сейчас находятся.
    /// Кроме того, я не выписал некоторые члены интерфейса, 
    /// потому программа поначалу не будет компилироваться - просьба разобраться и выписать их самим - гугл и студия в помощь.
    /// 
    /// Сразу поясняю T - не равно Node!
    /// Другие члены - поля, свойства, методы и пр. - можно добавлять на ваше усмотрение!
    /// </summary>
    /// <typeparam name="T"></typeparam>

    class LinkedList<T> : ICustomCollection<T>
    {
        private int _index;
        
        private Node<T> _head;

        public T this[int index]
        {
            get
            {
                if (_index == 0)
                {
                    throw new IndexOutOfRangeException();
                }

                int iter = 0;

                var currentNode = _head;

                while (iter < index && currentNode.nextMember != null)
                {
                    iter++;
                    currentNode = currentNode.nextMember;
                }

                if (iter == index)
                {
                    return currentNode.member;
                }

                throw new IndexOutOfRangeException();
            }
            set
            {
                if (_index == 0)
                {
                    throw new IndexOutOfRangeException();
                }

                int iter = 0;

                var currentNode = _head;

                while (iter < index && currentNode.nextMember != null)
                {
                    iter++;
                    currentNode = currentNode.nextMember;
                }

                if (iter == index)
                {
                    currentNode.member = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public int Length => _index;

        public void AddItem(T item)
        {
            if (_head != null)
            {
                var currentNode = _head;

                while (currentNode.nextMember != null)
                {
                    currentNode = currentNode.nextMember;
                }

                var newNode = new Node<T>(item);
                currentNode.nextMember = newNode;
                newNode.nextMember = null;
            }
            else
            {
                _head = new Node<T>(item) {nextMember = null};
            }

            _index++;
        }
        
        public void RemoveItem(int index)
        {
            if (_index != 0)
            {
                int iter = 0;

                var currentNode = _head;
                Node<T> nodeBefore = null;

                while (iter < index && currentNode.nextMember != null)
                {
                    iter++;
                    nodeBefore = currentNode;
                    currentNode = currentNode.nextMember;
                }

                if (iter == index)
                {
                    if (nodeBefore == null)
                    {
                        _head = currentNode.nextMember;
                    }
                    else
                    {
                        nodeBefore.nextMember = currentNode.nextMember;
                    }

                    _index--;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        
        public bool Has(T item)
        {
            var currentNode = _head;

            while (currentNode.nextMember != null)
            {
                if (Comparer.Default.Compare(currentNode.member, item) != 0)
                {
                    currentNode = currentNode.nextMember;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsEmpty() => _index == 0;
        
        public override string ToString()
        {
            string text = $"collection with length {_index}\n";

            if (_index == 0)
            {
                return text;
            }

            var currentNode = _head;

            while (currentNode.nextMember != null)
            {
                text += $"element with value {currentNode.member}\n";
                currentNode = currentNode.nextMember;
            }

            return text;
        }
    }
    /// <summary>
    /// Это класс, представляющий из себя коробочки, из которых должен состоять односвязный список - 
    /// какие в нем должны быть члены - 
    /// можно догадаться, 
    /// посмотреть в справочном материале в гугле/слаке, 
    /// вспомнить, о чем говорилось в конце занятия в субботу
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        public T member;
        
        public Node<T> nextMember;

        public Node(T value)
        {
            member = value;
        }
    }
}