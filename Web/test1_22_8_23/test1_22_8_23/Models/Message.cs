namespace test1_22_8_23.Models
{
    public class Message
    {
        public string msg { get; set; }
        public int pgnum { get; set; }

        public Message() { }

        public Message(string msg, int pgnum ) {
            this.msg = msg;
            this.pgnum = pgnum;
        }

    }
}
