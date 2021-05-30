namespace Cursova
{
    public interface ServiceFrontDesk
    {
        int sizeQueue();
        void add(Human passanger);
        bool isWorked();
        void setStewaredss(Stewardess stewardess);
        void startWork();
    }
}