namespace Cursova
{
    public interface ServiceFrontDesk
    {
        int sizeQueue();
        void add(Passanger passanger);
        bool isWorked();
        void setStewaredss();
    }
}