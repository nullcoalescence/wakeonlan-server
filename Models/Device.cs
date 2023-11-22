namespace wakeonlan_server.Models
{
    public class Device
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string MacAddress { get; set; }
    }
}
