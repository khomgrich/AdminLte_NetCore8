namespace AdminLte.Models
{
    public class MenuItem
    {
        public string Title { get; set; } = "";
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string Icon { get; set; } = "fas fa-circle";
        public List<MenuItem> Children { get; set; } = new List<MenuItem>(); // สำหรับเก็บเมนูย่อย
    }
}

