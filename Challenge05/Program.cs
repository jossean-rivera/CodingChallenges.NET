
//  The function Cons is a funtion that takes two values and return a funtion that returns a pair (or tupple) of those two values
//  Translate the following python code into C#
/*
    def cons(a, b):
        def pair(f):
            return f(a, b)
        return pair
*/
Func<Func<T, T, T>, T> Cons<T>(T a, T b)
{
    T Pair(Func<T, T, T> f) 
    {
        return f(a, b);
    }

    return Pair;
}

//  Implement Car
T Car<T>(Func<Func<T, T, T>, T> pair)
{
    return pair((T a, T b) => a);
}

//  Implement Cdr
T Cdr<T>(Func<Func<T, T, T>, T> pair)
{
    return pair((T a, T b) => b);
}

//  Test car(cons(3, 4)) returns 3
int car = Car(Cons(3, 4));
Console.WriteLine("car(cons(3, 4)) returns {0}", car);

//  Test cdr(cons(3, 4)) returns 4
int cdr = Cdr(Cons(3, 4));
Console.WriteLine("cdr(cons(3, 4)) returns {0}", cdr);
