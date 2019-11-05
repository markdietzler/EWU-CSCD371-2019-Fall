namespace Mailbox
{
    public class Mailbox
    {
        public Sizes mSize { get; }
        public (int, int) mLocation { get; }
        public Person mOwner { get; set; }
        public Mailbox(Sizes newSize, (int, int) newLocation, Person newOwner)
        {
            this.mSize = newSize;
            this.mLocation = mLocation;
            this.mOwner = newOwner;
        }

        public string toString()
        {
            return $"{"Size: " + mSize + " Location: (" + mLocation + ") Owner: " + mOwner.toString()}";
        }
    }
}
