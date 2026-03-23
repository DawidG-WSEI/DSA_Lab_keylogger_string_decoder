// Zadanie: Złam hasło
// Keylogger zainstalowany na komputerze ofiary rejestruje naciśnięcia klawiszy podczas wprowadzania hasła w tekstowym polu formularza i zapisuje je do postaci napisu. Zakładamy, że tekst edytowany jest w trybie insert (pionowa kreska kursora między dwoma znakami).
// Rejestrowane są klawisze alfanumeryczne oraz trzy klawisze specjalne, zakodowane w następujący sposób:
// < reprezentuje strzałkę w lewo (przesunięcie kursora w lewo o 1 pozycję).
// > reprezentuje strzałkę w prawo  (przesunięcie kursora w prawo o 1 pozycję).
// - reprezentuje klawisz Backspace (usunięcie znaku na lewo od kursora).
// Przykładowo:
// ofiara wprowadziła tekst generio1
// następnie nacisnęła strzałkę w lewo i wprowadziła 3 (zatem w formularzu widać generio31)
// następnie nacisnęła strzałkę w prawo i wprowadziła 2 (zatem w formularzu widnieje generio312)
// następnie wprowadziła ghj i nacisnęła trzykrotnie Backspace, usuwając te trzy litery
// zatwierdziła hasło (ostatecznie hasło to generio312)
// keylogger zwrócił tekst generio1<3>2ghj--- reprezentujący działania ofiary podczas wpisywania hasła.
// Twoim zadaniem jest ustalić ostateczną wersję hasła na podstawie zapisów keyloggera.
// Napisz program w języku C#, który wczyta ze standardowego wejścia napis wygenerowany przez keyloggera, przeanalizuje go i wypisze na standardowe wyjście przechwycone hasło.


using System.Text;

// eg. input: generio1<3>2ghj--- -> output: generio312
// eg. input: <<BP<A>C- -> output: BAP

string input = Console.ReadLine() ?? String.Empty;
Console.WriteLine(Decoder(input));

StringBuilder Decoder(string input)
{
    var left = new MyStack<char>();
    var right = new MyStack<char>();

    foreach(var c in input)
    {
        switch(c)
        {
            case '<':
                if(!left.IsEmpty())
                    right.Push(left.Pop());
                break;
            case '>':
                if(!right.IsEmpty())
                    left.Push(right.Pop());
                break;
            case '-':
                if(!left.IsEmpty())
                    left.Pop();
                break;
            default:
                left.Push(c);
                break;
        }
    }

    var leftArray = left.ToArray();
    Array.Reverse(leftArray);
    var rightArray = right.ToArray();

    StringBuilder finalWord = new StringBuilder(leftArray.Length + rightArray.Length);
    finalWord.Append(leftArray);
    finalWord.Append(rightArray);

    return finalWord;
}

public class MyStack<T>
{
    private T[] _items;
    private int _count;

    public MyStack(int initialCapacity = 10)
    {
        _items = new T[initialCapacity];
    }

    public T Peek() => IsEmpty()? throw new IndexOutOfRangeException("Empty stack.") : _items[_count-1];

    public T Pop()
    {
        if(IsEmpty())
            throw new InvalidOperationException("Empty Stack.");
        _count--;
        T popedItem = _items[_count];
        _items[_count] = default(T)!;
        return popedItem;
    }

    public void Push(T item)
    {
        if(_count == _items.Length)
            Array.Resize(ref _items, _items.Length * 2);
        _items[_count] = item;
        _count++;
    }

    public bool IsEmpty() => _count == 0;

    public T[] ToArray()
    {
        T[] itemsArray = new T[_count];

        for(int i = 0; i < _count; i++)
        {
            itemsArray[i] = _items[_count -1 - i];            
        }
        return itemsArray;
    }
    public int Count => _count;
}
