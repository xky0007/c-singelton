public class InternalSingelton
{
    private InternalSingelton(){}

    private static InternalSingelton instance;

    public InternalSingelton Instance
    {
        get
        {
            return instance;
        }
    }

    internal class Nested
    {
        static Nested()
        {
            instance = new InternalSingelton();
        }
    }
}