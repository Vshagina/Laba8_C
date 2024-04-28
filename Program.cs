class GenericArray<T>
{
    private T[] array;
    private int size;

    public GenericArray(int capacity)
    {
        array = new T[capacity];
        size = 0;
    }

    public void Add(T item)
    {
        if (size < array.Length)
        {
            array[size] = item;
            size++;
        }
        else
        {
            Console.WriteLine("Массив заполнен. Не удается добавить больше элементов.");
        }
    }

    public bool RemoveAt(int index)
    {
        if (index >= 0 && index < size)
        {
            for (int i = index; i < size - 1; i++)
            {
                array[i] = array[i + 1];
            }
            size--;
            return true;
        }
        else
        {
            Console.WriteLine("Неверный индекс. Элемент не удален.");
            return false;
        }
    }

    public T GetElementAt(int index)
    {
        if (index >= 0 && index < size)
        {
            return array[index];
        }
        else
        {
            Console.WriteLine("Неверный индекс. Возвращает значение по умолчанию.");
            return default(T);
        }
    }

    public int Length()
    {
        return size;
    }
}
class Credentials
{
    public string Username { get; set; }
    public string Password { get; set; }
}

class UserCredentials : GenericArray<Credentials>
{
    public UserCredentials(int capacity) : base(capacity)
    {
    }

    public void RegisterUser(string username, string password)
    {
        Credentials credentials = new Credentials { Username = username, Password = password };
        Add(credentials);
    }
}

class Program
{
    static void Main(string[] args)
    {
        UserCredentials userCredentials = new UserCredentials(2);
        userCredentials.RegisterUser("Антон", "Петров");
        userCredentials.RegisterUser("Вадим", "Сидоров");

        Console.WriteLine("Зарегистрированные пользователи:");
        for (int i = 0; i < userCredentials.Length(); i++)
        {
            Credentials credentials = userCredentials.GetElementAt(i);
            Console.WriteLine("Имя: " + credentials.Username + ", Пароль: " + credentials.Password);
        }
    }
}