namespace Sharper
{
    public interface PersistentList<out A>
    {
        bool IsCons { get; }
        bool IsNil { get; }
    }

    public class Cons<A> : PersistentList<A>
    {
        public Cons(A head, PersistentList<A> tail)
        {
            Head = head;
            Tail = tail;
        }

        public bool IsCons
        {
            get { return true; }
        }

        public bool IsNil
        {
            get { return !IsCons; }
        }

        public A Head { get; private set; }
        public PersistentList<A> Tail { get; private set; }
    }

    public class Nil<A> : PersistentList<A>
    {
        public bool IsCons
        {
            get { return false; }
        }

        public bool IsNil
        {
            get { return !IsCons; }
        }
    }
}