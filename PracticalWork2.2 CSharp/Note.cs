namespace PracticalWork2._2_CSharp
{
    internal class Note
    {
        public string Name;
        public string Description;
        public System.DateTime Date;

        public Note(string Name, string Description, System.DateTime Date)
        {
            this.Name = Name;
            this.Description = Description;
            this.Date = Date;
        }
    }
}
