namespace TaskTracker.Sandbox.Dto
{
    public class JobDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
        
        public override string ToString()
        {
            return $"JobDto:\nid: {Id}\ntext: {Text}";
        }
    }
}