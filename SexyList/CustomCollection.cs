﻿namespace LinkedList
{
    /// <summary>
    /// Ниже представлен интерфейс CustomCollection
    /// Ко всему прочему, он еще и обобщенный <T> - это значит, что класс (коллекция), 
    /// которая его реализует, сможет оперировать с объектами любого заданного типа (подробнее об этом будет позже)
    /// </summary>
    /// <typeparam name="T">Тип хранимых данных</typeparam>
    interface ICustomCollection<T>
    {
        /// <summary>
        /// Свойство, возвращающее текущий размер коллекции 
        /// (Для тех, кто все успел - возможно реализовать амортизацию вызова этого свойства путем кеширования)
        /// </summary>
        int Length { get; }
        
        /// <summary>
        /// Добавляет элемент в конец коллекции
        /// </summary>
        /// <param name="item"></param>
        void AddItem(T item);

        /// <summary>
        /// Удаляет элемент по индексу index
        /// </summary>
        /// <param name="index"></param>
        void RemoveItem(int index);

        /// <summary>
        /// Возвращает информацию о том, есть ли в коллекции запрашиваемый элемент типа T
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Has(T item);

        /// <summary>
        /// Это индексатор, по сути своей - некое "массивное" свойство, которое доступно через индекс, как при обращении к элементам массива по индексу array[index]
        /// То есть, если у вас есть некая коллекция, которую вы реализовали, то возможно следующее:
        /// Collection<int> C = new Collection<int>(); // в данном случае, создана коллекция для переменных типа int (T = int)
        /// C.Add(1);
        /// int a = C[0];  // a = 1;
        /// C[1] = 10;     // вы присваиваете первому элементу свой коллекции значение 10.
        /// Остается открытым главный вопрос - как вы будете получать это самое значение и как вы будете его вставлять в коллекцию? 
        /// (зависит полностью от вас, принципы те же, что и у свойства - через get и set, только у вас появляется еще один параметр - index, который вам передали в квадратных скобках)
        /// В нашем случае, если элемента по такому индексу - нет, бросается исключение IndexOutOfRangeException
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T this[int index] { get; set; }

        /// <summary>
        /// Метод, сообщающий о пустоте коллекции
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// Метод, возвращающий строковое представление коллекции
        /// </summary>
        string ToString();

    }
}
